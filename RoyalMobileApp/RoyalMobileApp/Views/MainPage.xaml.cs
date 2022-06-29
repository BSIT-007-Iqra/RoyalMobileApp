using RoyalMobileApp.Register;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace RoyalMobileApp.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            Task.Run(RotateImage);
        }
        private async void RotateImage()
        {
            try
            {
         while (true)
            {
                await BannerImg.RelRotateTo(360, 10000, Easing.Linear);
            }
        
        }
            catch (Exception erre)
            {
                await DisplayAlert("Error", "Something went wrong. Please check your internet connection. \nError: " + erre.Message, "OK");

            }

        }
        private void getstarted_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage(new Login());
        }
    }
}