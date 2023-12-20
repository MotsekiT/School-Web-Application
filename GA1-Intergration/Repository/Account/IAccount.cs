using GA1_Intergration.Models;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GA1_Intergration.Repository.Account
{
    public interface IAccount
    {
        Task SignUp(SignUp signUp);
        Task<string> Login(Models.Login login, string returnUrl, IOwinContext owinContext);

        Task PasswordRestLink(string EmailID);

    }
}
