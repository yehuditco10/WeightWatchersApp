using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeightWatchers.Data;
using WeightWatchers.Data.Entities;
using WeightWatchers.Services;
using WeightWatchers.Services.Models;

namespace WeightWatcher.UnitTests
{
    [TestClass]
    public class SubscriberServiceUnitTest
    {
        
        [TestMethod]
        public async void GetCardId_CardExists_returnSuscriberWithThisCardId()
        {
            var subscriberService = new SubscriberService(
                new SubscriberRepository(
                    new WeightWatchersContext()));
            CardModel result =await subscriberService.GetByIdAsync(1);
            Assert.Equals(1, result.id);
        }
    }
}
