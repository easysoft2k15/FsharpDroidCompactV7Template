namespace Easysoft

open Android.OS
open Android.Runtime
open Android.Views
open Android.Widget

open System
open Com.Google.Android.Flexbox

type View_Home (ctx , vm: View_Model1)=
    inherit ViewBase()
    override this.Render()=
        let ll=LL ctx LL_PARS_MP LL_PARS_MP LL_VERT

        let tv1=V<TextView> ctx  LL_PARS_MP LL_PARS_WC :?> TextView
        tv1.Text <- "This is a test"
    
        let bt1=V<Button> ctx LL_PARS_MP LL_PARS_WC :?> Button
        bt1.Text <- "Make Uppercase"
        bt1.Click.Add(fun e -> tv1.Text <- tv1.Text.ToUpper())

        ll >=> tv1 >=> bt1

type View_View1(ctx  , vm: View_Model1)=
    inherit ViewBase()
    override  this.Render()=
        let fl=FB ctx  LL_PARS_MP LL_PARS_MP FB_DIR_ROW 
        fl.FlexWrap <- FB_WRAP
        fl.JustifyContent <- FlexboxLayout.JustifyContentSpaceAround

        let tv1=V<TextView> ctx  LL_PARS_WC LL_PARS_WC :?> TextView
        tv1.Text <- "This is a test"

        this.Bind vm <@ vm.Text1 @> tv1 <@ tv1.Text @> tv1.TextChanged None None

        let tv2=V<TextView> ctx  LL_PARS_WC LL_PARS_WC :?> TextView
        tv2.Text <- "This is a test 2"
    
        let bt1=V<Button> ctx LL_PARS_WC LL_PARS_WC :?> Button
        bt1.Text <- "Make Uppercase"
        bt1.Click.Add(fun e -> tv1.Text <- tv1.Text.ToUpper())
    
        fl >=> tv1 >=> tv2 >=> bt1
        
    
type View_View2(ctx , vm: View_Model1)=
    inherit ViewBase()
    override  this.Render()=
        let ll1=LL ctx LL_PARS_MP LL_PARS_MP LL_VERT

        let te1=V<EditText> ctx LL_PARS_MP LL_PARS_WC :?> EditText
        te1.Text <- "type here..."
        this.Bind vm <@ vm.Text1 @> te1 <@ te1.Text @> te1.TextChanged None None
        
        let bt1=V<Button> ctx LL_PARS_MP LL_PARS_WC :?> Button
        bt1.Text <- "My Button"
        bt1.Click.Add (fun e -> te1.Text <- te1.Text.ToUpper() )

        ll1 >=> te1 >=> bt1





