using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppFirebase.Model;
using Firebase.Database;
using Firebase.Database.Query;

namespace AppFirebase.Services
{
    public class DBFirebase
    {
        public FirebaseClient client;

        public DBFirebase()
        {
            client = new FirebaseClient(
                "PASTE YOUR FIREBASE LINK HERE");
        }

        public ObservableCollection<Users> GetUsersList()
        {
            var userdata = client
                .Child("Users")
                .AsObservable<Users>()
                .AsObservableCollection();
            return userdata;
        }

        public async Task AddUser(string fname, string lname, int age)
        {
            Users u = new Users() {Fname = fname, Lname = lname, age = age};
            await client
                .Child("Users")
                .PostAsync(u);
        }

        public async Task UpdateUser(string fname, string lname, int age)
        {
            var toUpdateUser = (await client
                .Child("Users")
                .OnceAsync<Users>()).FirstOrDefault
                (a => a.Object.Fname == fname);

            Users u = new Users() {Fname = fname, Lname = lname, age = age};
            await client
                .Child("Users")
                .Child(toUpdateUser.Key)
                .PutAsync(u);
        }

        public async Task DeleteUser(string fname, string lname, int age)
        {
            var toDeleteUser = (await client
                .Child("Users")
                .OnceAsync<Users>()).FirstOrDefault
                (a => a.Object.Fname == fname || a.Object.Lname == lname);
            await client.Child("Users").Child(toDeleteUser.Key).DeleteAsync();
        }
    }
}
