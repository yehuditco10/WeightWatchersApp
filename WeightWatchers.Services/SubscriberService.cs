﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WeightWatchers.Services.Models;

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

    }
}
