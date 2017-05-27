namespace Easysoft

open Android.App
open Android.Content
open Android.OS
open Android.Runtime
open Android.Views
open Android.Widget
open System

open Com.Google.Android.Flexbox

[<AutoOpen>]
module AndroidBase=
    ///
    ///LinearLayout
    ///
    type LL_PARS=LinearLayout.LayoutParams
    let LL_PARS_MP=LinearLayout.LayoutParams.MatchParent
    let LL_PARS_WC=LinearLayout.LayoutParams.WrapContent
    let LL_VERT= Orientation.Vertical
    let LL_HORIZ= Orientation.Horizontal

    ///
    ///FlexboxLayout
    ///
    let FB_DIR_ROW=FlexboxLayout.FlexDirectionRow
    let FB_DIR_COL=FlexboxLayout.FlexDirectionColumn
    let FB_WRAP=FlexboxLayout.FlexWrapWrap
    let FB_NOWRAP=FlexboxLayout.FlexWrapNowrap
    
    let (>=>)  (vg: ViewGroup) (v: View) =
        vg.AddView(v)
        vg

    let LL ctx (width: int)  (height: int) orientation=
        let ll=new LinearLayout(ctx)
        ll.LayoutParameters <- new LinearLayout.LayoutParams(width,height)
        ll.Orientation <- orientation
        ll
        
    let FB ctx (width: int)  (height: int)  dir=
        let fb=new FlexboxLayout(ctx)
        fb.LayoutParameters <- new FlexboxLayout.LayoutParams(width,height)
        fb.FlexDirection <- dir
        fb

    let V<'a> ctx  (width: int)  (height: int)=
        let obj=Activator.CreateInstance(typeof<'a>,ctx :> obj) :?> View
        obj.LayoutParameters <- new LinearLayout.LayoutParams(width,height)
        obj



