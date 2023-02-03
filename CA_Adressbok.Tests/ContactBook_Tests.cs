using CA_Adressbok.Models;
using CA_Adressbok.Services;

namespace CA_Adressbok.Tests
{
	public class ContactBook_Tests
	{

		private ContactBook contactBook;
		ContactPerson contact;

		public ContactBook_Tests()
		{
			// arrange
			contactBook = new ContactBook();
			contact = new ContactPerson();
		}

		[Fact]
		public void Should_Add_Contact_To_List()
		{
			contactBook.ContactList.Add(contact);
			contactBook.ContactList.Add(contact);

			// assert
			Assert.Equal(2, contactBook.ContactList.Count);
		}
	}
}