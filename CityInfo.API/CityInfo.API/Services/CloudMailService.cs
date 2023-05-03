namespace CityInfo.API.Services
{
    public class CloudMailService : IMailService
    {
        private readonly string _mailTo = string.Empty;
        private readonly string _mailFrom = string.Empty;

        public CloudMailService(IConfiguration configuration)
        {
            _mailTo = configuration["mailSettings:mailToAddress"];
            _mailFrom = configuration["mailSettings:mailFromAddress"];
        }

        public void Send(string subject, string message)
        {
            //Mimic of sending a mail (output to console window)
            Console.WriteLine($"Mail from {_mailFrom} to {_mailTo}, with " +
                $"{nameof(CloudMailService)}.");

            Console.WriteLine($"{subject}");
            Console.WriteLine($"{message}");
        }
    }
}
