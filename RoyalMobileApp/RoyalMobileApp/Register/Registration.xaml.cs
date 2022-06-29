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
    
    public partial class Registration : ContentPage
    {
        public Registration()
        {
            InitializeComponent();
        }

        private async void btnRegister_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txName.Text)||string.IsNullOrEmpty(txEmail.Text)||string.IsNullOrEmpty(txPhone.Text)||string.IsNullOrEmpty(txPassword.Text)||string.IsNullOrEmpty(txCPass.Text))
                {
                    await DisplayAlert("Error", "Please fill the Required field... ", "OK");
                    return;
                }

                if (txPassword.Text != txCPass.Text)
                {
                    await DisplayAlert("Error", "Password do not Match,\n Please Enter Correct Password", "OK");
                    return;
                }

                  var c = (await App.firebaseDatabase.Child("User").OnceAsync<User>()).FirstOrDefault(x => x.Object.Email == txEmail.Text);
                  if (c != null)
                {
                      await DisplayAlert("Error", "This Email Already Exist...", "OK");
                      return;
                  }
                LoadInd.IsRunning = false;
                int LastID, NewID = 1;

                var LastRecord= (await App.firebaseDatabase.Child("User").OnceAsync<User>()).FirstOrDefault();
                if (LastRecord != null)
                {
                    LastID = (await App.firebaseDatabase.Child("User").OnceAsync<User>()).Max(a =>a.Object.UserID);
                   NewID = ++LastID;
                }
                
                User u = new User()
                {
                    UserID = NewID,
                    Name = txName.Text,
                    Phone = txPhone.Text,
                    Email = txEmail.Text,
                    Password = txPassword.Text,
                  };

               await App.firebaseDatabase.Child("User").PostAsync(u);
                LoadInd.IsRunning = false;
                
                //App.db.Insert(u);
                await DisplayAlert("Success", "Account Registered", "Ok"); 
                await Navigation.PushAsync(new Login());
               

            }
            catch (Exception erre)
            {
                LoadInd.IsRunning = false;
                await DisplayAlert("Error", "Something went wrong. Please check your internet connection. \nError: \n" + erre.Message, "OK");
              
            }
        }
    }
}