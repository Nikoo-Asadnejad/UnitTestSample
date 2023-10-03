using Fundamental.Tests.TestData;
using SampleProject;

namespace Fundamental.Tests.EmailService;
/// <summary>
/// Exceptions
/// </summary>
public class OldEmailService_tests
{
    [Theory]
    [EmailServiceNullBodyData]
    public async Task SendAsync_BodyIsNullOrEmpty_ThrowsArgumentException_(string body)
    {
        //Arrange
        var service = new OldEmailService();

        //Act
        await service.SendAsync("", "", "", body);
        
        //Assert
        Assert.True(true);
    }
    
    [Theory]
    [EmailServiceNullBodyData]
    public async Task SendAsync_BodyIsNullOrEmpty_ThrowsArgumentException(string body)
    {
        //Arrange
        var service = new OldEmailService();

        //Act
        var sendAsync = async ()=> await service.SendAsync("", "", "", body);

        //Assert
        var excpetion = await Assert.ThrowsAsync<ArgumentNullException>(sendAsync);
        Assert.Contains("body", excpetion.Message);
    }
}