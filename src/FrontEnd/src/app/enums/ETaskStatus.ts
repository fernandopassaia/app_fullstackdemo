export enum ETaskStatus {
  All = 0,
  Todo = 1,
  Done = 2,
}

export const ETaskStatusDesc = {
  [ETaskStatus.All]: "Todos",
  [ETaskStatus.Todo]: "Pendente",
  [ETaskStatus.Done]: "Executado",
};
