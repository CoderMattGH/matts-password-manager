using MattsPasswordManager.Validators;

public class EncPasswordValidatorTests
{
    [Fact]
    public void ValidPassword_ReturnsValid()
    {
        string password = "ValidPassword";

        var result = EncPasswordValidator.ValidateEncPassword(password);

        Assert.True(result.IsValid);
    }
}
