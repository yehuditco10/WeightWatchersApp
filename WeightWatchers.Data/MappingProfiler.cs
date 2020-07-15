using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using WeightWatchers.Data.Entities;
using WeightWatchers.Services.Models;

namespace WeightWatchers.Data
{
    public class MappingProfiler:Profile
    {
        public MappingProfiler()
        {
           
            CreateMap<SubscriberModel, Subscriber>();
            CreateMap<CardModel, Card>();
            CreateMap<Card, CardModel>().ForMember(name => name.firstName, to => to.MapFrom(n => n.subscriber.firstName))
                .ForMember(name => name.lastName, to => to.MapFrom(n => n.subscriber.lastName)); ;
           
        }
    }
}
