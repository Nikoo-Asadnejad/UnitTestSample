using System.Net.Mail;
using Fundamental.Interfaces;
using Fundamental.Tests.TestData;
using Moq;

namespace Fundamental.Tests.EmailService;

public class EmailService_Tests 
{
    private readonly Fundamental.EmailService _service;
    private readonly Mock<ISmtpClientService> _smtpClientMoq;
    public EmailService_Tests()
    {
        _smtpClientMoq= new();
        _service = new(_smtpClientMoq.Object);
    }
    
    [Theory]
    [EmailServiceNullBodyData]
    public async Task SendAsync_BodyIsNullOrEmpty_ThrowsArgumentException(string body)
    {
        //Act
        var sendAsync = async ()=> await _service.SendAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), body);

        //Assert
        var excpetion = await Assert.ThrowsAsync<ArgumentNullException>(sendAsync);
        Assert.Contains("body", excpetion.Message);
    }
    
    [Theory]
    [EmailServiceNullBodyData]
    public async Task SendAsync_BodyIsNullOrEmpty_SmtpClientShouldntBeCalled(string body)
    {
        //Act
        var sendAsync = async ()=> await _service.SendAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), body);

        //Assert
        _smtpClientMoq.VerifyNoOtherCalls();
    }

    [Fact]
    public async Task SendAsync_WhenCalled_SmtpSendShouldBeCalled_()
    {
        //Arrange 
        string from = "nikoo@gmail.com";
        string to ="nikoo2@gmail.com";
        string subject = "test";
        string body = "test";
        MailMessage mail = new(from, to, subject, body);
        
        //Act
        await _service.SendAsync(from, to, subject, body);

        //Assert
        _smtpClientMoq.Verify(smpt=> smpt.SendAsync(mail , new CancellationToken()));
    }
    
    [Fact]
    public async Task SendAsync_WhenCalled_SmtpSendShouldBeCalled()
    {
        //Arrange 
        string from = "nikoo@gmail.com";
        string to ="nikoo2@gmail.com";
        string subject = "test";
        string body = "test";

        //Act
        await _service.SendAsync(from, to, subject, body);

        //Assert
        _smtpClientMoq.Verify(smpt=> smpt.SendAsync(
            It.Is<MailMessage>(m=> m.From.Address.Equals(from) 
                                          && m.To.Any(t=> t.Address.Equals(to)
                                          && m.Body.Equals(body)
                                          && m.Subject.Equals(subject))) ,
            It.IsAny<CancellationToken>()));
    }
}