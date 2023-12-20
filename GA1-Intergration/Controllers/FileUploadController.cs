using Firebase.Auth;
using Firebase.Storage;
using GA1_Intergration.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace GA1_Intergration.Controllers
{
    public class FileUploadController : Controller
    {
        
        
        private static string Web_Api = "AIzaSyDbQPheNov1dYGes9SYmXIMSWmOUEhkfPU";
        private static string Bucket = "groupassignment2-36a80.appspot.com";
        private static string AuthEmail = "techtronicsbus@gmail.com";
        private static string password = "Admin@12345";
        
        // GET: FileUpload
        public ActionResult Index()
        { 
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Index(FileUpload fileUpload, HttpPostedFileBase postedFile)
        {

            FileStream stream;           

            if (postedFile.ContentLength > 0)
            {
                string path = Path.Combine(Server.MapPath("~/Content/images/"), postedFile.FileName);
                postedFile.SaveAs(path);
                stream = new FileStream(Path.Combine(path), FileMode.Open);
                await Task.Run(() => Upload(stream, postedFile.FileName));
            } 



                return View();
        }//end 


        public async void Upload(FileStream stream, string fileName)
        {
           
            // of course you can login using other method, not just email+password
            var auth = new FirebaseAuthProvider(new FirebaseConfig(Web_Api));
            var a = await auth.SignInWithEmailAndPasswordAsync(AuthEmail, password);

            // you can use CancellationTokenSource to cancel the upload midway
            var cancellation = new CancellationTokenSource();

            var task = new FirebaseStorage(
                Bucket,
                new FirebaseStorageOptions
                {
                    AuthTokenAsyncFactory = () => Task.FromResult(a.FirebaseToken),
                    ThrowOnCancel = true // when you cancel the upload, exception is thrown. By default no exception is thrown
                })
                .Child("images")
                .Child(fileName)
                .PutAsync(stream, cancellation.Token);


            try
            {
                // error during upload will be thrown when you await the task
                string link = await task;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception was thrown: {0}", ex);
            }
        }
    }
}