//using Microsoft.EntityFrameworkCore;
////using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Moq;
//using WeightWatchers.Data;
//using WeightWatchers.Data.Entities;
//using WeightWatchers.Services.Models;
//using WeightWatchersXUnitTest.Extensions;
//using Xunit;

//namespace WeightWatchersXUnitTest
//{
//    public class SubscriberServiceTest
//    {
//        private SubscriberRepository _repository;
//        private Mock<DbSet<Subscriber>> _mockSubscribers;
//        private Mock<DbSet<Card>> _mockCards;
//        [Fact]
//        //[TestInitialize]
//        public void TestInitialize()
//        {
//            _mockSubscribers = new Mock<DbSet<Subscriber>>();
//            _mockCards = new Mock<DbSet<Card>>();
//            var mockContext = new Mock<WeightWatchersContext>();

//            mockContext.SetupGet(c => c.Subscribers).Returns(_mockSubscribers.Object);
//            mockContext.SetupGet(c => c.Cards).Returns(_mockCards.Object);

//            _repository = new SubscriberRepository(mockContext.Object);
//        }
//        [Fact]
//        public void GetCardId_CardExists_returnSuscriberWithThisCardId()
//        {
//            var card = new Card() { id = 1, weight = 200, BMI = 3 };

//            _mockCards.SetSource(new[] { card });

//            var cards = _repository.GetByIdAsync(1);
//            Assert.IsType<CardModel>(cards);
//            Assert.Equal(1, cards.Id);
//            //Assert.IsInstanceOfType(cards, typeof(CardModel));
//            //Assert.AreEqual(1, cards.Id);
//        }
//    }
//}
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WeightWatchers.Services;
using WeightWatchers.Services.Models;

namespace WeightWatchersXUnitTest
{
    [TestClass]
    public class SubscriberServiceTest
    {
        [TestMethod]
        public void GetCardId_CardExists_returnSuscriberWithThisCardId()
        {
            var mock = new Mock<ISubscriberRepository>();
            var card = new CardModel() { id = 1, weight = 200 };
             mock.Setup(p => p.GetById(1)).Returns(card);
            SubscriberService subscriberService = new SubscriberService(mock.Object);
            var result = subscriberService.GetByIdAsync(1);
            Assert.AreEqual(card, result);
        }
    }
}
