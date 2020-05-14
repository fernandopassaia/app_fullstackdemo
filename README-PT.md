### AppFullStackDemo .NetCore 3.1 DDD/SOLID/CQRS/Api Rest
### Angular Material Panel + React Native Mobile.
### Se você gostar desse projeto, por favor siga e nos dê uma estrela :sunglasses: :computer:

* Nota 1: Eu também gravei alguns tutoriais em vídeo que mostram como rodar essa app. Basta acessar meu canal: https://www.youtube.com/channel/UCFzZD9snKFKZAx-FwL6SpeQ
* Nota 2: Você pode usar apenas partes desse sistema. Exemplo: Se você não é um DevMobile, apenas ignore.

# 
### Lógica de negócios:
Como funciona: O PainelWeb (Angular Material) e o Aplicativo Mobile (React Native) irão ter uma tela de Login, que irá
trabalhar com o BackEnd para logar - no caso do painel haverá um gerenciamento completo com DashBoard + 3 CRUDs + Lista/
Detalhes. No caso do aplicativo mobile você poderá ver os detalhes do Dispositivo e registrar ele no portal. Uma vez
registrado, você verá ele no Painel ligado ao usuário logado (detalhes do device) e irá interagir na Dashboard.

**FrontEnd** irá ter uma tela de login, onde o usuário pode clicar "Registrar agora" e criar um novo usuário, ou mesmo
logar com um existente. No painel você terá a DashBoard (mostrando gráficos com número de dispositivos por versão de 
android, e número de dispositivos por fabricante). Usuários logados no painel poderão criar novos usuários e também
poderão logar no painel e no app mobile. Então: A tela de Login terá uma função completa de CRUD (Listar, Criar, Editar,
Excluir usuários).

Na tela de usuário (lista) haverá um botão para listar os dispositivos para o usuário (detalhes do device). Então ao 
logar em um Dispositivo, o usuário poderá registrar e então ficará disponível os detalhes no painel. Haverá mais duas
telas para gerenciar Fabricantes e Modelos. Um Equipamento pertence a um Modelo, e um Modelo a um Fabricante:

Fabricante: Samsung. Modelos: Galaxy S8, Galaxy S9, Galaxy S10, Galaxy Note 8, Galaxy Note 9.
Fabricante: Xiaomi. Modelos: Mi8, Mi9, Mi10, Redmi8, Redmi 9, Mi Max 2, Mix Max3, Mi Mix2.

O BackEnd irá automaticamente gerenciar isso, procurando pelos modelos e fabricantes e criando se não existirem, ou
anexar o equipamento ao Fabricante>Modelo existente. O Painel Angular também está pronto pra trabalhar com Token, com
uma camada interceptor para lidar com códigos 401/403, mostrar mensagens de OK, alertas, mensagens de popup, modals e
um monte de coisas legais com um um Design Material.

**BackEnd** irá provar uma API para suportar o Painel e o Mobile. Todo o "cérebro" do APP: A lógica de negócios,
entidades, camadas de banco de dados, API, Serviços e Manipuladores estarão aqui. **Abaixo do capô**: Um BackEnd .Net
Core com Arquitetura Rica DDD/SOLID que rodará provendo toda a informação para ambos os Apps.

**MobileApp** pode registrar o Equipmento no BackEnd - informando o Fabricante, Modelo, Número Phone, Número Serial,
Imei e algumas outras informações. Você pode usar seu Aparelho Real ou mesmo um Emulador (como Android Studio ou
Genymotion) para testar. Uma vez que é React-Native e você tiver um Mac - pode trabalhar para compilar para iOS.

Note que o MobileApp é um bônus: Esse App irá basicamente apenas listar algumas informações sobre o Device, e irá
permitir que esse equipamento seja registrado no BackEnd, e então aparecerá no painel. Eu não sou um desenvolvedor
ReactNative, então você pode me ajudar a melhorar esse App e fazê-lo melhor :)

