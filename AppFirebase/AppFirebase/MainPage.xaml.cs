using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppFirebase.Model;
using AppFirebase.ViewModel;
using Xamarin.Forms;

namespace AppFirebase
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new UsersViewModel();
        }

        private async void ListView_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            var users = e.Item as Users;
            if(users == null) return;

            await Navigation.PushAsync(new UserDetailPage(users));

        }
    }
}
