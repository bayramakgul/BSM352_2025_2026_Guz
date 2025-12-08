
using Firebase.Auth;
using Firebase.Auth.Providers;

using MauiToDoApp.Model;

using System;
using System.Collections.Generic;
using System.Text;

namespace MauiToDoApp.Services
{
    internal static class FirebaseServices
    {
        static string projectId = "rehber2025-cdaf0";
        static string apiKey = "AIzaSyDBaHKTEUZ9BxA1k6FrwtVUfkDYUSR2I1s";
        static string authDomain = "rehber2025-cdaf0.firebaseapp.com";
        static string storeBucked = $"{projectId}.appspot.com";

        static FirebaseAuthConfig config = new FirebaseAuthConfig()
        {
            ApiKey = apiKey,
            AuthDomain = authDomain,
           Providers = new FirebaseAuthProvider[] {  new EmailProvider()  }
        };
        public static Task<bool> Register(string username, string email, string password, ref string message)
        {
            message = "";
            try
            {

                var client = new FirebaseAuthClient(config);
                var res = client.CreateUserWithEmailAndPasswordAsync(email, password, username);

                return Task.FromResult(res.Result.User != null ? true : false);
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            return Task.FromResult(false);
        }

        public static Task<bool> Login(string email, string password, ref string message)
        {
            message = "";
            try
            {
                var client = new FirebaseAuthClient(config);
                var res = client.SignInWithEmailAndPasswordAsync(email, password);

                return Task.FromResult(res.Result?.User != null ? true : false);
            }
            catch(Exception ex)
            {
                message = ex.Message;
            }
            return Task.FromResult(false);
        }

        internal static void AddNewTodo(ToDoItem item)
        {
            throw new NotImplementedException();
        }
    }
}
