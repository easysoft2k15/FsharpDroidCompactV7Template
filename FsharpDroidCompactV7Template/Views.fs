namespace Easysoft

open Android.OS
open Android.Runtime
open Android.Views
open Android.Widget

open System

type View_Home(ctx)=
    member this.Render()=
        let layoutPars=new LinearLayout.LayoutParams(LinearLayout.LayoutParams.MatchParent,LinearLayout.LayoutParams.MatchParent)
        let ll=new LinearLayout(ctx)
        ll.LayoutParameters <- layoutPars
        ll.Orientation <- Orientation.Vertical

        let viewPars= new LinearLayout.LayoutParams(LinearLayout.LayoutParams.MatchParent,LinearLayout.LayoutParams.WrapContent)
        let tv=new TextView(ctx)
        tv.Text <- "View Home"
        tv.LayoutParameters <- viewPars
        let bt=new Button(ctx)
        bt.Text <- "Make uppercase - BY VIEW HOME"
        bt.LayoutParameters <- viewPars
        bt.Click.Add(fun e -> tv.Text <- tv.Text.ToUpper())

        ll.AddView(tv)
        ll.AddView(bt)
        ll

type View_View1(ctx)=
    member this.Render()=
        let layoutPars=new LinearLayout.LayoutParams(LinearLayout.LayoutParams.MatchParent,LinearLayout.LayoutParams.MatchParent)
        let ll=new LinearLayout(ctx)
        ll.LayoutParameters <- layoutPars
        ll.Orientation <- Orientation.Vertical

        let viewPars= new LinearLayout.LayoutParams(LinearLayout.LayoutParams.MatchParent,LinearLayout.LayoutParams.WrapContent)
        let tv=new TextView(ctx)
        tv.Text <- "View 1"
        tv.LayoutParameters <- viewPars
        let bt=new Button(ctx)
        bt.Text <- "Make uppercase - BY VIEW1"
        bt.LayoutParameters <- viewPars
        bt.Click.Add(fun e -> tv.Text <- tv.Text.ToUpper())

        ll.AddView(tv)
        ll.AddView(bt)
        ll
    
type View_View2(ctx)=
    member this.Render()=
        let layoutPars=new LinearLayout.LayoutParams(LinearLayout.LayoutParams.MatchParent,LinearLayout.LayoutParams.MatchParent)
        let ll=new LinearLayout(ctx)
        ll.LayoutParameters <- layoutPars
        ll.Orientation <- Orientation.Vertical

        let viewPars= new LinearLayout.LayoutParams(LinearLayout.LayoutParams.MatchParent,LinearLayout.LayoutParams.WrapContent)
        let tv=new TextView(ctx)
        tv.Text <- "View 2"
        tv.LayoutParameters <- viewPars
        let bt=new Button(ctx)
        bt.Text <- "Make uppercase - BY VIEW2"
        bt.LayoutParameters <- viewPars
        bt.Click.Add(fun e -> tv.Text <- tv.Text.ToUpper())

        ll.AddView(tv)
        ll.AddView(bt)
        ll



