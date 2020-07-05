using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using WeightWatchers.Api.DTO;
using WeightWatchers.Data;
using WeightWatchers.Services;
using WeightWatchers.Services.Models;

namespace WeightWatchers.Api
{
    class MappingProfile: Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<Subscriber, SubscriberDTO>();
            CreateMap<SubscriberDTO, Subscriber>();
            CreateMap<Card, CardDTO>();
            CreateMap<CardDTO, Card>();
        }
    }
}
