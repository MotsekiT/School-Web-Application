using FireSharp.Interfaces;
using FireSharp.Response;
using GA1_Intergration.Models;
using GA1_Intergration.Repository.DataConnection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GA1_Intergration.Controllers
{
    public class LearnerController : Controller
    {

        private FirebaseConnect _connect;
        private Firebase.Auth.IFirebaseAuthProvider _authProvider;
        private IFirebaseClient _firebaseClient;
        private IFirebaseConfig config;
        private IFirebaseClient client;
        public LearnerController()
        {
            _connect = new FirebaseConnect();
            _firebaseClient = _connect.firebaseClient;
            _authProvider = _connect.authProvider;
            config = new FireSharp.Config.FirebaseConfig()
            {
                AuthSecret = FirebaseConstants.AuthorizationSecret,
                BasePath = FirebaseConstants.FirebaseDatabaseAddress
            };
            client = new FireSharp.FirebaseClient(config);
        }

        // GET: Learner
        public ActionResult Index()
        {
            client = new FireSharp.FirebaseClient(config);
            FirebaseResponse response = client.Get("Learners");
            dynamic data = JsonConvert.DeserializeObject<dynamic>(response.Body);
            var list = new List<Learner>();
            foreach (var item in data)
            {
                list.Add(JsonConvert.DeserializeObject<Learner>(((JProperty)item).Value.ToString()));
            }
            return View(list);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Learner learner)
        {
            try
            {
                client = new FireSharp.FirebaseClient(config);
                var data = learner;
                PushResponse response = _firebaseClient.Push("Learners/", data);
                data.Id = response.Result.name;
                SetResponse setResponse = _firebaseClient.Set("Learners/" + data.Id, data);

                if (setResponse.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    ModelState.AddModelError(string.Empty, "Added Succesfully");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Something went wrong!!");
                }
            }
            catch (Exception ex)
            {

                ModelState.AddModelError(string.Empty, ex.Message);
            }

            return View();
        }

        [HttpGet]
        public ActionResult Detail(string id)
        {
            client = new FireSharp.FirebaseClient(config);
            FirebaseResponse response = client.Get("Learners/" + id);
            Learner data = JsonConvert.DeserializeObject<Learner>(response.Body);
            return View(data);
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            client = new FireSharp.FirebaseClient(config);
            FirebaseResponse response = client.Get("Learners/" + id);
            Learner data = JsonConvert.DeserializeObject<Learner>(response.Body);
            return View(data);
        }

        [HttpPost]
        public ActionResult Edit(Learner learner)
        {
            client = new FireSharp.FirebaseClient(config);
            SetResponse response = client.Set("Learners/" + learner.Id, learner);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(string id)
        {
            client = new FireSharp.FirebaseClient(config);
            FirebaseResponse response = client.Delete("Learners/" + id);
            return RedirectToAction("Index");
        }




    }
}