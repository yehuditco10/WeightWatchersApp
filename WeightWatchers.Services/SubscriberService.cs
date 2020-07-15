using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WeightWatchers.Services.Models;
using System.Net;
using System.Net.Mail;
using System.Configuration;

namespace WeightWatchers.Services
{
    public class SubscriberService : ISubscriberService
    {
        private readonly ISubscriberRepository _subscriberRepository;

        public SubscriberService(ISubscriberRepository subscriberRepository)
        {
            _subscriberRepository = subscriberRepository;
        }

        public SubscriberService()
        {
        }

        public async Task<bool> IsEmailExistsAsync(string email)
        {
            return await _subscriberRepository.IsEmailExistsAsync(email);
        }

        public async Task<bool> AddAsync(SubscriberModel subsciber, float height)
        {
            var isExsits = _subscriberRepository.IsEmailExistsAsync(subsciber.email);

            if (isExsits.Result == false)
            {
                await _subscriberRepository.AddAsync(subsciber, height);
                return true;
            }
            throw new Exception("this email exists, try another");
        }

        public async Task<int> LoginAsync(string email, string password)
        {
            return await _subscriberRepository.LoginAsync(email, password);
        }
        public Task<CardModel> GetByIdAsync(int cardId)
        {
            var card = _subscriberRepository.GetByIdAsync(cardId);
            return card;
        }

        public async Task<int> UpdateCard(int cardId, float weight)
        {
            CardModel card = await IsCardExists(cardId);
            if (card != null)
            {
                CardModel cardUpdated = new CardModel()
                {
                    id = cardId,
                    BMI = weight / (card.height * card.height),
                    weight = weight,
                    updateDate = DateTime.Today
                };
                return await _subscriberRepository.UpdateCard(cardUpdated);
            }
            return -1;
        }
        public async Task<CardModel> IsCardExists(int cardId)
        {

            return await _subscriberRepository.isCardExists(cardId);
        }
        public async Task SendEmail(string email)
        {
            string subject = "SubjectVerifyEmail";

            string body = "Hello " + email + "your verify number is 1234";
            await SendEmail(email, subject, body);
        }
        private async Task SendEmail(string emailTo, string subject, string body)
        {
            try
            {
                string fromMail = "brixbootcamp@gmail.com";
               // string fromMail = ConfigurationManager.AppSettings["WeightWatcherEmailAddress"];
                string fromPassword = "brix2020";
                //string fromPassword = ConfigurationManager.AppSettings["WeightWatcherEmailAddress"];
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                mail.From = new MailAddress(fromMail);
                mail.To.Add(emailTo);
                mail.Subject = subject;
                mail.Body = body;
                SmtpServer.Port = 25;
                SmtpServer.Credentials = new System.Net.NetworkCredential(fromMail, fromPassword);
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(mail);
                
            }


            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