![Login Panel](https://github.com/fernandopassaia/app_fullstackdemo/blob/master/panel/Panel1.png)

![Register Page](https://github.com/fernandopassaia/app_fullstackdemo/blob/master/panel/Panel2.png)

![DashBoard](https://github.com/fernandopassaia/app_fullstackdemo/blob/master/panel/Panel3.png)

![DashBoard2](https://github.com/fernandopassaia/app_fullstackdemo/blob/master/panel/Panel4.png)

![UpdateDeviceModel](https://github.com/fernandopassaia/app_fullstackdemo/blob/master/panel/Panel5.png)

![UserCrud](https://github.com/fernandopassaia/app_fullstackdemo/blob/master/panel/Panel6.png)

![UserDetails](https://github.com/fernandopassaia/app_fullstackdemo/blob/master/panel/Panel7.png)

![DeviceDetails](https://github.com/fernandopassaia/app_fullstackdemo/blob/master/panel/Panel8.png)

# 
### BackEnd .NET Core 3.1 C# + EF Core (SQLServer). Rich Architecture DDD/SOLID using:

* Modelagem rica (Models-Entities, Enums, ValueObjects) (leia abaixo para as regras de negócio)
* Api REST + Handlers (Services) para lidar com as requisições - injeção de dependência
* JWT Token para Autenticação + Claims + Json para transferir Data
* Camada de Handler (você pode chamar de Serviço) para orquestrar as requisições
* Entity Framework Core com camadas separadas para o ConfigMap das Tabelas + SQL Server Express (Free)
* Camada de Repositórios + Unit of Work + 3 CRUDS (EF Code First)
* CQRS para Receber Queries, Commands e Retornar Results
* Validação por Contratos nos Comandos (Fail-Fast Validations)
* Padrão (BaseCommandResult) para os Retornos da Api de uma forma bem definida
* Projeto Compartilhado (shared classlib) para formatação de campos, validações e criptografia
* Criador de Dados-Teste para preencher o banco de dados e iniciar com alguns dados de teste
* Testes de unidade para os commandos, queries, repositórios, entidades e handlers
* Nota: Banco de dados pode ser facilmente substituido (para Postgres, MySQL) uma vez que as camadas são separadas.

### FrontEnd Angular + Material Panel + Login + Auth + 3 Full-CRUDS + Detail screen:
* Painel completo para Criar Conta, Logar + DashBoard + 3 Cruds Completos (leia abaixo a regra de negócio)
* Bela Interface Angular Material com Modals, MatTable, Charlist e mais
* CQRS e Interfaces baseados no BackEnd (Commands and Results)
* Camada de Serviço e Comunicação de API - pronta para capturar resultados e mostrar mensagens (como mensagens de OK ou
listas de erros) do backend (você não precisa tratar cada mensagem e mostrar ao usuário o que ocorreu (httpinterceptor))
* Módulos e arquivos de rotas separados para uma melhor organização.
* Serviços Compartilhados para Dialogs, Mensagens de Notificação, Telas de Modal, Descrição de Enums.
* Camada de Autenticação (Interceptor) para lidar perfeitamente com os Tokens, Autenticação, Headers (401/403).

### Mobile React-Native + Device-Info:
A tela de Login irá se comunicar com o BackEnd para Autenticar e Receber o Token. Uma vez logado, o AppMobile irá 
permitir o usuário adicionar o Device na sua conta com os detalhes (Imei, Número Fone, Número Série, Fabricante, Modelo).
Uma vez registrado, o Equipamento e sua informação irá aparecer no Painel em Usuário > Lista de Equipamentos.

# 
### Licença de Uso desse App num mundo real:
Nota: Esse App é Livre e totalmente opensource. Você pode usar como base do seu sistema, ou também pode colaborar comigo
para melhorá-lo. Num mundo real, esse APP precisa ser melhor planejado:

Usuários devem pertencer a uma Compania (ou ainda melhor - Usuários devem pertencer a uma entidade como Colaborador),
as Claims devem ter profiles (como Mestre, Admin) de onde as claims serão conectadas (não diretamente ao usuário). Nós
também precisamos de uma tela para gerenciar as claims (que não temos nesse app). Criar categorias para os Devices:

Também é necessário implementar coisas como RefreshToken, Email de welcome, recuperação de senha, mudança de senha e mais.
Nós precisamos adaptar várias coisas para atender uma Lógica de negócios.

Mas para agora: Lembre-se que esse app é um demo de programação, arquitetura e skills técnicos - NÃO um demo de aplicativo
do mundo real. Então iremos manter as regras de negócio simples e focar em pontos técnicos. De qualquer forma, você pode
usar como base para seu sistema e arquitetura, e iniciar seu sistema sobre esse, seguindo os padrões já implementados aqui.
Você pode usar como um "esqueleto" para seu próximo software real. Boa sorte :cake:

# 
### Como rodar o App e Informações Técnicas:
Você pode Desenvolver e rodar no Windows, Linux ou MacOs. Na minha máquina: Eu usei Linux Ubuntu 20.04 e VS Code :)

**Tutorial**: Se você preferir um Tutorial em vídeo sobre como rodar esse App, basta acessar:
https://www.youtube.com/watch?v=ck3GnZC3vho

Se você quiser saber como eu configuro meu ambiente: VSCode, extensões, as fontes que uso, as variáveis de ambiente e como
eu configuro elas, os pacotes que uso: Eu tenho isso de forma documentada. Por favor olhe o meu repositório chamado
**docsamples > generaldocs**. Você verá arquivos e pastas para .Net Core, VsCode, Angular, React Native - essas são minhas
referências e as coisas que uso pra trabalhar com essas linguagens.

Eu também uso "Imsomnia" para testar a API, mas você pode usar Postman se preferir, instalar algo integrado como Swagger.
Eu também uso "Azure Data Studio" para verificar o banco, caso precise. Nota: Eu também testei todo esse ambiente usando
Windows 10 e funcionou perfeitamente, também no VS Community 2019. Então basicamente escolha o seu predileto :trollface:

### Como rodar o BackEnd:
A conexão do SQL Server para o BackEnd fica em "BackEnd>AppFullStackDemo.Api>appsettins.json", então por favor configure sua
conexão antes de tentar rodar o app. Se sua conexão não existir nesse arquivo, o EF irá usar o Default que está no arquivo
"AppFullStackDemoContext.cs".

Depois de configurar sua conexão, na pasta principal (BackEnd) rode:
<li>dotnet restore</li>
<li>dotnet build</li>

Após entre na pasta ".Infra" e rode o comando de migration:
<li>dotnet ef --startup-project ../AppFullStackDemo.Api/ database update</li>
<br />
**Criando os dados de testes**:
Você pode iniciar sua app com alguns dados de teste como usuário, alguns fabricantes, dispositivos, e ai você pode ver como
o app funciona, logar no painel. Para fazer isso tudo rode o teste: Abra "BackEnd > AppFullStackDemo.Tests > MockDataCreator
> FakeDataCreator" e rode o teste. Importante: Você precisa rodar o migration acima e criar o banco antes.

O Criador de Dados de testes irá gerar um primeiro Login, que você pode usar no Painel para Logar:
<li>Login: admin</li>
<li>Password: admin</li>

Então, na pasta ".Api" rode o comando:
<li>dotnet run</li>

Sua Api deve iniciar. Se você ver ela rodando na porta 4001, perfeito! O BackEnd está pronto e rodando!


### How to Run the FrontEnd:
Dentro da Pasta FrontEnd rode:

<li>npm install</li>
<li>ng serve --o</li>

### How to Run the Mobile:
Dentro da Pasta Mobile vá para "src > services > api.js". Você precisa configurar seu IP (troque 192.168.1.10).
Para descobrir seu IP use "ifconfig" (linux) or "ipconfig" (windows). Nota: Eu tentei usar "localhost" com o React-Native,
mas conflitou. Então eu usei o endereço de IP local.

Você precisa criar um arquivo chamado "local.properties" dentro da pasta "android" com o caminho do seu SDK. No meu caso:
sdk.dir = /home/fernandopassaia/Android/Sdk

Dentro da Pasta Mobile rode:
<li>npm install</li>
<li>react-native run-android</li>

(Nota: Você precisará configurar seu ambiente e precisa ter um Equipamento ou Emulador rodando).

### Tutorial vídeos on Youtube:
Eu gravei alguns vídeos também mostrando como rodar esse App. Apenas vá para esse canal:
<li>https://www.youtube.com/channel/UCFzZD9snKFKZAx-FwL6SpeQ</li>

### Se você gostar desse projeto, por favor siga e nos dê uma estrela :sunglasses: :computer:

# 
### Informações adicionais:
**Nota sobre as CLAIMS**: O sistema vem com 5 claims de base: dashboard, manufacturer, devicemodel, user and 
equipment. A melhor forma de implementar seria granulado (user.list, user.create, user.edit) e o sistema precisaria de
uma tela para Editar as Claims, e uma maneira fácil de linkar o usuário a claim. Na minha opinião pessoal, o sistema
deveria ter "Perfís" (como Mestre, Admin, Usuário) e o usuário receberia suas claims baseado no seu perfil.

De qualquer forma, como descrito, esse sistema não é um exemplo de regras de negócios. Você deve melhorar ele de acordo
com suas necessidades. Então basicamente quando um usuário é criado, no "UserHandler" as claims (todas) serão dadas para
o usuário, e ele terá todos acessos. De qualquer forma, se você quiser testar o "forbidden" e o Angular Interceptor,
você pode deletar da tabela "UserClaim" (que linka Claims a Usuários). Então apenas faça logout (para deletar o token).

**Nota sobre o Template**: Eu usei um Template Pronto da Internet. Então basicamente a maioria das coisas, como html/css
vieram dele. Partes dos itens eu fiz (como modals, mensagens, alguns desings), instalei e configurei componentes. O
Template não veio com código para integrar ao backend, sem serviços, sem interceptor, autenticação, nada. Apenas um
design limpo material. Eu não sou um Designer, então tive que usar um template pronto para seguir em frente com o painel.