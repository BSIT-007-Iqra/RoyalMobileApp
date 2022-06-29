using RoyalMobileApp.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace RoyalMobileApp.ViewModels
{ 
    public class MainViewModel : BaseViewModel
{
    public MainViewModel()
    {
        Picks = GetPick();
    }
    public List<Pick> Picks { get; set; }
  //public ICommand bookingCommand => new Command(() => Application.Current.MainPage.Navigation.PushAsync(new booking()));
    private List<Pick> GetPick()
    {
        return new List<Pick>
        {
            new Pick {Title="Duplux Room" , Image = "Pic_b.jpg" ,
                Description = "We are providing you the best fesilities with trained staff and Luxuries "},
       new Pick {Title="Queen Room" , Image = "Pic_f.jpg" ,
           Description = "We are providing you the best fesilities with trained staff and Luxuries "}
        };
    }

}
public class Pick
{
    public string Title { get; set; }
    public string Image { get; set; }
    public string Description { get; set; }
    public string Price { get; set; }

}


}