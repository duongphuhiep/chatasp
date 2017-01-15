# [ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/) and [Couchbase](https://www.couchbase.com/nosql-databases/couchbase-server) self-learning

I will try to make application with
* [ASP.NET MVC](https://docs.microsoft.com/en-us/aspnet/core/) 
* [Couchbase](https://www.couchbase.com/nosql-databases/couchbase-server)
* ReactJs, Mobx, WebSocket
* I'm a "Windows" guy but all developement will go entirely under Linux.

My objectif is to try, to train and to fail.. so
* It will take long time
* **I might not complet this application until a finised product.**
* I might try odd architectural decision.

# The project

A TODO app is too trivial, so It will be a **Simple Chat application**. With some basic features
* Register User
* Login
* Make a conversation with other user

# Run the webapp
```
cd src/webapp
dotnet run
```
or Watch and run so that the server is compiled 
```
dotnet watch run
```

# How to Debug in VSCode

Attach Debugger to the process `dotnet exec ... webapp.dll` in the list.

> Tip: in the process list, filter the name of the application dll (`webapp.dll` in this case).

You can also Run/Debug the WebApp directly from VSCode (F5)