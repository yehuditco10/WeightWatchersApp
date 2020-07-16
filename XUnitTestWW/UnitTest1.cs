using System;
using Moq;
using NUnit.Framework.Internal;
using WeightWatchers.Services;
using WeightWatchers.Services.Models;
using Xunit;

namespace XUnitTestWW
{
    public class UnitTest1
    {
        [Fact]
        public async System.Threading.Tasks.Task GetCardIdAsync_CardExists_returnSuscriberWithThisCardIdAsync()
        {
            var mock = new Mock<ISubscriberRepository>();
            var card = new CardModel() { id = 1, weight = 200 };
            mock.Setup(p => p.GetByIdAsync(1).Result).Returns(card);
            SubscriberService subscriberService = new SubscriberService(mock.Object);
            CardModel result = subscriberService.GetByIdAsync(1).Result;
            Assert.Equal(card, result);
        }

        [Fact]
        public void GetCardId_CardExists_returnSuscriberWithThisCardId()
        {
            var mock = new Mock<ISubscriberRepository>();
            var card = new CardModel() { id = 1, weight = 200 };
            mock.Setup(p => p.GetById(1)).Returns(card);
            SubscriberService subscriberService = new SubscriberService(mock.Object);
            CardModel result = subscriberService.GetById(1);
            Assert.Equal(card, result);
        }
    }
}

