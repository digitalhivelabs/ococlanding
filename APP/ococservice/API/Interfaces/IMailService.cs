using API.Data;

namespace API.Interfaces;

public interface IMailService
{
    bool SendMail(MailData mailData);
}
