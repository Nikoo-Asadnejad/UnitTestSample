using Fundamental.Tests.TestData;
using Moq;

namespace Fundamental.Tests.EmailService;

public class SecondOldEmailService_Tests
{
    private readonly OldEmailService _service;
    public SecondOldEmailService_Tests()
    {
        _service = new();
    }
    
    [Theory]
    [EmailServiceNullBodyData]
    public async Task SendAsync_BodyIsNullOrEmpty_ThrowsArgumentException(string body)
    {
        //Act
        var sendAsync = async ()=> await _service.SendAsync(Moq.It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), body);

        //Assert
        var excpetion = await Assert.ThrowsAsync<ArgumentNullException>(sendAsync);
        Assert.Contains("body", excpetion.Message);
    }
}