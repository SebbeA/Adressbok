using CA_Adressbok.Interfaces;

namespace CA_Adressbok.Models;

internal class ContactPerson : IContactPerson
{
	//public Guid Id { get; set; } = Guid.NewGuid();
	public string FirstName { get; set; } = null!;
	public string LastName { get; set; } = null!;
	public string Email { get; set; } = null!;
	public string Phone { get; set; } = null!;
	public string Adress { get; set; } = null!;
	string DisplayName => $"{FirstName} {LastName}";
}
