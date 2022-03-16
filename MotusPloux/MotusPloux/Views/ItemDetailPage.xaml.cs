using MotusPloux.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace MotusPloux.Views
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