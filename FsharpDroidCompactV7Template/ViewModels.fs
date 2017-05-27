namespace Easysoft

open Android.OS
open Android.Runtime
open Android.Views
open Android.Widget

open System

type View_Model1()=
    inherit ViewModelBase()
    let mutable _text1=""
    member this.Text1
        with get() = _text1
        and set(value) = 
            _text1 <- value
            this.raiseIfChanged !! <@ this.Text1 @>
   