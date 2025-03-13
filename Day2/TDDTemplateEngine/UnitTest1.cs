namespace TemplateEngine.Tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void ForOneVariable()
    {
        TemplateEngine templateEngine = new TemplateEngine();
        templateEngine.SetTemplate("Hello {name}");
        templateEngine.SetVariable("name", "Shiza");
        string result = templateEngine.Evaluate();

        Assert.That("Hello Shiza",Is.EqualTo(result));
    }

    [TestCase("Shiza", "Ali")]
    [TestCase("John", "Doe")]
    public void ForTwoVariable(string firstName, string secondName)
    {
        //Arrange
        TemplateEngine templateEngine = new TemplateEngine();
        templateEngine.SetTemplate("Hello {firstName} {secondName}");
        templateEngine.SetVariable("firstName", firstName);
        templateEngine.SetVariable("secondName", secondName);
        //Act
        string result = templateEngine.Evaluate();
        //Assert
        Assert.That($"Hello {firstName} {secondName}", Is.EqualTo(result));
    }

}