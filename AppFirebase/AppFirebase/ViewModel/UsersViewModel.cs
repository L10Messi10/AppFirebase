using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using AppFirebase.Model;
using AppFirebase.Services;
using MvvmHelpers;
using MvvmHelpers.Commands;

namespace AppFirebase.ViewModel
{
    public class UsersViewModel :BaseViewModel
    {
        public string Fname { get; set; }
        public string Lname { get; set; }
        public int age { get; set; }

        private DBFirebase services;
        public Command AddUsersCommand { get; }
        private ObservableCollection<Users> _users = new ObservableCollection<Users>();

        public ObservableCollection<Users> UsersList
        {
            get { return _users;}
            set
            {
                _users = value;
                OnPropertyChanged();
            }
        }

        public UsersViewModel()
        {
            services = new DBFirebase();
            UsersList = services.GetUsersList();
            AddUsersCommand = new Command(async () => await AddUsersAsync(Fname, Lname, age));
        }

        public async Task AddUsersAsync(string fname, string lname, int age)
        {
            await services.AddUser(fname, lname, age);
            
        }
    }
}
