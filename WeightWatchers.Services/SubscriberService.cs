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
            var subscriber = _subscriberRepository.GetByIdAsync(cardId);
            return subscriber;
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
        public async Task sendEmail(string email)
        {
            var fromAddress = new MailAddress(
                    ConfigurationManager.AppSettings["WeightWatcherEmailAddress"]);
            var toAddress = new MailAddress(email);
            //const??
            string fromPassword = ConfigurationManager.AppSettings["WeightWatcherEmailAddress"];
            string subject = ConfigurationManager.AppSettings["SubjectVerifyEmail"];
            //todo -
            string body = "Hello "+email +"your verify number is 1234";
            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 578,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }

        }
    }
}
