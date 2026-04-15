using System;
using System.Collections.Generic;
using services.AuthService.src.models;


namespace services.AuthService{
    class AuthService{

        static void register(List<User> userlist){
            try{
                Console.Write("Enter name: ");
                string name = Console.ReadLine();
                Console.Write("Enter username: ");
                string username = Console.ReadLine();
                Console.Write("Enter password: ");
                string pass = Console.ReadLine();
                userlist.Add(new User(username,pass));
                Console.WriteLine("{0} Registered Successfully!", name);
            }catch(Exception ex){
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }

        static void login(List<User> userlist){
            try{
                Console.Write("Enter username: ");
                string username = Console.ReadLine();
                Console.Write("Enter Password: ");
                string pass = Console.ReadLine();
                User user = new User(username,pass);
                int index = userlist.IndexOf(user);
                if(index==-1) {
                    Console.WriteLine("Not registered!");
                    Console.WriteLine("Retry? (y/n)");
                    if(Console.ReadLine().ToLower()=="y") login(userlist);
                    if(Console.ReadLine().ToLower()=="n"){
                        Console.WriteLine("Register? (y/n)");
                        if(Console.ReadLine().ToLower()=="y") register(userlist);
                        else Console.WriteLine("Exiting...");
                    }
                }
                else if(!userlist[index].Verify(username,pass)) {
                    Console.WriteLine("Invalid Password!!");
                    Console.WriteLine("Retry? (y/n)");
                    if(Console.ReadLine().ToLower()=="y") login(userlist);
                }
                else {
                    userlist[index].add_last_login();
                    Console.WriteLine("Login Successful!!");
                }
            }catch(Exception ex){
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }

        static void forgot_password(List<User> userlist){
            try{
                Console.Write("Enter username: ");
                string username = Console.ReadLine();   
                int index = userlist.IndexOf(new User(username,""));
                if(index==-1) {
                    Console.WriteLine("Not registered!");
                    Console.WriteLine("Retry? (y/n)");
                    if(Console.ReadLine().ToLower()=="y") forgot_password(userlist);
                    if(Console.ReadLine().ToLower()=="n"){
                        Console.WriteLine("Login? (y/n)");
                        if(Console.ReadLine().ToLower()=="y") login(userlist);
                        else Console.WriteLine("Exiting...");
                    }
                }
                Console.WriteLine("Your new password ");
                string pass = Console.ReadLine();
                userlist[index].update_password(pass);
                Console.WriteLine("Password Updated Successfully!!");
                Console.WriteLine("Login Now? (y/n)");
                if(Console.ReadLine().ToLower()=="y") login(userlist);
            }catch(Exception ex){
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }


        public static void AuthSystem()
        {
            try{
                List<User> userlist = new List<User>();
                Console.WriteLine("===========================================");
                Console.WriteLine("===Welcome to the Authentication System====");
                Console.WriteLine("===========================================");

                Console.WriteLine("Please Choose:");
                Console.WriteLine("1. Register\n 2. Login\n 3. Forgot password\n 4.Exit");

                switch (Console.ReadLine()){
                    case "1":
                        register(userlist);
                        break;

                    case "2":
                        login(userlist);
                        break;

                    case "3":
                        forgot_password(userlist);
                        break;
                    default:
                        Console.WriteLine("===========================================");
                        Console.WriteLine("==========Exiting...=======================");  
                        Console.WriteLine("===========================================");  
                        break;
                }
            }catch(Exception ex){
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}