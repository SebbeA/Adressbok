using CA_Adressbok.Models;
using Newtonsoft.Json;

namespace CA_Adressbok.Services;

public class FileService
{
	private List<ContactPerson> _persons;
	private readonly string _filePath;

	public FileService(string filePath)
	{
		_filePath = filePath;
		_persons = new List<ContactPerson>();
	}

	public void Save(List<ContactPerson> contacts)
	{
		using var sw = new StreamWriter(_filePath);
		sw.Write(JsonConvert.SerializeObject(contacts));
	}

	public void DeleteContact(string firstName, string lastName)
	{
		try
		{
			var tempFile = Path.GetTempFileName();
			using (var sr = new StreamReader(_filePath))
			using (var sw = new StreamWriter(tempFile))
			{
				string line;
				while ((line = sr.ReadLine() ?? "") != "")
				{
					var contact = JsonConvert.DeserializeObject<ContactPerson>(line);
					if (contact != null && contact.FirstName != firstName || contact != null && contact.LastName != lastName)
					{
						sw.WriteLine(line);
					}
				}
			}
			File.Delete(_filePath);
			File.Move(tempFile, _filePath);
		}
		catch { }
	}

	public List<ContactPerson> Read()
	{
		try
		{
			using var sr = new StreamReader(_filePath);
			_persons = JsonConvert.DeserializeObject<List<ContactPerson>>(sr.ReadToEnd())!;
		}
		catch { _persons = new List<ContactPerson>(); }

		return _persons;
	}

	public ContactPerson GetContact(string firstName, string lastName)
	{
		try
		{
			using (var sr = new StreamReader(_filePath))
			{
				string line;
				while ((line = sr.ReadLine() ?? "") != "")
				{
					var contact = JsonConvert.DeserializeObject<ContactPerson>(line);
					if (contact != null && contact.FirstName != firstName && contact.LastName != lastName)
					{
						return contact;
					}
				}
			}
		}
		catch { }
		return null!;
	}
}
