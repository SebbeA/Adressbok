using CA_Adressbok.Interfaces;
using CA_Adressbok.Models;

namespace CA_Adressbok.Services;

internal class PersonService
{
	public void ShowAll(List<IContactPerson> people)
	{
		Console.WriteLine("Nedanför är alla kontaktpersoner");
		foreach (IContactPerson person in people)
		{
			Console.WriteLine(person.DisplayName + ", " + person.Email + ", " + person.Phone + ", " + person.Adress);
		}
	}
}

/*	var personService = new PersonService();
	List<IContactPerson> people = new List<IContactPerson>();
	personService.ShowAll(people);*/