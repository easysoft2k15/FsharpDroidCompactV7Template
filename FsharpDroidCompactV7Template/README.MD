## Template for Android App with Compact V7 Theme (FSHARP)
Views are written in FSharp (no XML)

### MainActivity.fs
Setup Drawer Navigation + basic UI + Menu navigation between views

### ViewManager.fs
Load VIews: basically every type with name that start with `Easysoft.View_` is expected to be a View

### Views.fs
All Views are created here

### NOTE
Right now is just a template for not having to remember all the type package and settings necessary to setup a CompactV7 App.
I'm looking forward to implement very simple DSL + MVVM to build Android UI in code.

Any idea or contribution is welcome!
