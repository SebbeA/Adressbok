using CA_Adressbok.Interfaces;

namespace CA_Adressbok.Models
{
	internal class ContactList
	{
		public List<ContactPerson> persons { get; set; } = new List<ContactPerson>();
	}	
}
