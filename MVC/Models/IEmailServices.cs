using System.Collections.Generic;
using System.Threading.Tasks;

namespace MVC.Models
{
    public interface IEmailServices
    {
        //string GetEmailBody(string templateName);
        Task SendTestEmail(List<UserEmailOptions> userEmailOptions);
    }
}