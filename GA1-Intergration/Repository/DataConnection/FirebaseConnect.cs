using Firebase.Auth;
using FireSharp.Config;
using FireSharp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GA1_Intergration.Repository.DataConnection
{
    public class FirebaseConnect : IDisposable
    {
        public IFirebaseClient firebaseClient { get; }
        public IFirebaseAuthProvider authProvider;

        public FirebaseConnect()
        {
            IFirebaseConfig config = new FireSharp.Config.FirebaseConfig()
            {
                AuthSecret = FirebaseConstants.AuthorizationSecret,
                BasePath = FirebaseConstants.FirebaseDatabaseAddress
            };
            firebaseClient = new FireSharp.FirebaseClient(config);
            authProvider = new FirebaseAuthProvider(new Firebase.Auth.FirebaseConfig(FirebaseConstants.Web_Api));
        }

        public void Dispose()
        {
            this.Dispose();
        }

    }
}