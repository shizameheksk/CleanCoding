using Moq;

namespace PredictionEngine.Tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [TestCase("Hello how are y","y")]
    public void ShouldCallUnigramWhenInputIsPartialWord(string inputString, string lastWord)
    {
        //Arrange
        var mockAlgo = new Mock<ILanguageModelAlgo>();
        PredictionEngine predictionEngine = new PredictionEngine(mockAlgo.Object);

        //Act
        string predictedWord = predictionEngine.Predict(inputString);

        //Assert
        mockAlgo.Verify(p => p.predictUsingMonogram(lastWord), Times.Once());
    }

    [TestCase("Hello how are you ", "you")]
    public void ShouldCallBigramWhenInputIsEndingWithASpace(string inputString, string lastWord)
    {
        //Arrange
        var mockAlgo = new Mock<ILanguageModelAlgo>();
        PredictionEngine predictionEngine = new PredictionEngine(mockAlgo.Object);

        //Act
        string predictedWord = predictionEngine.Predict(inputString);

        //Assert
        mockAlgo.Verify(p => p.predictUsingBigram(lastWord), Times.Once());
    }
}

/*

    [Test]
public void Ping_invokes_DoSomething()
{
    // ARRANGE
    var mock = new Mock<ILanguageModelAlgo>();
    mock.Setup(p => p.predictUsingMonogram(It.IsAny<string>())).Returns("value");
   

    // ACT
    

    // ASSERT
    mock.Verify(p => p.predictUsingMonogram("PING"), Times.Once());
}
*/
