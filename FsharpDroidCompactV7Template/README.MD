## Template for Android App with Compact V7 Theme (FSHARP)
Views are written in FSharp (no XML)

### ViewManager.fs
Load Views: basically every type with name that start with `Easysoft.View_` is expected to be a View

### AndroidBase.fs
Some shortcuts to easily build UI in code

### ViewModelBase.fs
ViewModel base class. Here is where the observable sequence of bindings is held and here it get subscribed

### ViewBase.fs
View base class. Here the `Bind`function is define to bind View WIdget to ViewModel properties

### ViewModel.fs
Here You define Your own View Models

### Views.fs
Here You define Your own Views

### MainActivity.fs
Setup Drawer Navigation + basic UI + Menu navigation between views

### BINDING BASE ARCHITECTURE
ViewBase has a `Bind` function that bind view model properties to Android Widget. This function is basically merging a sequence of
Observable each containing SOURCE and DESTINATION property to be bound.
This Observable is held inside ViewModelBase.
Binding is setup inside render method of each View.
MainActivity MUST call `MyFinalize()` method on each ViewModel in order to trigger the Observable subscription
All view once setup are always "live" and MainActivity is only swapping View when new menuItem is selected.
Is a very simple architecture probably usable only for small application

### NOTE
Beside my attempt to setup a very simple framework the nice effect is that this is a template for not having to remember all the type package and settings necessary to setup a CompactV7 App.
So MainActivity `OnCreate()` method is worth (to me) at least for this.


Any idea or contribution is welcome!
