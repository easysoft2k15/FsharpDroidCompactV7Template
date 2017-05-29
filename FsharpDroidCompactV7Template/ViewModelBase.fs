namespace Easysoft


open Android.OS
open Android.Runtime
open Android.Views
open Android.Widget

open System
open System.Linq
open System.Reactive
open System.Reactive.Linq
open System.Reactive.Subjects
open System.Reflection

type ObservableSource= {Src: obj ;  SrcPropInfo: PropertyInfo ; Dst: obj ; DstPropInfo: PropertyInfo ; Transform: (unit -> unit) Option}

type BaseViewModelProp()=
    inherit System.Attribute()

type ViewModelBase()=
    let _observableLocalProps = new Subject<ObservableSource>()
    let mutable _observableGlobalProps =Observable.Empty<ObservableSource>()
    let mutable _dispose: IDisposable =null
    [<BaseViewModelProp>]
    member this.ObservableLocalProps
        with get()= _observableLocalProps
    [<BaseViewModelProp>]
    member this.ObservableGlobalProps
        with get()= _observableGlobalProps
        and set(value) = _observableGlobalProps <- value
    member this.raiseIfChanged (propInfo: PropertyInfo)=
        _observableLocalProps.OnNext({Src=this ; SrcPropInfo=propInfo ; Dst=null ; DstPropInfo= null ; Transform = None})
    member this.MyFinalize<'TViewModel>()=
        //Subscribe observable chain
        _dispose <-this.ObservableGlobalProps.Subscribe( 
            fun os -> 
                        match os.Transform with 
                        | None ->
                            let newValue=os.SrcPropInfo.GetValue(os.Src)
                            let oldValue=os.DstPropInfo.GetValue(os.Dst)
                            Console.WriteLine(sprintf "Prop Change - Src=%s - Dst=%s - Value=%s" (os.Src.ToString()) (os.Dst.ToString()) (newValue.ToString()) )
                            if newValue <> oldValue then
                                os.DstPropInfo.SetValue(os.Dst,newValue) 
                        | Some f -> f()
                                                       )
        //Make sure everybody get updated on actual value
        typeof<'TViewModel>.GetProperties()
        |> Array.filter( fun pi -> not (pi.GetCustomAttributes<BaseViewModelProp>().Any()))
        |> Array.iter(fun pi -> pi.SetValue(this,pi.GetValue(this) ) )
    member this.Dispose()=
        _dispose.Dispose()
    

