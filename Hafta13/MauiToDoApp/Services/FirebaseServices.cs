
using Firebase.Auth;
using Firebase.Auth.Providers;
using Firebase.Database;
using Firebase.Database.Query;


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

        const string ConnectionString = "https://rehber2025-cdaf0-default-rtdb.firebaseio.com/";
        static FirebaseClient firebaseClient = new FirebaseClient(ConnectionString);

        internal static bool AddNewTodo(ToDoItem item, ref string message)
        {
            message = "";
            // TODO: Implement Firebase Firestore integration to add a new ToDo item
            if (item == null)
            {
                message = "ToDo item cannot be null.";
                return false;
            }
            else
            {
                firebaseClient.Child($"todos/{item.Id}").PutAsync(item).Wait();
                return true;
            }

        }
    }
}
