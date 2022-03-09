using DriversLog.UI.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace DriversLog.UI.Views
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