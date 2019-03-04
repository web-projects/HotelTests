using NUnit.Framework;
using System.Diagnostics;
using WebProjects.Hotel;

namespace WebProjects.Tests
{
    [TestFixture]
    public class ReservationTest
    {
        [SetUp]
        public void Setup()
        {
            Debug.WriteLine("tests: setup");
        }

        // MethodUnderTest_Scenario_ExpectedBehavior

        [Test]
        public void CanBeCancelledBy_UserIsAdmin_ReturnsTrue()
        {
            // Arrange
            var reservation = new Reservation();

            // Act
            var result = reservation.CanBeCancelledBy(new User { IsAdmin = true } );

            // Assert
            Assert.That(result, Is.True);
        }
 
        [Test]
        public void CanBeCancelledBy_SameUserCancellingReservation_ReturnsTrue()
        {
            // Arrange
            var user = new User();
            var reservation = new Reservation { MadeBy = user };

            // Act
            var result = reservation.CanBeCancelledBy(user);

            // Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void CanBeCancelledBy_AnotherUserCancellingReservation_ReturnsFalse()
        {
            // Arrange
            var reservation = new Reservation { MadeBy = new User() };

            // Act
            var result = reservation.CanBeCancelledBy(new User());

            // Assert
            Assert.That(result, Is.False);
        }
    }
}