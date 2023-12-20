using FireSharp.Interfaces;
using FireSharp.Response;
using GA1_Intergration.Repository.DataConnection;
using GA1_Intergration.Repository.Utilities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
/*
220000213 M Tshabalala
219014331 SL Hadebe
219007267 MP Tsoaela    
*/
namespace GA1_Intergration.Repository.Contact
{
    public class ContactRepository : IContact, IDisposable
    {
        FirebaseConnect connect = new FirebaseConnect();
        private IFirebaseClient _firebaseClient;
        public ContactRepository()
        {

            _firebaseClient = connect.firebaseClient;
        }
        public void AddConact(Models.Contact contact)
        {
            var contactData = contact;
            PushResponse pushResponse = _firebaseClient.Push("Contact/", contactData);
            contactData.ContactId = pushResponse.Result.name;
            SetResponse setResponse = _firebaseClient.Set("Contact/" + contactData.ContactId, contactData);
        }

        public void Dispose()
        {
            this.Dispose();
        }

        public async Task EditContact(Models.Contact contact)
        {
            string body = string.Empty;
            var root =  AppDomain.CurrentDomain.BaseDirectory; 
            using (var reader = new System.IO.StreamReader(root + @"EmailTemplate/ResponseMessageTemplate.txt"))
            {
                string readFile = reader.ReadToEnd();
                string strContent = string.Empty;
                strContent = readFile;
                strContent = strContent.Replace("[FullName]", contact.FullName);
                strContent = strContent.Replace("[RespondMessage]", contact.ResponseMessage);
                body = strContent.ToString();

            }

            MailMessage mailMessage = new MailMessage("palesadlamini421@gmail.com", "palesadlamini421@gmail.com");
            mailMessage.Subject = "Ref Num: " + contact.ContactId  + " - " + "Techtronics response";
            mailMessage.Body = body;

            await Mail.SendMail(mailMessage);
            SetResponse firebaseSetResponse = _firebaseClient.Set("Contact/" + contact.ContactId, contact);

        }

        public List<Models.Contact> GetAllContacts()
        {
            FirebaseResponse firebaseResponse = _firebaseClient.Get("Contact");
            dynamic contactData = JsonConvert.DeserializeObject<dynamic>(firebaseResponse.Body);
            var contactList = new List<Models.Contact>();

            if (contactData != null)
            {
                foreach (var contact in contactData)
                {
                    contactList.Add(JsonConvert.DeserializeObject<Models.Contact>(((JProperty)contact).Value.ToString()));
                }
            }

            return contactList;
        }

        public void RemoveConact(string contactId)
        {
            FirebaseResponse firebaseResponse = _firebaseClient.Delete("Contact/" + contactId);
        }

        public Models.Contact ShowContact(string contactId)
        {
            FirebaseResponse firebaseResponse = _firebaseClient.Get("Contact/" + contactId);
            Models.Contact contact = JsonConvert.DeserializeObject<Models.Contact>(firebaseResponse.Body);
            return contact;
        }
    }
}