# app_fullstackdemo .NetCore + Angular + React Native.
* Note: This Documentation is also available in Portuguese. Scrool down for it.
* Nota: Essa documentação está também disponível em Português, role pra baixo para acessar.

# This is my Demo of a FullStack App using:
.NET Core BackEnd (With Rich Arquitecture) DDD/SOLID/CQRS + WebApi.
Web-Panel using Angular 8.2 Version with Material with Rich Arquitecture.
Mobile App using React-Native.

# More Details about this Architecture you can find going on this doc...
------------------------------------------------------------------------------------------------------------

## Business Logic:

How it works: WebPanel (Angular) and MobileApp (React) will have a Login-Screen, that will communicate with
the backend, to login and Store the Token (JWT) with the Claims. Once Logged:

MobileApp can "register" the Device on backend, registering the Manufacturer (Motorola, LG, Samsung, Xiaomi),
Model (S7, S8, S9, RedMi9, RedMi10), IMEI number and some other information. MobileApp will have a cool screen
to show some important informations from Device - once registered, will store the ID taken from backend. You
could use your Real Device or also an Emulator (like Android Studio or Genymotion) to test it. Once it's React
Native, you can also work to compile it to iOS and iPhone.

FrontEnd will also Login and get the Token (JWT with Claims). On Panel you will have a DashBoard (showing 
graphics with Number of Devices per AndroidVersion, and Number of Devices per Manufacturer). Users logged on
Panel will be allowed to create Another Users that can also Login into Panel and MobileApp. So the Users
Screen will comes with a "CRUD" function to List, Create, Edit and Delete Users.

On UserScreen (List) will be a button to LIST all the Devices for that user. So when you Login in a Mobile
Device, so once user Login in MobileApp and Register the Device, it will be available with Details on Panel.
Angular Panel is also ready to work with the Token, with a Interceptor Layer to Deal with 401/403 codes,
show good messages, alerts, ballon messages, modals and a lot of cool things with a nice Material-Interface.

BackEnd will manage Automatically the Manufacturers > Models of devices. So new Manufacturers and new models
will be generate by the BackEnd, attaching the Device to the Right "relationship". So basically: A Device will
belong to a Model, and a Model will belong to a Manufacturer. One Manufacturer has N Models, One Model has
N devices. This relationships will be generated on Entities, and also, replicated by EF on Database.

The Screen on Panel to Manage (CRUD) this Manufacturers > Models will also be Available. So we have at least
3 Cruds: Users, Manufacturers and Models. A Screen for Devices (List and Details) is also available.

Under the hood : The BackEnd .NET Core will be running providing all this data for both apps.

:+1: (Note: Add some PrintScreens of App Here) :shipit:


Note: This App is FREE. You can Use it as a base for your system, or you can also colaborate with me to
improve it. In a REAL-WORLD, this App needs to be bigger: Users should belong to a Company, should have
levels (where we will connect the claims), one "low-level" user cannot update data from others. The Main
point here is to Show Programming, Architecture and Techinical stuff. In a Real-World, this app nees better
logic-business studies, and for sure a better need for development.

------------------------------------------------------------------------------------------------------------

## BackEnd:

### .NET Core 2.2 C# + EF Core (SQLServer). Rich Architecture DDD/SOLID using:

Rich Modeling (Models-Entities, Enums, ValueObjects) (read below for the Business Logic)

Api REST + Handlers to Deal with the Requests + DI

JWT Token to Auth Parts + JSON to Data

CQRS to Receive Queries and Comands and Return Results

Repositories Layer + Unit of Work + 2 CRUDS (EF Code First)

Validation by Contracts.

* Note: DataBase can be Easily replaced (to Postgres, MySQL) once layers are very well separated.

## FrontEnd:

### Angular 8 + Angular Material Panel + Login + Auth + 2 Full-CRUDS:

Complete Panel to Login + DashBoard + 2 Entire CRUDS (read below for the Business Logic)

CQRS Models and Interfaces based on BackEnd (Queries, Commands and Results)

Layer for the Services and API Communication

Separated Modules and Rotes Files for better Organization

Shared Services for Dialogs, Notification Messages, Modal Screens, Enum Description.

Auth Guard / Auth Interceptor to Deal Perfectly with the Tokens, Authentication, Headers (401/403)

## Mobile:

### React-Native + Device-Info:

Login Screen that Will Communicate with the BackEnd for Auth and Store the JWT.

DashBoard to Show the Device Basic Information about the Device (Brand, Model, Android Version, Device Id):
DashBoard will also add the Device to the BackEnd, so the Panel will display a List of Devices per Users.

------------------------------------------------------------------------------------------------------------

## How to RUN it and Technical Information:

- You can Develop and Run it on Windows, Linux and MacOs.
In My Machine:

- We recommend you to use Visual Studio Code. If you want to use my VSCode preferences like fonts, colors,
icons, plugins you can look on my Repository: "Docsamples > General Docs > VsCode".
- On Windows you can also use Visual Studio Community 2019.

Youtube Vídeo: