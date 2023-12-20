using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
220000213 M Tshabalala
219014331 SL Hadebe
219007267 MP Tsoaela    
*/
namespace GA1_Intergration.Repository.Contact
{
    public interface IContact
    {
        void AddConact(GA1_Intergration.Models.Contact contact);
        void RemoveConact(string contactId);

        GA1_Intergration.Models.Contact ShowContact(string contactId);

        List<Models.Contact> GetAllContacts();
        

        Task EditContact(GA1_Intergration.Models.Contact contact);

    }
}
