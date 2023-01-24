//using CA_Adressbok.Models;
//using Newtonsoft.Json;

//namespace CA_Adressbok.Services;

//internal class ContactService
//{
//	private readonly string _filePath;
//	private List<ContactPerson> _contacts;

//	public ContactService(string filePath)
//	{
//		_filePath = filePath;
//		_contacts = JsonConvert.DeserializeObject<List<ContactPerson>>(File.ReadAllText(filePath)) ?? new List<ContactPerson>();
//	}
//	public void AddContact(ContactPerson contact)
//	{
//		_contacts.Add(contact);
//		SaveChanges();
//	}

//	public ContactPerson GetOneContact(string firstname, string lastname)
//	{
//		return _contacts.Find(x => x.FirstName == firstname && x.LastName == lastname)!;
//	}

//	public List<ContactPerson> GetAllContacts()
//	{
//		return _contacts;
//	}

//	public void RemoveContact(string firstname, string lastname)
//	{
//		_contacts.RemoveAll(x => x.FirstName == firstname && x.LastName == lastname);
//		SaveChanges();
//	}

//	private void SaveChanges()
//	{
//		File.WriteAllText(_filePath, JsonConvert.SerializeObject(_contacts));
//	}
//}
