using CA_Adressbok.Interfaces;
using CA_Adressbok.Models;
using Newtonsoft.Json;

namespace CA_Adressbok.Services;

internal class PersonService
{
	public void GetAll(List<ContactPerson> persons)
	{
		Console.WriteLine("Nedanför är alla kontaktpersoner");
		foreach (ContactPerson person in persons)
		{
			Console.WriteLine(person.FirstName + person.LastName + ", " + person.Email + ", " + person.Phone + ", " + person.Adress);
		}
	}

}