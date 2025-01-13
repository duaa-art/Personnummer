using Xunit;
using PersonnummerKontroll;

public class PersonnummerValidatorTests
{
    [Theory]
    [InlineData("19900101-1234", true)]
    [InlineData("19851230-1234", false)]
    [InlineData("19900101-123", false)]
    public void TestValidatePersonnummer(string personnummer, bool expected)
    {
        Assert.Equal(expected, Program.ValidatePersonnummer(personnummer));
    }
}
