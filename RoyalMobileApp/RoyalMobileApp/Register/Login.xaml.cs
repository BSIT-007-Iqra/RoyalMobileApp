using Firebase.Database.Query;
using RoyalMobileApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RoyalMobileApp.Register
{
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
        }
        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Registration());
        }

        private async void btnlogin_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txEmail.Text) || string.IsNullOrEmpty(txPassword.Text))
                {
                    await DisplayAlert("Error", "Please fill the Require field ", "OK");
                    return;
                }
                //Local Database Table Creation
                //App.db.CreateTable<User>();
                //Checking Data from local Database
                //var c = App.db.Table<User>().FirstOrDefault(x => x.Email == txEmail.Text && x.Password == txPassword.Text);
                   LoadInd.IsRunning = true;

                var c = (await App.firebaseDatabase.Child("User").OnceAsync<User>()).FirstOrDefault(x => x.Object.Email == txEmail.Text && x.Object.Password == txPassword.Text);
                 if (c == null)
                {
                    LoadInd.IsRunning = false;
                    await DisplayAlert("Error", "Email and Password Invalid", "OK");
                    return;
                }
                else
                {
                    await Navigation.PushAsync(new Userlist());
                }

                User u = new User()
                {
                    Email = txEmail.Text,
                    Password = txPassword.Text,
                };

               await App.firebaseDatabase.Child("User").PostAsync(u);
                LoadInd.IsRunning = false;
                // App.db.Insert(u);
                await DisplayAlert("Success", "Successfully Login", "Ok");


            }
            catch (Exception erre)
            {
                LoadInd.IsRunning = false;
                await DisplayAlert("Error", "Something went wrong. Please check your internet connection. \nError: " + erre.Message, "OK");

            }

        }
    }
}