using FireSharp.Interfaces;
using GA1_Intergration.Repository.DataConnection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Firebase.Storage;
/*
220000213 M Tshabalala
219014331 SL Hadebe
219007267 MP Tsoaela    
*/
namespace GA1_Intergration.Repository.Utilities
{
    public class ManageFiles
    {
        private FirebaseConnect _connect;
        private Firebase.Auth.IFirebaseAuthProvider _authProvider;
        private IFirebaseClient _firebaseClient;

        public ManageFiles()
        {
            _connect = new FirebaseConnect();
            _firebaseClient = _connect.firebaseClient;
            _authProvider = _connect.authProvider;
        }

        public async Task<string> Upload(FileStream stream, string fileName)
        {
            string returnLink_error = string.Empty;
            var getUserToken = await _authProvider.SignInWithEmailAndPasswordAsync("techtronicsbus@gmail.com", "Admin@12345");
            var cancellation = new CancellationTokenSource();
            var task = new FirebaseStorage(
                    FirebaseConstants.Bucket, 
                new FirebaseStorageOptions
                {
                    AuthTokenAsyncFactory = () => Task.FromResult(getUserToken.FirebaseToken),
                    ThrowOnCancel = true
                })
                .Child("images")
                .Child(fileName)
                .PutAsync(stream, cancellation.Token);
            try
            {
                string link = await task;
                returnLink_error = link;
            }
            catch (Exception e)
            {
                returnLink_error = "Upload Error: " + e.ToString();
            }
            return returnLink_error;
        }

        public async Task<string> Delete(string fileName)
        {
            string returnLink_error = string.Empty;
            var getUserToken = await _authProvider.SignInWithEmailAndPasswordAsync("techtronicsbus@gmail.com", "123456");
            var cancellation = new CancellationTokenSource();
            dynamic task = new FirebaseStorage(
                    FirebaseConstants.Bucket, 
                    new FirebaseStorageOptions
                {
                    AuthTokenAsyncFactory = () => Task.FromResult(getUserToken.FirebaseToken),
                    ThrowOnCancel = true
                })
                .Child("images")
                .Child(fileName)
                .DeleteAsync();
            try
            {
                string link = await task;
                returnLink_error = link;
            }
            catch (Exception e)
            {
                returnLink_error = "Deletion Error: " + e.ToString();
            }
            return returnLink_error;
        }
    }
}