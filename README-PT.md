### AppFullStackDemo .NetCore 3.1 DDD/SOLID/CQRS/Api Rest
### Angular 9 Material Panel + React Native Mobile.

* Nota: Esse documento também está disponível em Inglês. Por favor veja o README.MD original.
* Nota 2: Eu também gravei alguns tutoriais em vídeo que mostram como rodar essa app. Os links abaixo.
* Nota 3: Nós publicamos esse sistema ONLINE, você pode acessar e testar. Os links abaixo.
* Nota 4: Você pode usar apenas partes desse sistema. Exemplo: Se você não é um DevMobile, apenas ignore.

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

* Rich Modeling (Models-Entities, Enums, ValueObjects) (read below for the Business Logic)
* Api REST + Handlers to Deal with the Requests + Dependency Injection
* JWT Token to Auth Parts + Claims + JSON to Data
* Handler Layer (you can also call it as "Service") to "orchestrate" the requests
* Repositories Layer + Unit of Work + 3 CRUDS (EF Code First)
* CQRS to Receive Queries and Comands and Return Results
* Validation by Contracts on Commands (Fail-Fast Validations)
* Pattern (BaseCommandResult) for the Returns of the API on a Well-defined type
* Shared Project (classlib) for Field Formaters, Validations, Cryptografy
* Mock-DataCreator to fill start-database with some test-data
* Unit-Tests for Commands, Queries, Repositories, Entities and Handlers
* Note: DataBase can be Easily replaced (to Postgres, MySQL) once layers are very well separated.

### FrontEnd Angular 9 + Material Panel + Login + Auth + 3 Full-CRUDS + Detail screen:
* Complete Panel to Login + DashBoard + 3 Entire CRUDS (read below for the Business Logic)
* Nice Interface using Angular Material, Modals, MatTable, Chartlist and more.
* CQRS Models and Interfaces based on BackEnd (Commands and Results)
* Layer for the Services and API Communication - Capable to Catch Results and Display Messages (like
  good result or list of validation-errors) coming from the backend (you'll not need to catch on each
  service or screen the messages to display to user what happens) (httpinterceptor)
* Separated Modules and Rotes Files for better Organization.
* Shared Services for Dialogs, Notification Messages, Modal Screens, Enum Description.
* Auth Guard / Auth Interceptor to Deal Perfectly with the Tokens, Authentication, Headers (401/403).

### Mobile React-Native + Device-Info:
Login Screen that Will Communicate with the BackEnd for Auth and Store the JWT. Once Logged, MobileApp will
allow user to add this device to the account with the Details of the Device (Imei, PhoneNumber, Serial,
manufacturer, model). Once Registered, Device and it's info will appears on the Panel > User > Equipment list.

# 
### License and USE of this App in a RealWorld Scenario:
Note: This App is FREE and FULL OpenSource. You can Use it as a base for your system, or you can also colaborate with me
to improve it. In a REAL-WORLD, this App needs to be better planned:

