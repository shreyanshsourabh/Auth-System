using System;

namespace services.AuthService.src.models{
    class User{

        string userId, username, password;
        DateTime lastLogin;

        public User(string username, string password){
            this.userId = Guid.NewGuid().ToString();
            this.username = username;
            this.password = password;
            this.lastLogin = DateTime.MinValue;
        }

        public bool Verify(string username, string password){
            if (this.username == username && this.password == password) return true;
            else return false;
        }

        public void update_password(string new_pass){ this.password = new_pass;}

        public void add_last_login() {this.lastLogin = DateTime.Now;}
    }
}