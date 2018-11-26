using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System.IO;

namespace DatabaseExample
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            var listView = FindViewById<ListView>(Resource.Id.listView1);


            var databaseService = new DatabaseService();
            databaseService.CreateDatabase();
            databaseService.CreateTableWithData();
            var table = databaseService.GetAllStocks();
            
            listView.Adapter = new CustomAdapter(this, table.ToList());

            foreach(var s in table)
            {
                System.Diagnostics.Debug.WriteLine(s.Id + " " + s.Symbol);
            }
        }
    }
}