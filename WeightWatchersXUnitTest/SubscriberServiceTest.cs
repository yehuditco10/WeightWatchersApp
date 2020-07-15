using System;
using WeightWatchers.Data;
using WeightWatchers.Services;
using WeightWatchers.Services.Models;
using Xunit;

namespace WeightWatchersXUnitTest
{
    public class SubscriberServiceTest
    {
        [Fact]
        public async void SendEmail_emailSend_returnStatus200()
        {
            var subscriberService = new SubscriberService();
            var result =  subscriberService.SendEmail("brixbootcamp@gmail.com");
         
        }

        //[Fact]
        //public async void GetCardId_CardExists_returnSuscriberWithThisCardId()
        //{
        //    var subscriberService = new SubscriberService(
        //        new SubscriberRepository(
        //            new WeightWatchersContext
        //            (options =>
        //       options.UseSqlServer("Data Source =ILBHARTMANLT; Initial Catalog = weightWatchers; Integrated Security = True"))));
        //    var result = await subscriberService.GetByIdAsync(1);
        //    Assert.IsType<CardModel>(result);
        //    Assert.Equal<int>(1, result.id);
        //}
        
    }
}
