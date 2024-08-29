using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MattsPasswordManager.Validators;

public class EntryValidatorTests
{
    public class ValidateDescriptionTests
    {
        [Fact]
        public void ValidDescription_ReturnsValid()
        {
            string description = "This is a description";

            var result = EntryValidator.ValidateDescription(description);

            Assert.True(result.IsValid);
        }

        [Fact]
        public void StartingSpaces_ReturnsValid()
        {
            string description = " This is a description";

            var result = EntryValidator.ValidateDescription(description);

            Assert.True(result.IsValid);
        }

        [Fact]
        public void EndingSpaces_ReturnsValid()
        {
            string description = "This is a description   ";

            var result = EntryValidator.ValidateDescription(description);

            Assert.True(result.IsValid);
        }

        [Fact]
        public void EmptyDescription_ReturnsInValid()
        {
            string description = "";

            var result = EntryValidator.ValidateDescription(description);

            Assert.False(result.IsValid);
            Assert.Equal("Description cannot be empty!", result.Message);
        }

        [Fact]
        public void EmptySpacesDescription_ReturnsInValid()
        {
            string description = "   ";

            var result = EntryValidator.ValidateDescription(description);

            Assert.False(result.IsValid);
            Assert.Equal("Description cannot be empty!", result.Message);
        }

        [Fact]
        public void TooLongDescription_ReturnsInValid()
        {
            string description = "";

            for (int i = 0; i < 201; i++)
            {
                description += "A";
            }

            var result = EntryValidator.ValidateDescription(description);

            Assert.False(result.IsValid);
            Assert.Equal("Description cannot exceed 200 characters!", result.Message);
        }
    }
}
