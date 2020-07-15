using System;
using Abp.Domain.Uow;
using Moq;
using WeightWatchers.Services;
using WeightWatchers.Services.Models;
using Xunit;

namespace SubscriberServiceXUnitTest
{
    public class SubscriberServiceUnitTest
    {
        [testMethod]
        public void AddAsync_WithEmailAlreadyExist_ThrowException()
        {
             SubscriberModel subscriberModel = new SubscriberModel();
            var mockUoW = new Mock<IUnitOfWork>();
            SubscriberService subscriberService = new SubscriberService(mockUoW.Object);
            subscriberService.AddAsync
        }
    }
}
