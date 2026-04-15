using System;
using System.Collections.Generic;
using services.AuthService;

public class Program{
    //command: cmd /c build.cmd
    public static void Main(string[] args)
    {
        // Authentication System
        try{
            AuthService.AuthSystem();
        }catch(Exception ex){
            Console.WriteLine("An error occurred: " + ex.Message);
        }   
    }
        
}