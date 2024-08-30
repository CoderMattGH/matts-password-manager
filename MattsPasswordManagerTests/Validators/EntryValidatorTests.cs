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
        public void EmptyDescription_ReturnsInvalid()
        {
            string description = "";

            var result = EntryValidator.ValidateDescription(description);

            Assert.False(result.IsValid);
            Assert.Equal("Description cannot be empty!", result.Message);
        }

        [Fact]
        public void EmptySpacesDescription_ReturnsInvalid()
        {
            string description = "   ";

            var result = EntryValidator.ValidateDescription(description);

            Assert.False(result.IsValid);
            Assert.Equal("Description cannot be empty!", result.Message);
        }

        [Fact]
        public void TooLongDescription_ReturnsInvalid()
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

    public class ValidateUsernameTests
    {
        [Fact]
        public void ValidUsername_ReturnsValid()
        {
            string username = "validusername";

            var result = EntryValidator.ValidateUsername(username);

            Assert.True(result.IsValid);
        }

        [Fact]
        public void EmptyUsername_ReturnsInvalid()
        {
            string username = "";

            var result = EntryValidator.ValidateUsername(username);

            Assert.False(result.IsValid);
            Assert.Equal("Username cannot be empty!", result.Message);
        }

        [Fact]
        public void JustSpacesUsername_ReturnsInvalid()
        {
            string username = "   ";

            var result = EntryValidator.ValidateUsername(username);

            Assert.False(result.IsValid);
            Assert.Equal("Username cannot be empty!", result.Message);
        }

        [Fact]
        public void StartingSpaces_ReturnsInvalid()
        {
            string username = " username";

            var result = EntryValidator.ValidateUsername(username);

            Assert.False(result.IsValid);
            Assert.Equal("Username cannot contain spaces!", result.Message);
        }

        [Fact]
        public void EndingSpaces_ReturnsInvalid()
        {
            string username = "username  ";

            var result = EntryValidator.ValidateUsername(username);

            Assert.False(result.IsValid);
            Assert.Equal("Username cannot contain spaces!", result.Message);
        }

        [Fact]
        public void ContainsSpaces_ReturnsInvalid()
        {
            string username = "a username";

            var result = EntryValidator.ValidateUsername(username);

            Assert.False(result.IsValid);
            Assert.Equal("Username cannot contain spaces!", result.Message);
        }

        [Fact]
        public void UsernameTooLong_ReturnsInvalid()
        {
            string username = "";
            for (int i = 0; i < 101; i++)
            {
                username += "A";
            }

            var result = EntryValidator.ValidateUsername(username);

            Assert.False(result.IsValid);
            Assert.Equal("Username cannot exceed 100 characters!", result.Message);
        }
    }
}
