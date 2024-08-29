using System.Security.Policy;
using MattsPasswordManager.Validators;

public class EncPasswordValidatorTests
{
    public class ValidateEncPasswordTests
    {
        [Fact]
        public void ValidPassword_ReturnsValid()
        {
            string password = "ValidPassword";

            var result = EncPasswordValidator.ValidateEncPassword(password);

            Assert.True(result.IsValid);
        }

        [Fact]
        public void EmptyPassword_ReturnsInvalid()
        {
            string password = "";

            var result = EncPasswordValidator.ValidateEncPassword(password);

            Assert.False(result.IsValid);
            Assert.Equal("Password cannot be empty!", result.Message);
        }

        [Fact]
        public void OnlySpacesPassword_ReturnsInvalid()
        {
            string password = "  ";

            var result = EncPasswordValidator.ValidateEncPassword(password);

            Assert.False(result.IsValid);
            Assert.Equal("Password cannot contain spaces!", result.Message);
        }

        [Fact]
        public void Over16CharsPassword_ReturnsInvalid()
        {
            string password = "alskdjaslkdjakldjlkasdjlaldk";

            var result = EncPasswordValidator.ValidateEncPassword(password);

            Assert.False(result.IsValid);
            Assert.Equal("Password must be 16 characters or less!", result.Message);
        }

        [Fact]
        public void ContainsSpacesPassword_ReturnsInvalid()
        {
            string password = "sasfdfsd sdfsdfsdf";

            var result = EncPasswordValidator.ValidateEncPassword(password);

            Assert.False(result.IsValid);
            Assert.Equal("Password cannot contain spaces!", result.Message);
        }
    }

    public class CheckPasswordsMatchTests
    {
        [Fact]
        public void MatchingPasswords_ReturnsValid()
        {
            string password1 = "password";
            string password2 = "password";

            var result = EncPasswordValidator.CheckPasswordsMatch(password1, password2);

            Assert.True(result.IsValid);
        }

        [Fact]
        public void DifferentCasesPasswords_ReturnsInValid()
        {
            string password1 = "password";
            string password2 = "passwoRD";

            var result = EncPasswordValidator.CheckPasswordsMatch(password1, password2);

            Assert.False(result.IsValid);
            Assert.Equal("Passwords do not match!", result.Message);
        }

        [Fact]
        public void DifferentPasswords_ReturnsInValid()
        {
            string password1 = "password";
            string password2 = "password123";

            var result = EncPasswordValidator.CheckPasswordsMatch(password1, password2);

            Assert.False(result.IsValid);
            Assert.Equal("Passwords do not match!", result.Message);
        }

        [Fact]
        public void SamePasswordsWithSpaces_ReturnsInValid()
        {
            string password1 = "keyboard-cat ";
            string password2 = "keyboard-cat";

            var result = EncPasswordValidator.CheckPasswordsMatch(password1, password2);

            Assert.False(result.IsValid);
            Assert.Equal("Passwords do not match!", result.Message);
        }
    }
}
