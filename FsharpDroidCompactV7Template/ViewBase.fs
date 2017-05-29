namespace Easysoft

open System
open System.Reactive
open System.Reactive.Linq
open System.Reactive.Subjects
open Microsoft.FSharp.Quotations.Patterns
open Microsoft.FSharp.Quotations

open Android.Views

[<AbstractClass>]
type ViewBase()=
    abstract member Render: unit -> ViewGroup
    member this.Bind<'TEventArg> (viewModel: ViewModelBase) (viewModelProp: Expr) (viewItem: View) (viewItemProp: Expr) 
        (viewObservable: IObservable<'TEventArg>) (transformViewToModel: (unit -> unit) Option ) (transformModelToView: (unit -> unit) Option )=
        let obsView=viewObservable
                        .Select(fun o ->  {Src=viewItem ; SrcPropInfo= !! viewItemProp; Dst=viewModel ; DstPropInfo= !! viewModelProp ; Transform=transformViewToModel} )
        let obsModel=viewModel.ObservableLocalProps
                        .Where(fun os -> os.SrcPropInfo.Name =  (!! viewModelProp).Name)
                        .Select(fun os -> {os with Dst = viewItem ; DstPropInfo = !! viewItemProp ; Transform=transformModelToView})
        viewModel.ObservableGlobalProps <- viewModel.ObservableGlobalProps 
                                            |> Observable.merge obsView
                                            |> Observable.merge obsModel

