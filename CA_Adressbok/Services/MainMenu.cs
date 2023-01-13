using CA_Adressbok.Interfaces;
using CA_Adressbok.Models;
using Newtonsoft.Json;

namespace CA_Adressbok.Services;

internal class MainMenu
{
	private List<IContactPerson> persons = new List<IContactPerson>();
	private FileService file = new FileService();
	private PersonService _personService = new();
	public string FilePath { get; set; } = null!;
	public void OptionMenu()
	{
		Console.Clear();
		Console.WriteLine("Välkommen till adressboken!");
		Console.WriteLine("1. Skapa en ny kontaktperson");
		Console.WriteLine("2. Visa alla kontaktpersoner");
		Console.WriteLine("3. Visa en specifik kontaktperson");
		Console.WriteLine("4. Ta bort en kontaktperson");
		Console.WriteLine("5. Avsluta");
		Console.Write("Ange ett av alternativen ovan: ");
		var option = Console.ReadLine();

		switch (option)
		{
			case "1": OptionOne(); break;
			case "2": OptionTwo(); break;
			case "3": OptionThree(); break;
			case "4": OptionFour(); break;
			case "5": Environment.Exit(0); break;
		}

		file.Save(FilePath, JsonConvert.SerializeObject(new { persons }));

	}

	private void OptionOne()
	{
		Console.Clear();
		Console.WriteLine("Skapa en ny kontaktperson.\n");
		Console.WriteLine("1. Lägg till kontaktperson ");
		Console.WriteLine("2. Återgå till startsida. ");
		var option = Console.ReadLine();

		switch (option)
		{
			case "1": CreateContactPerson(); break;
			case "2": return;
		}

		file.Save(FilePath, JsonConvert.SerializeObject(new { persons }));
	}

	private void CreateContactPerson()
	{
		Console.Clear();
		Console.WriteLine("Fyll i följande:\n ");

		IContactPerson person = new ContactPerson();
		Console.Write("Ange förnamn: ");
		person.FirstName = Console.ReadLine() ?? "";
		Console.Write("Ange efternamn: ");
		person.LastName = Console.ReadLine() ?? "";
		Console.Write("Ange E-postadress: ");
		person.Email = Console.ReadLine() ?? "";
		Console.Write("Ange telefonnummer: ");
		person.Phone = Console.ReadLine() ?? "";
		Console.Write("Ange adress: ");
		person.Adress = Console.ReadLine() ?? "";

		persons.Add(person);
		file.Save(FilePath, JsonConvert.SerializeObject(new ContactList { persons = persons }));
	}

	private void OptionTwo()
	{
		Console.Clear();
		Console.WriteLine("Visa alla kontaktpersoner.\n ");
		Console.WriteLine("1. Visa alla. ");
		Console.WriteLine("2. Återgå till startsida. ");
		var option = Console.ReadLine();

		switch (option)
		{
			case "1": ShowAllContacts(); break;
			case "2": return;
		}
	}
	private void ShowAllContacts()
	{
		Console.Clear();
		Console.WriteLine("Här är alla kontaktpersoner\n");
		var option = Console.ReadLine();

		foreach (IContactPerson person in persons)
		{
			Console.WriteLine(person.DisplayName + ", " + person.Email + ", " + person.Phone + ", " + person.Adress);
		}
		//PersonService personService = new PersonService();
		_personService.ShowAll(persons);
	}
	private void OptionThree()
	{

	}
	private void OptionFour()
	{

	}
	private void OptionFive()
	{

	}
}
