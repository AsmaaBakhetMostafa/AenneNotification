using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NotificationApp.Hubs;
using Serilog;

namespace NotificationApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            // Init Serilog configuration
            Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(configuration).CreateLogger();
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
          services.AddCors();
            //services.AddCors(options => options.AddPolicy("CorsPolicy", builder =>
            //{
            //    builder
            //        .AllowAnyMethod()
            //        .AllowAnyHeader()
            //        .WithOrigins("http://localhost:6715")
            //        .DisallowCredentials();
            //}));
            services.AddCors(options => options.AddPolicy("CorsPolicy",
 builder =>
 {
     builder.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin()
            //.WithOrigins("*")
            //.WithMethods("*")
            //.WithHeaders("*")


            .AllowCredentials();
 }));

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.AddMvc();

            services.AddSignalR();
            services.AddSignalR(config => config.EnableDetailedErrors = true);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            // logging
            loggerFactory.AddSerilog();
   
            //app.UseCors(builder => builder.AllowCredentials().AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin().Build());
            app.UseCors("CorsPolicy");

         //app.UseCors(builder => builder
         //     .AllowAnyOrigin()
         //     .AllowAnyMethod()
         //     .AllowAnyHeader()
         //     .AllowCredentials()

         //     );
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseSignalR(config => config.MapHub<ChatHub>("/chatHub"));
            app.UseSignalR(config => config.MapHub<TripNotificationHub>("/TripNotification"));
            app.UseSignalR(config => config.MapHub<NotificationHub>("/AdminNotification"));


            //app.UseSignalR(routes =>
            //{
            //    routes.MapHub<ChatHub>("/chatHub");
            //});

            app.UseMvc();
        }
    }
}
