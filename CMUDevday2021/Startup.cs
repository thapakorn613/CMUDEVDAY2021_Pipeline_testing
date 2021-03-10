using CMUDevday2021.Model;
using CMUDevday2021.Model.entity;
using CMUDevday2021.Model.Interface;
using CMUDevday2021.Model.Repository;
using CMUDevday2021.Model.Repository.Mock;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMUDevday2021
{
    public class Startup
    {
        private IWebHostEnvironment webHostEnvironment;
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            webHostEnvironment = env;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddScoped<IUserRepository, UserRepository>();
            if (webHostEnvironment.IsEnvironment("test"))
            {
                services.AddDbContext<UserContext>(options => options.UseInMemoryDatabase(databaseName: "UserContext").ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning)));
                services.AddScoped<IAccountRepository, AccountRepositoryMock>();

               
            }
            else
            {
                services.AddDbContext<UserContext>(options => options.UseInMemoryDatabase(databaseName: "UserContext").ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning)));
                services.AddScoped<IAccountRepository, AccountRepository>();
            }
            services.AddControllers(options =>
            {
                options.InputFormatters.Insert(0, new ITSCInputFormatter());
                foreach (var inputFormatter in options.InputFormatters.OfType<ITSCInputFormatter>().Where(_ => _.SupportedMediaTypes.Count == 0))
                {
                }
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, UserContext userContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            userContext.Database.EnsureCreated();
            if (webHostEnvironment.IsEnvironment("test"))
            {
                User user1 = new User();
                user1.UserId = 1;
                user1.UserName = "User1";
                user1.Account = "User1@cmu.ac.th";
                user1.Menus = userContext.Menu.OrderBy(o => o.MenuId).ToList();
                userContext.User.Add(user1);

                User user2 = new User();
                user2.UserId = 2;
                user2.UserName = "User2";
                user2.Account = "User2@cmu.ac.th";
                user2.Menus = userContext.Menu.Where(w => w.MenuId != 1 && w.MenuId != 2).OrderBy(o => o.MenuId).ToList();
                userContext.User.Add(user2);


                userContext.SaveChanges();
            }
        }
    }
}
