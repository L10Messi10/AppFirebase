using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppFirebase.Model;
using AppFirebase.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppFirebase
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserDetailPage : ContentPage
    {
        private DBFirebase services;
        public UserDetailPage(Users users)
        {
            InitializeComponent();
            BindingContext = users;
            services = new DBFirebase();
        }

        private async void Button_OnClicked(object sender, EventArgs e)
        {
            await services.UpdateUser(
                Fname.Text, Lname.Text, int.Parse(age.Text));
            await Navigation.PopAsync();
        }
    }
}