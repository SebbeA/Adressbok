using CA_Adressbok.Interfaces;

namespace CA_Adressbok.Models
{
	internal class ContactList
	{
		public List<IContactPerson> persons { get; set; } = null!;
	}
}
