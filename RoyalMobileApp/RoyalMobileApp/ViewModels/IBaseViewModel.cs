using RoyalMobileApp.Models;
using RoyalMobileApp.Services;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace RoyalMobileApp.ViewModels
{
    public interface IBaseViewModel
    {
        IDataStore<Item> DataStore { get; }
        bool IsBusy { get; set; }
        string Title { get; set; }

        event PropertyChangedEventHandler PropertyChanged;
       
        void OnPropertChanged([CallerMemberName] string name = "");
    }
}