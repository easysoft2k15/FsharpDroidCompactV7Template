namespace Easysoft 

#if INTERACTIVE
#r @"C:\Users\alessandro\GITHUB\FsharpDroidCompactV7Template\packages\FSharp.Data.2.3.3\lib\portable-net45+netcore45\Fsharp.data.dll"
#endif

open System
open System.Reflection
open System.Net.Http
open Newtonsoft.Json
open System.Net
open System.IO
open Android.Widget
open Android.Views
open System.Threading
open System.Threading.Tasks
open WebSocketSharp

type ViewsAssembly={namefile: string ; timestamp: DateTime ; content: string}
      
module ViewManager=
    let mutable private _views: Map<string,ViewGroup> = Map.empty

    //let LoadView ctx=
    //    try
    //        Assembly.GetExecutingAssembly().GetTypes()
    //        |>Array.filter( fun t -> t.ToString().StartsWith("Easysoft.View_"))
    //        |> Array.iter (fun t ->
    //            let obj=Activator.CreateInstance(t,ctx :> obj)
    //            let m=t.GetMethod("Render")
    //            let r=m.Invoke(obj,[||]) 
    //            let v=r :?> ViewGroup
    //            _views <- _views.Add(t.ToString(),v)
    //            () )
    //    with 
    //        | ex -> Console.WriteLine("ERRORE: "+ex.Message)

    let LoadView<'TView> ctx viewModel=
        try   
            let obj=Activator.CreateInstance(typeof<'TView>,ctx :> obj, viewModel :> obj)

            typeof<'TView>.GetMethods() |> Array.iter( fun m -> Console.WriteLine("Method="+ m.Name))

            let m=typeof<'TView>.GetMethod("Render")
            let r=m.Invoke(obj,[||]) 
            let v=r :?> ViewGroup
            _views <- _views.Add(typeof<'TView>.ToString(),v)
        with 
            | ex -> Console.WriteLine("ERRORE: "+ex.Message)

    let GetView<'a>()=
        let a=typeof<'a>.ToString()
        Map.tryFind (typeof<'a>.ToString()) _views