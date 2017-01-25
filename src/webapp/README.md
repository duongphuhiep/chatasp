# Main Application

This is the main WebApp.

Here the idea:

I'll try to combine differents frontend + backend technologies, so it will be a Multi("Single-page application").

The foundation is a MVC Web application which will provide:
- API json-based services (application of API-first ideologie)
- Several dynamically generated html pages
  * Some of generated html pages are a Single-Page Applications 
 with ReactJs + Mobx go around.

The `wwwroot` folder is naturally the battle-ground for Front-end devloppement.
I started it with the [reactjs-mobx boilerplate](https://github.com/mobxjs/mobx-react-boilerplate) 

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


Thought:
I'm not sure if the project requirement is complex enough to showoff these technologies, if is not the case, I will just come up with more requirements..