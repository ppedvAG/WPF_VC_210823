using System;
using Xunit;

namespace M14_Model.Tests
{
    public class PersonTests
    {
        [Fact]
        public void ModelIsNotNull()
        {
            // Arrange
            var person = new Person
            {
                Vorname = "a",
                Nachname = "b",
                Alter = 1,
                Kontostand = 2
            };

            // Assert
            Assert.NotNull(person);
            Assert.Equal("a", person.Vorname);
            Assert.Equal("b", person.Nachname);
            Assert.Equal(1, person.Alter);
            Assert.Equal(2, person.Kontostand);
        }
    }
}
