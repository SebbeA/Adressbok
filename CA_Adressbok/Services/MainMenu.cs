﻿using CA_Adressbok.Models;
using Newtonsoft.Json;

namespace CA_Adressbok.Services;

internal class MainMenu
{
	private readonly List<ContactPerson> persons = new List<ContactPerson>();
	private readonly FileService file = new FileService();
	//private PersonService _personService = new();
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

		file.Save(FilePath, JsonConvert.SerializeObject(persons));
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

		file.Save(FilePath, JsonConvert.SerializeObject(persons));
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

		persons.Add(person);
		file.Save(FilePath, JsonConvert.SerializeObject(persons));
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

		Console.WriteLine("Antal kontakter: " + persons.Count);

		//foreach (ContactPerson person in persons)
		//{
		//	Console.WriteLine($"{person.FirstName} {person.LastName}, {person.Email}, {person.Phone}, {person.Adress}");
		//}

		file.Read(FilePath);
		Console.WriteLine("Tryck Enter för att gå tillbaka till menyn.");
		Console.ReadLine();
	}
	private void OptionThree()
	{
		Console.Clear();
		Console.WriteLine("Visa en specifik kontaktperson.\n ");
		Console.WriteLine("1. Sök. ");
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
		Console.WriteLine("Ange förnamn och efternamn");
		var name = Console.ReadLine();

	}
	private void OptionFour()
	{

	}
	private void OptionFive()
	{

	}
}
