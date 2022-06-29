using Firebase.Database.Query;
using RoyalMobileApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RoyalMobileApp.Register
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Userlist : ContentPage
    {
        public Userlist()
        {
            InitializeComponent();
           
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            
        try
            {
                LoadInd.IsRunning = true;
                LoadData();
                LoadInd.IsRunning = false;
            }
            catch (Exception erre)
            {
                LoadInd.IsRunning = false;
                await DisplayAlert("Error", "Something went wrong. Please check your internet connection. \nError: \n" + erre.Message, "OK");

            }
        }
        async void LoadData()
        {

            Datalist.ItemsSource = (await App.firebaseDatabase.Child("User").OnceAsync<User>()).Select(x => new User
             {
                UserID = x.Object.UserID,
                Name = x.Object.Name,
                Email = x.Object.Email,
                Password = x.Object.Password,
                Phone = x.Object.Phone
            }).ToList();
        }
        private async void Datalist_ItemTapped(object sender, ItemTappedEventArgs e)
        {

            var selected = e.Item as User;
            var item = (await App.firebaseDatabase.Child("User").OnceAsync<User>()).FirstOrDefault(x => x.Object.UserID == selected.UserID);
            var response =  await DisplayActionSheet("Options", "Close", "Delete", "View", "Edit");
            if (response == "View")
            {//we can use concatenate opreation to show more than one item at a time.
                await DisplayAlert("Details", "\n"+
                    "\nUserID : " + item.Object.UserID +
                     "\nUserName : " + item.Object.Name +
                     "\nUserEmail : " + item.Object.Email +   
                     "\nUserPassword : ****** " +
                     "\nUserContact : " + item.Object.Phone 
                    ,"Ok");
            }
        if (response == "Delete")
            {
                var q = await DisplayAlert("Confirmation", "Are you sure you want to delete " + item.Object.Name, "Yes", "No");
                if (q)
                {
                    await App.firebaseDatabase.Child("User").Child(item.Key).DeleteAsync();
                    LoadData();
                    await DisplayAlert("Confirmation", "You have deleted " +item.Object.Name + "Permanently...", "Ok");
                }
               
            }
        if (response == "Edit")
            {
            
            }
        }
    }
}