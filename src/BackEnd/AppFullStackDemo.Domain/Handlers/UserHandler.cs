using AppFullStackDemo.Domain.Commands;
using AppFullStackDemo.Domain.Commands.User;
using AppFullStackDemo.Domain.Handlers.Contracts;
using Flunt.Notifications;

namespace AppFullStackDemo.Domain.Handlers
{
    public class TodoHandler :
        Notifiable,
        IHandler<CreateUserCommand>,
        IHandler<UpdateUserCommand>,
        IHandler<LoginUserCommand>
    {
        private readonly ITodoRepository _repository;

        public TodoHandler(ITodoRepository repository)
        {
            _repository = repository;
        }

        public IBaseCommandResult Handle(CreateUserCommand command)
        {
            // Fail Fast Validation
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Ops, parece que sua tarefa está errada!", command.Notifications);

            // Gera o TodoItem
            var todo = new TodoItem(command.Title, command.User, command.Date);

            // Salva no banco
            _repository.Create(todo);

            // Retorna o resultado
            return new GenericCommandResult(true, "Tarefa salva", todo);
        }

        public IBaseCommandResult Handle(UpdateUserCommand command)
        {
            // Fail Fast Validation
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Ops, parece que sua tarefa está errada!", command.Notifications);

            // Recupera o TodoItem (Rehidratação)
            var todo = _repository.GetById(command.Id, command.User);

            // Altera o título
            todo.UpdateTitle(command.Title);

            // Salva no banco
            _repository.Update(todo);

            // Retorna o resultado
            return new GenericCommandResult(true, "Tarefa salva", todo);
        }

        public IBaseCommandResult Handle(LoginUserCommand command)
        {
            // Fail Fast Validation
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Ops, parece que sua tarefa está errada!", command.Notifications);

            // Recupera o TodoItem
            var todo = _repository.GetById(command.Id, command.User);

            // Altera o estado
            todo.MarkAsDone();

            // Salva no banco
            _repository.Update(todo);

            // Retorna o resultado
            return new GenericCommandResult(true, "Tarefa salva", todo);
        }
    }
}