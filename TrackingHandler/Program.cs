using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using NServiceBus;
using Microsoft.Extensions.DependencyInjection;
using Tracking.Services;
using Tracking.Data;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using System.Configuration;

namespace TrackingHandler
{
    public class Program
    {
        static async Task Main()
        {
            Console.Title = "Tracking";

            var endpointConfiguration = new EndpointConfiguration("Tracking");

            endpointConfiguration.EnableOutbox();
            var connection = ConfigurationManager.AppSettings["WeightWatchersOutBoxConnection"];
            var persistence = endpointConfiguration.UsePersistence<SqlPersistence>();
            var subscriptions = persistence.SubscriptionSettings();
            subscriptions.CacheFor(TimeSpan.FromMinutes(1));
            persistence.SqlDialect<SqlDialect.MsSqlServer>();
            persistence.ConnectionBuilder(
                connectionBuilder: () =>
                {
                    return new SqlConnection(connection);
                });

            var transport = endpointConfiguration.UseTransport<RabbitMQTransport>();
            transport.UseConventionalRoutingTopology();
            transport.ConnectionString(ConfigurationManager.AppSettings["TransportConnection"]);
            endpointConfiguration.EnableInstallers();
            endpointConfiguration.AuditProcessedMessagesTo("audit");

            var recoverability = endpointConfiguration.Recoverability();
            recoverability.Delayed(
                customizations: delayed =>
                {
                    delayed.NumberOfRetries(2);
                    delayed.TimeIncrease(TimeSpan.FromMinutes(4));
                });

            recoverability.Immediate(
                customizations: immediate =>
                {
                    immediate.NumberOfRetries(1);

                });
            var conventions = endpointConfiguration.Conventions();
            conventions.DefiningCommandsAs(type => type.Namespace == "Messages.Commands");
            conventions.DefiningEventsAs(type => type.Namespace == "Messages.Events");

            var containerSettings = endpointConfiguration.UseContainer(new DefaultServiceProviderFactory());
            containerSettings.ServiceCollection.AddSingleton<ITrackingService, TrackingService>();
            containerSettings.ServiceCollection.AddScoped<ITrackingRepository, TrackingRepository>();
            //containerSettings.ServiceCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            containerSettings.ServiceCollection.AddDbContext<TrackingContext>(options =>
                        options.UseSqlServer(
                            ConfigurationManager.AppSettings["TrackingDBConnection"]));
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            containerSettings.ServiceCollection.AddSingleton(mapper);

            var endpointInstance = await NServiceBus.Endpoint.Start(endpointConfiguration)
                .ConfigureAwait(false);

            Console.WriteLine("Press Enter to exit.");
            Console.ReadLine();

            await endpointInstance.Stop()
                .ConfigureAwait(false);
        }
    }

    internal class MappingProfile : Profile
    {
        public MappingProfile()
        {

            {
                //  CreateMap<Tracking.Api.DTO.Tracking, Services.Models.Tracking>();
                CreateMap<Tracking.Services.Models.Tracking, Tracking.Data.Entities.Tracking>();
                CreateMap<Messages.Commands.AddTrack, Tracking.Services.Models.Tracking>();
            }
        }
    }
}


