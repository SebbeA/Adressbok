using CA_Adressbok.Models;
using Newtonsoft.Json;

namespace CA_Adressbok.Services;

public class FileService
{
	private List<ContactPerson> persons = new List<ContactPerson>();

	public void Save(string filePath, string contacts)
	{
		using var sw = new StreamWriter(filePath);
		sw.Write(JsonConvert.SerializeObject(contacts));
	}
	public void Read(string filePath)
	{
		try
		{
			using var sr = new StreamReader(filePath);
			persons = JsonConvert.DeserializeObject<List<ContactPerson>>(sr.ReadToEnd())!;
		}
		catch { persons = new List<ContactPerson>(); }
	}
}
