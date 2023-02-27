using FakeItEasy;

namespace Domain.UnitTests
{
    public class BookTests
    {
        private IEmailSender _emailSender;

        [SetUp]
        public void SetUp() 
        { 
            _emailSender = A.Fake<IEmailSender>();
        }

        [Test]
        public void Reserve_WhenBookAvailable_ShouldReturnReservation()
        {
            // Arrange
            var book = new Book("Harry Potter", "MC", _emailSender);
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
            var book = new Book("Harry Potter", "MC", _emailSender);
            var user = new User("Jhon", "Doe", "jdoe@gmail.com");
            book.Reserve(user);

            // Act
            var exception = Assert.Throws<ApplicationException>(()=> book.Reserve(user));

            // Assert
            StringAssert.Contains($"Book is not available. Book id: [{book.Id}]", exception?.Message);
        }
    }
}
