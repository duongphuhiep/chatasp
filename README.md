# An [ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/) project template

This is a boilerplate project template for [VSCode](https://code.visualstudio.com/).
It is target for Linux users who would want to develop ASP.NET application.

In real project, you often split code to several projects and make them reference each other. So this solution include 3 projects:

- a webapp (asp.net mvc)
- a library (dal)
- a unit test on the library (dal.tests)

We don't have to put everything inside one MVC project (unlike many other MVC framework). You can create as many projects / tests as you like in the `src` or `test` folder; then you can reference to them by adding dependencies to `project.json`. Exemple:
```
"dependencies": {    
    "dal": { "target": "project" }
}
```
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

# Final note

**01/2017**
* I didn't expect everything (Debugger, Refactoring..) work so well at this early state. Dotnet core eco-system is growing, it is changing fast. This boilerplate will soon become obsolete.
* But evens in this current state, I think that developping MVC with C# and VSCode, ASP.Net Core is way more enjoyable than many other popular MVC framework out there. 
* I think that it is safe to learn and to start new projects in MVC Core now. The Eco-System is changing fast but the technology is mature, you might have to migrate the project format / structure, upgrade the tooling, but not your Codes.