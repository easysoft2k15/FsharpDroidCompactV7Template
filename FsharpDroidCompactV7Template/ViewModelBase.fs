namespace Easysoft


open Android.OS
open Android.Runtime
open Android.Views
open Android.Widget

open System
open System.Reactive
open System.Reactive.Linq
open System.Reactive.Subjects
open System.Reflection

type ObservableSource= {Src: obj ;  SrcPropInfo: PropertyInfo ; Dst: obj ; DstPropInfo: PropertyInfo}

type ViewModelBase()=
    let _observableLocalProps = new Subject<ObservableSource>()
    let mutable _observableGlobalProps =Observable.Empty<ObservableSource>()
    let mutable _dispose: IDisposable =null
    member this.ObservableLocalProps
        with get()= _observableLocalProps
    member this.ObservableGlobalProps
        with get()= _observableGlobalProps
        and set(value) = _observableGlobalProps <- value
    member this.raiseIfChanged (propInfo: PropertyInfo)=
        _observableLocalProps.OnNext({Src=this ; SrcPropInfo=propInfo ; Dst=null ; DstPropInfo= null})
    member this.MyFinalize()=
        _dispose <-this.ObservableGlobalProps.Subscribe( 
            fun os -> 
                        let newValue=os.SrcPropInfo.GetValue(os.Src)
                        let oldValue=os.DstPropInfo.GetValue(os.Dst)
                        Console.WriteLine(sprintf "Prop Change - Src=%s - Dst=%s - Value=%s" (os.Src.ToString()) (os.Dst.ToString()) (newValue.ToString()) )
                        if newValue <> oldValue then
                            os.DstPropInfo.SetValue(os.Dst,newValue) )
    

