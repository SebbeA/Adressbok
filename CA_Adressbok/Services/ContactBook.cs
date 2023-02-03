using CA_Adressbok.Models;

namespace CA_Adressbok.Services;

public class ContactBook
{
	public List<ContactPerson> ContactList { get; set; } = new List<ContactPerson>();
}
