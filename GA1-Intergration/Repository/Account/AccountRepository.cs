using FireSharp.Interfaces;
using FireSharp.Response;
using GA1_Intergration.Models;
using GA1_Intergration.Repository.DataConnection;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
/*
220000213 M Tshabalala
219014331 SL Hadebe
219007267 MP Tsoaela    
*/
namespace GA1_Intergration.Repository.Account
{
    public class AccountRepository
    {
        private FirebaseConnect _connect;
        private Firebase.Auth.IFirebaseAuthProvider _authProvider;
        private IFirebaseClient _firebaseClient;

        public AccountRepository()
        {
            _connect = new FirebaseConnect();
            _authProvider = _connect.authProvider;
            _firebaseClient = _connect.firebaseClient;

        }

        public void Dispose()
        {
            this.Dispose();
        }

        public async Task<string> Login(Login login, string returnUrl, IOwinContext owinContext)
        {
           
            var fbAAuthenticationResponse = await _authProvider.SignInWithEmailAndPasswordAsync(login.Email, login.Password);
            string token = fbAAuthenticationResponse.FirebaseToken;

            var user = fbAAuthenticationResponse.User;

            if(!string.IsNullOrEmpty(token))
            {
                var claims = new List<Claim>();
                try
                {
                    claims.Add(new Claim(ClaimTypes.Email, user.Email));
                    claims.Add(new Claim(ClaimTypes.Authentication, token));
                    var claimIdentities = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie);
                    var ctx = owinContext;
                    var authenticationManager = ctx.Authentication;
                    authenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = false}, claimIdentities);

                    if (IsAdmin(login))
                    {
                        return "Admin";
                    }
                    return "User";
                }
                catch (Exception ex)
                {
                    return "Authentication login failed";
                }
                
            }
            else
            {
                return "Token generation failed";
            }    
        }

        public async Task ResetPasswordLink(string emailId)
        {
            await _authProvider.SendPasswordResetEmailAsync(emailId);
        }
        private bool IsAdmin(Models.Login login)
        {
            FirebaseResponse firebaseResponse = _firebaseClient.Get("AccessRight/");
            var accessRightData = JsonConvert.DeserializeObject<List<string>>(firebaseResponse.Body);
            return login.Email == accessRightData[0].ToString();
        }
        public async Task SignUp(SignUp signUp)
        {
            await _authProvider.CreateUserWithEmailAndPasswordAsync(signUp.EmailAddress, signUp.Password, signUp.Name, true);


        }


    }
}