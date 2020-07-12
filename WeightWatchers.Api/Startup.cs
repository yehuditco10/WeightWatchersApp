using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WeightWatchers.Services;
using WeightWatchers.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using WeightWatchers.Api.Middleware;
using System.IO;
using System.Reflection;

namespace WeightWatchers.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddDbContext<WeightWatchersContext>(options =>
               options.UseSqlServer(
                   Configuration.GetConnectionString("weightWatchersConnection")));
          
            services.AddScoped<ISubscriberService, SubscriberService>();
            services.AddScoped<ISubscriberRepository, SubscriberRepository>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            // Auto Mapper Configurations
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
            services.AddSwaggerGen(setupAction =>
            {
                setupAction.SwaggerDoc("WeightWatchersOpenApiSpecification",
                    new Microsoft.OpenApi.Models.OpenApiInfo()
                    {
                        Title = "WeightWatchers",
                        Version = "1",
                        Description = "Through this api you can get the your Weight Watchers card",
                        Contact = new Microsoft.OpenApi.Models.OpenApiContact()
                        {
                            Name = "Yehudit Cohen & Batya Hartman",
                            Email = "cyehudit10@gmail.com"
                        }
                    });
                //var xmlCommentFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                //var xmlCommentFullPath = Path.Combine(AppContext.BaseDirectory, xmlCommentFile);
                //setupAction.IncludeXmlComments(xmlCommentFullPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("");

                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseMiddleware(typeof(ErrorHandlerMiddlware));

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        await context.Response.WriteAsync("Hello World!");
            //    });
            //});
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseSwagger();
            app.UseSwaggerUI(setupAction =>
            {
                setupAction.SwaggerEndpoint(
                    "/swagger/WeightWatchersOpenApiSpecification/swagger.json",
                    "WeightWatchers");
                setupAction.RoutePrefix = "";
            });
        }
    }
}
