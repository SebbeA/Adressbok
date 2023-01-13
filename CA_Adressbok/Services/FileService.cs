namespace CA_Adressbok.Services;

internal class FileService
{
	public void Save(string filePath, string content)
	{
		using var sw = new StreamWriter(filePath);
		sw.Write(content);
	}
	public string Read(string filePath)
	{
		try
		{
			using var sr = new StreamReader(filePath);
			return sr.ReadToEnd();
		}
		catch { return null!; }
	}
}
