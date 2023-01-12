namespace CA_Adressbok.Services;

internal class MainMenu
{
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
			case "4": OptionOFour(); break;
			case "5": OptionOFive(); break;
		}
	}
}
