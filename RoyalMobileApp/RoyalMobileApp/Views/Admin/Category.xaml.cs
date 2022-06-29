
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RoyalMobileApp.Views.Admin
{
    public partial class Category : ContentPage
    { 
        public static string PicPath = "Image_pick.png";
        

        public Category()
        {
            InitializeComponent();
        }

       
        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            try
            {
                var response = await DisplayActionSheet("Select Image Source", "Close", "", "From Gallery", "From Camera");
                if (response == "From Camera")
                {
                    await CrossMedia.Current.Initialize();
                    if (!CrossMedia.Current.IsTakePhotoSupported)
                    {
                        await DisplayAlert("Error", "Phone is not Take Photo Supported", "OK");
                        return;
                    }

                    var mediaOptions = new StoreCameraMediaOptions()
                    {
                        PhotoSize = PhotoSize.Medium
                    };

                    var SelectedImg = await CrossMedia.Current.TakePhotoAsync(mediaOptions);

                    if (SelectedImg == null)
                    {
                        await DisplayAlert("Error", "Error Picking Image...", "OK");
                        return;
                    }

                    PicPath = SelectedImg.Path;
                    PreviewPic.Source = SelectedImg.Path;


                }
                if (response == "From Gallery")
                {
                    await CrossMedia.Current.Initialize();
                    if (!CrossMedia.Current.IsPickPhotoSupported)
                    {
                        await DisplayAlert("Error", "Phone is not Pick Photo Supported", "OK");
                        return;
                    }

                    var mediaOptions = new PickMediaOptions()
                    {
                        PhotoSize = PhotoSize.Medium
                    };

                    var SelectedImg = await CrossMedia.Current.PickPhotoAsync(mediaOptions);

                    if (SelectedImg == null)
                    {
                        await DisplayAlert("Error", "Error Picking Image...", "OK");
                        return;
                    }

                    PicPath = SelectedImg.Path;
                    PreviewPic.Source = SelectedImg.Path;


                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Message", "Something Went wrong \n" + ex.Message, "OK");

            }
        } 
        private async void btncat_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txName.Text) || string.IsNullOrEmpty(txDetails.Text))
                {
                    await DisplayAlert("Error", "Please fill the Require field ", "OK");
                    return;
                }

                App.db.CreateTable<Models.Category>();
                var c = App.db.Table<Models.Category>().FirstOrDefault(x => x.CatName == txName.Text);
                if (c != null)
                {
                    await DisplayAlert("Error", "Name Already Exist", "OK");
                    return;
                }
               
                Models.Category cat = new Models.Category()
                {
                    CatName = txName.Text,
                    Detail = txDetails.Text,
                    Image = PicPath,
                };

                App.db.Insert(cat);
                await DisplayAlert("Success", "Category Created Sucessfully", "Ok");


            }
            catch (Exception erre)
            {
                await DisplayAlert("Error", "Something went wrong. Please check your internet connection. \nError: " + erre.Message, "OK");

            }
        }

    }
}