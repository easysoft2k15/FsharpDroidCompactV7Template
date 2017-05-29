namespace Easysoft

open System

open Android.App
open Android.Content
open Android.OS
open Android.Runtime
open Android.Views
open Android.Widget
open Android.Support.V7.App
open Android.Support.V7.Widget
open Android.Support.V4.Widget
open Android.Support.Design.Widget

open Newtonsoft.Json

[<Activity (Label = "FSharpDroidCompactV7", MainLauncher = true, Icon = "@mipmap/icon")>]
type MainActivity () =
    inherit AppCompatActivity ()

    let mutable drawerLayout:DrawerLayout = null
    let mutable mainContainer:  FrameLayout=null


    let mutable vm1: View_Model1 = new View_Model1()

    let replaceView view (container: FrameLayout)=
        container.RemoveAllViews()
        container.AddView(view)

    member this.ShowView<'a>()=
        ViewManager.GetView<'a>()
        |> Option.bind (fun v ->
            replaceView v mainContainer
            None) |> ignore
        ()

    override this.OnCreate (bundle) =
        base.OnCreate (bundle)

        //Restore previous data
        if bundle <> null then
            vm1 <- JsonConvert.DeserializeObject<View_Model1>(bundle.GetString("vm1"))

        // Set our view from the "main" layout resource
        this.SetContentView (Resource_Layout.Main)

        ///Setup V7 stuff
        ///----------------------------------------------------------
        let toolbar=this.FindViewById<Toolbar>(Resource_Id.toolbar)
        this.SetSupportActionBar(toolbar)

        this.SupportActionBar.SetHomeAsUpIndicator(Resource_Drawable.ic_menu)
        this.SupportActionBar.SetDisplayHomeAsUpEnabled(true)

        drawerLayout <- this.FindViewById<DrawerLayout>(Resource_Id.drawer_layout)

        ///Navigation drawer menu
        let navigationView=this.FindViewById<NavigationView>(Resource_Id.nav_view)
        navigationView.NavigationItemSelected.Add(
            fun e ->
                match e with 
                | e when e.MenuItem.ItemId = Resource_Id.nav_home -> this.ShowView<View_Home>()
                | e when e.MenuItem.ItemId = Resource_Id.nav_view1 ->this.ShowView<View_View1>()
                | e when e.MenuItem.ItemId = Resource_Id.nav_view2 ->this.ShowView<View_View2>()
                | _ -> ()

                let rec uncheck (menu: IMenu)=
                    {0.. menu.Size()-1}
                    |> Seq.map(fun i ->
                        let item=menu.GetItem(i)
                        item.SetChecked(false))
                    |> Seq.iter(fun mi -> 
                        if mi.HasSubMenu then
                            uncheck mi.SubMenu )
                        
                uncheck (navigationView.Menu)
                e.MenuItem.SetChecked(true) |> ignore
                drawerLayout.CloseDrawers()
                )

        //Floating action button
        let fab=this.FindViewById<FloatingActionButton>(Resource_Id.fab)
        fab.Click.Add(fun e -> 
                Snackbar.Make(fab,"Snack bar test",Snackbar.LengthLong).Show())

        ///Setup my stuff
        ///----------------------------------------------------------
        mainContainer <- this.FindViewById<FrameLayout>(Resource_Id.main_layout)
        ViewManager.LoadView<View_Home> this vm1
        ViewManager.LoadView<View_View1> this vm1
        ViewManager.LoadView<View_View2> this vm1
        vm1.MyFinalize<View_Model1>()

        //Show first view
        this.ShowView<View_View1>()

        Console.WriteLine("---------------------------------------ACTIVITY CREATED!!!!!!!!!!!!!")
        ()

    override this.OnDestroy()=
        base.OnDestroy()
        Console.WriteLine("ACTIVITY DESTROYED!!!!!!!!!!!!!")
        vm1.Dispose()

    override this.OnSaveInstanceState(bundle)=
        bundle.PutString("vm1",JsonConvert.SerializeObject(vm1))

    override this.OnCreateOptionsMenu(menu)=
        this.MenuInflater.Inflate(Resource_Menu.menu_toolbar,menu)
        true
        
    ///Open drawer
    override this.OnOptionsItemSelected(item)=
        match item.ItemId with
        | id when id = Android.Resource.Id.Home -> 
            drawerLayout.OpenDrawer(Android.Support.V4.View.GravityCompat.Start)
        | _ ->  Console.WriteLine("Menu Unknow")
        base.OnOptionsItemSelected(item)

    
