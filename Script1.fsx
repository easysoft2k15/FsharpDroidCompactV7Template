open System
open System.Reflection

type ViewModel()=
    let mutable _x=""
    member this.x
        with get()= _x 
        and set(value)= _x <- value

let set (viewModel: ViewModel) (f: ViewModel -> obj) value =
    let o=f viewModel
    let pi = typeof<ViewModel>.GetProperty("x")
    pi.SetValue(viewModel,value)

let doit()=
    let vm=new ViewModel()
    vm.x <- "Prima"
    printfn "%s" vm.x
    set vm (fun vm -> vm.x :> obj) ("Dopo" :> obj)
    printfn "%s" vm.x

doit()

