using RoyalMobileApp.Services;
using RoyalMobileApp.Register;
using RoyalMobileApp.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;

using SQLite;
using Firebase.Storage;
using Firebase.Database;

namespace RoyalMobileApp
{
    public partial class App : Application
    {
        public static string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "dbRoyalLuxuryHotel.db3");
        public static SQLiteConnection db = new SQLiteConnection(dbPath);

        //Firebase Connections ======================================
         public static FirebaseStorage FirebaseStorage = new FirebaseStorage("gs://royalmobileapp-9dd3a.appspot.com");

        public static FirebaseClient firebaseDatabase = new FirebaseClient("https://royalmobileapp-9dd3a-default-rtdb.firebaseio.com/");
                      
        public App()
        {
            InitializeComponent();
           
           
            MainPage =new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