Users should belong to a Company (or even better - User should belong to a Real-Entity like Employee or something),
Claims should have Profiles (like Master, Admin...) where the Claims will be connected (not right to the user). We also
need a screen to manage the CRUD of the Claims (that we don't have on this app). Create category for the Devices:

We also need to implement things like RefreshToken Logic, WelcomeEmail, Recover Password, Change PassWord Screen and go
on and on - lot of other things to use this app in a Real-scenario. We need to adapt lot of things to a REAL-WORLD
Scenario of Real-Business needs Logic.

But for now: Remember that this app is a "demo" of Programming, Architecture and Techinical Skills - NOT a demo of
Real-World App. So we will keep the business-stuff simple to Focus on Technical stuff. Anyway, you can use it as a base
of a Architecture, and start your own system under it, following the patterns already implemented on it. You can use it
as a "skeleton" for your next Real-Software. Good luck :cake:

# 
### How to RUN it and Technical Information:
You can Develop and Run it on Windows, Linux and MacOs. In My Machine: I've Used Linux Ubuntu 20.04 and VS Code :)

If you want to know how do i configure my Linux Envoirnment: VSCode, extensions, the fonts i use, the system variables
of my envoirnment and how to i configure then, the packages i use: I have it in a documented way. Please take a look
to my repo called **docsamples > generaldocs**. You'll see files and folders for .Net Core, VsCode, Angular, React 
Native - this are my references and the things i use to work in these languages.

I also use "Insomnia" to TEST API, but you can use Postman or if you prefer, install some integrated tool like Swagger.
I also use "Azure Data Studio" to check the DataBase in case of need. Note: I've also tested all this APP and Envoirment
using Windows 10 and it also works perfect, also in VS Community 2019. Basically chooose your favorite :trollface:

### How to Run the BackEnd:
SQLServer Connection string for the BackEnd is on "BackEnd>AppFullStackDemo.Api>appsettins.json", so please set-up your
SQL Connection Server info before try to RUN the APP. If the connectionstring does not exists on this file, EF will use
the Default string on "AppFullStackDemoContext.cs".

After setup your connectionstring, enter on ".Infra" folder and RUN the migration command:
<li>dotnet ef --startup-project ../AppFullStackDemo.Api/ database update</li>
<br />
**Creating FakeMockData**:
You can start your app with some FakeMockData like a User, some Manufacturers, Devices, then you can see how it works,
login into panel. To do it you just need to run a TEST: Open the "BackEnd > AppFullStackDemo.Tests > MockDataCreator > 
FakeDataCreator" and run the test. IMPORTANT: You have to run the migration and create the DB first.

The MockDataCreator will generate the First LOGIN, that you can use on Panel/Mobile to Login. Then login with:
<li>Login: admin</li>
<li>Password: admin</li>

Then, on the ".Api" folder run the command: 
<li>dotnet run</li>

The Api should start. If you see it running on PORT 4001, well done. BackEnd is ready to go.


### How to Run the FrontEnd:
Inside FrontEnd folder go to "src > app > app.api.ts". You'll need to setup your IP connection (replace 192.168.1.10).
To discover your IP use "ifconfig" (linux) or "ipconfig" (windows). Then inside FrontEnd folder:

<li>ng serve --o</li>

### How to Run the Mobile:
Inside Mobile folder go to "src > services > api.js". You'll need to setup your IP connection (replace 192.168.1.10).
To discover your IP use "ifconfig" (linux) or "ipconfig" (windows). Then inside Mobile folder:

<li>react-native run-android</li>

(note: you'll need to setup your envoirnment and have a Device or Emulator running)

### Tutorial vídeos on Youtube:
I've recorded some videos also showing you how to Configure your Envoirnment and Run this App. Just go to these channel:
<li>https://www.youtube.com/channel/UCFzZD9snKFKZAx-FwL6SpeQ</li>

# 
### Published ONLINE System - if you just want to see it as a user, not a developer:
If you just want to **TEST** this system as a USER, without setting (or having) an envoirnment, we've published it
**ONLINE**. This system is published and ONLINE for test with the same user account below. You can test the Panel,
create an account for you, and also there's an APK that you can download, install on your device or an emulator, login
and see it working. Feel free at:

<li>www.futuradata.com.br/appfullstackdemo/panel (Angular Panel - Login/Pass: admin > admin)</li>
<li>www.futuradata.com.br/appfullstackdemo.apk (you can download an run on your device, same login)</li>
<li>www.futuradata.com.br/appfullstackdemo/backend (you can use Insomnia to test the API)</li>

# 
### Additional Info:
**Note about the CLAIMS**: System comes with a Claim Table and have 5 base claims: dashboard, manufacturer, devicemodel,
user and equipment. The "better" way to implement it should be granulated (user.list, user.create, user.edit) and
the system needs a Screen to Edit the Claims, and a way to "link" the User to the Claims. In my personal opinion
system should have "Profiles" (like Master, Admin, Users...) and user will receive claims based on a Profile.

Anyway, as we describe, this system is not a Sample of Business rules. You should improve it according to your needs.
So basically when a User is created, on the "UserHandler" the claims (all of them) will be gave to the User, and it
will have all accesses. Anyway, if you want to test a "forbidden" and Angular Interceptor, you can delete it from
"UserClaim" table (that links Claims to the Users). Than just logout (to delete token) and go on...

**Note about the Template**: I've used a Ready-Template from internet. So basically most of the things, html/css code
comes from it. Part of items i've done (like modals, messages, some designs), installed and configured components.
The Template comes with no code to integrate to backend, no services, no interceptor, auth, nothing at all. Just
clean Design-Material template. I'm not a Designer, so i have to use a ready-to-go template to go-ahead with Panel.

# 
### TO-DO:
### Docker-Compose and integrated Envoirnment:
Note: Need to be done on Future. Once i don't know (even if it's possible) to encapsulate inside a Containner the
"React Native" (Mobile) part. Once app needs to Run on Machine (to access the Device and install the APK), i don't
know how to make it runs inside a docker and make it automatically. Maybe it's possible to run "npm start" and 
"react-native run-android" inside the docker containner and install on local mobile. Well, to be checked/done...
### Lint: Need to pass the code by Linting and fix the inconsistences.