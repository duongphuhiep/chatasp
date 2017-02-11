# Main Application

This is the main WebApp.

Here the idea:

I'll try to combine differents frontend + backend technologies, so it will be a Multi("Single-page application").

The foundation is a MVC Web application which will provide:
- API json-based services (application of API-first ideologie)
- Several dynamically generated html pages, which is the entry point for the front-end application 
 * The generated html are really simple, they are quasi-static html 
 * vuejs will make its rich and dynamic

The `wwwroot` folder is naturally the battle-ground for Front-end devloppement.
I started it with the basic vuejs + webpack application

Download dependencies:
```
bower install
npm install
```

Create `dist/bundle.js`
```
webpack
```
or
```
webpack --watch
```
