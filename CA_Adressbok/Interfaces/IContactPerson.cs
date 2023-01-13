namespace CA_Adressbok.Interfaces;

internal interface IContactPerson
{
	Guid Id { get; set; }
	string FirstName { get; set; }
	string LastName { get; set; }
	string Email { get; set; }
	string Phone { get; set; }
	string Adress { get; set; }
	string DisplayName => $"{FirstName} {LastName}";
}
