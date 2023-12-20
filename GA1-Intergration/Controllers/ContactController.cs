using GA1_Intergration.Models;
using GA1_Intergration.Repository.Contact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
/*
220000213 M Tshabalala
219014331 SL Hadebe
219007267 MP Tsoaela    
*/
namespace GA1_Intergration.Controllers
{
 
    public class ContactController : Controller
    {


        private ContactRepository _contactRespository;
        public ContactController()
        {
            _contactRespository = new ContactRepository();
        }

        // GET: Contact
        public ActionResult Index()
        {
            return View(_contactRespository.GetAllContacts());
        }


        // GET: Contact
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // GET: Contact
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Contact contact)
        {

            try
            {
                if (string.IsNullOrEmpty(contact.Message) == false)
                {
                    _contactRespository.AddConact(contact);
                    ModelState.AddModelError(string.Empty, "Your message has been sent, we will be in contact soon");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Kindly enter a message, then click the send message");
                }
                  
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Your message was not sent. Kindly view the contact information.");
            }


            return View();
        }


        //Details 
        [HttpGet]
        public ActionResult Details(string id)
        {
            return View(_contactRespository.ShowContact(id));
        }

        //Details 
        [HttpGet]
        public ActionResult Delete(string id)
        {
            if (string.IsNullOrEmpty(id) == false)
            {
                _contactRespository.RemoveConact(id);
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Contact message cannot be found");
               return View();

            }
            return RedirectToAction("Index", "Contact");
        }


        [HttpGet]
        public ActionResult Edit(string id)
        {
            return View(_contactRespository.ShowContact(id));
        }
        [HttpPost]
        [ValidateInput(false)]
        public async Task<ActionResult> Edit(Contact contact)
        {
            try
            {
                await _contactRespository.EditContact(contact);
                ModelState.AddModelError(string.Empty, "Contact Response Successful");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Contact Response not Successful");
            }
            
            return RedirectToAction("Index", "Contact");
        }

    }
}