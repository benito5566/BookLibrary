using FakeItEasy;

namespace Domain.UnitTests
{
    public class BookTests
    {
        [Test]
        public void Reserve_WhenBookAvailable_ShouldReturnReservation()
        {
            // Arrange
            var emailSender = A.Fake<IEmailSender>();
            var book = new Book("Harry Potter", "MC", emailSender);
            var user = new User("Jhon", "Doe", "jdoe@gmail.com");

            // Act
            var result = book.Reserve(user);

            // Assert
            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public void Reserve_WhenBookIsReserved_ShouldThrowException()
        {
            // Arrange
            var emailSender = A.Fake<IEmailSender>();
            var book = new Book("Harry Potter", "MC", emailSender);
            var user = new User("Jhon", "Doe", "jdoe@gmail.com");
            book.Reserve(user);

            // Act
            var exception = Assert.Throws<ApplicationException>(()=> book.Reserve(user));

            // Assert
            StringAssert.Contains($"Book is not available. Book id: [{book.Id}]", exception?.Message);
        }
    }
}
