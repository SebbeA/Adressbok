using CA_Adressbok.Services;

var mainmenu = new MainMenu();
mainmenu.FilePath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\content.json";

while (true)
{
	Console.Clear();
	mainmenu.OptionMenu();
}