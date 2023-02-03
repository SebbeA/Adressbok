using CA_Adressbok.Models;

namespace CA_Adressbok.Services;

internal class MainMenu
{
	private List<ContactPerson> contacts = new List<ContactPerson>();
	private FileService file = new FileService($@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\contacts.json");
	public string FilePath { get; set; } = null!;
	public void OptionMenu()
	{
		Console.Clear();
		file.Read();
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

		file.Save(contacts);
	}
	private void CreateContactPerson()
	{
		Console.Clear();
		Console.WriteLine("Fyll i följande:\n ");

		var person = new ContactPerson();
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

		contacts.Add(person);
		file.Save(contacts);
	}
	private void OptionTwo()
	{
		Console.Clear();
		Console.WriteLine("Visa alla kontaktpersoner.\n ");
		Console.WriteLine("1. Visa alla. ");
		Console.WriteLine("2. Återgå till startsida. ");
		contacts = file.Read();
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

		if (contacts.Count == 0)
		{
			Console.WriteLine("Det finns inga kontaker i listan.");
		}
		else
		{
			Console.WriteLine("Antal kontakter: " + contacts.Count);

			foreach (ContactPerson person in contacts)
			{
				Console.WriteLine($"{person.FirstName} {person.LastName}, {person.Email}, {person.Phone}, {person.Adress}");
			}
		}

		file.Read();
		Console.WriteLine("Tryck på valfri tangent för att gå tillbaka till huvudmenyn.");
		Console.ReadLine();
	}
	private void OptionThree()
	{
		Console.Clear();
		Console.WriteLine("Visa en specifik kontaktperson.\n ");
		Console.WriteLine("1. Sök på för och efternamn. ");
		Console.WriteLine("2. Återgå till startsida. ");
		var option = Console.ReadLine();

		switch (option)
		{
			case "1": ShowOneContact(); break;
			case "2": return;
		}
	}
	private void ShowOneContact()
	{
		Console.Clear();
		Console.WriteLine("Ange förnamn");
		var firstName = Console.ReadLine();
		Console.WriteLine("Ange efternamn");
		var lastName = Console.ReadLine();

		var contact = contacts.FirstOrDefault(c => c.FirstName.ToLower() == firstName && c.LastName.ToLower() == lastName);
		if (contact == null)
		{
			Console.WriteLine("Kontaktpersonen hittades inte.");
		}
		else
		{
			Console.WriteLine($"{contact.FirstName} {contact.LastName}, {contact.Email}, {contact.Phone}, {contact.Adress}");
		}
		Console.WriteLine("Tryck på valfri tangent för att gå tillbaka till huvudmenyn.");
		Console.ReadLine();
	}

	private void OptionFour()
	{
		Console.Clear();
		Console.WriteLine("Radera en specifik kontaktperson.\n ");
		Console.WriteLine("1. Sök på för och efternamn. ");
		Console.WriteLine("2. Återgå till startsida. ");
		var option = Console.ReadLine();

		switch (option)
		{
			case "1": RewmoveOneContact(); break;
			case "2": return;
		}
	}
	private void RewmoveOneContact()
	{
		Console.Clear();
		Console.WriteLine("Radera en kontaktperson");
		Console.WriteLine("Ange förnamn");
		var firstName = Console.ReadLine();
		Console.WriteLine("Ange efternamn");
		var lastName = Console.ReadLine();

		var contact = contacts.FirstOrDefault(c => c.FirstName.ToLower() == firstName && c.LastName.ToLower() == lastName);
		if (contact == null)
		{
			Console.WriteLine("Kontaktpersonen hittades inte.");
		}
		else
		{
			Console.WriteLine("Är du säker på att du vill ta bort denna kontaktperson? (y/n)");
			var confirm = Console.ReadLine();

			if (confirm?.ToLower() == "y")
			{
				if (firstName != null && lastName != null)
				{
					contacts.Remove(contact);
					file.DeleteContact(firstName, lastName);
					Console.WriteLine("Kontaktpersonen har tagits bort.");
					file.Save(contacts);
				}
			}
			else
			{
				Console.WriteLine("Ingen kontaktperson togs bort.");
			}
		}
		file.Read();
		Console.WriteLine("Tryck på valfri tangent för att gå tillbaka till huvudmenyn.");
		Console.ReadKey();
	}
}
