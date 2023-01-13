using CA_Adressbok.Interfaces;
using CA_Adressbok.Models;
using Newtonsoft.Json;

namespace CA_Adressbok.Services;

internal class MainMenu
{
	private List<IContactPerson> persons = new List<IContactPerson>();
	private FileService file = new FileService();

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
		var option = Console.ReadLine();

		switch (option)
		{
			case "1": OptionOne(); break;
			case "2": OptionTwo(); break;
			case "3": OptionThree(); break;
			case "4": OptionFour(); break;
			case "5": OptionFive(); break;
		}
	}

	private void OptionOne()
	{
		Console.Clear();
		Console.WriteLine("Skapa en ny kontaktperson.");
		Console.WriteLine("1. Lägg till kontaktperson ");
		Console.WriteLine("2. Återgå till startsida. ");
		var option = Console.ReadLine();

		switch (option)
		{
			case "1": CreateContactPerson(); break;
			//case "2": StartPage(); break;
		}

		file.Save(FilePath, JsonConvert.SerializeObject(new { persons }));
	}

	private void CreateContactPerson()
	{
		Console.Clear();
		Console.WriteLine("Fyll i följande: ");

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
	}

	private void OptionTwo()
	{

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
