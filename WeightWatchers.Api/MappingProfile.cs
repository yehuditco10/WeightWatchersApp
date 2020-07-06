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
            CreateMap<Card, CardDTO>().ForMember(name => name.firstName, card => card.MapFrom(c => c.Subscriber.firstName))
                .ForMember(name => name.lastName, card => card.MapFrom(c => c.Subscriber.lastName));
            CreateMap<CardDTO, Card>();
        }
    }
}
