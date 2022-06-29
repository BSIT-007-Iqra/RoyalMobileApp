using RoyalMobileApp.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace RoyalMobileApp.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}