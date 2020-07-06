using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using WeightWatchers.Api.DTO;
using WeightWatchers.Data;
using WeightWatchers.Data.Entities;
using WeightWatchers.Services;
using WeightWatchers.Services.Models;

namespace WeightWatchers.Api
{
    class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<SubscriberDTO, SubscriberModel>();
            CreateMap<CardDTO, CardModel>();
            CreateMap<SubscriberModel, SubscriberModel>();
            CreateMap<CardModel, Card>();
            CreateMap<Card, CardModel>();
            CreateMap<CardModel, CardDTO>();


        }
    }
}
