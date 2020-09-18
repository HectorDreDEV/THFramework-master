using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreData.DbContexts;
using CoreData.Entities.EfEntity;
using Framework.Framework.Repository;
using Framework.Framework.UnitOfWork;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Services.TestingSevices;

namespace THFramework
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<EFDbContext>(option => option.UseSqlServer("Server=STSPC-TAYNGUYEN;Database=StructrureDB;Trusted_Connection=True;"));
            services.AddTransient<IUnitOfWork<EFDbContext>, UnitOfWork<EFDbContext>>();
            services.AddTransient<IRepository<UserEntity>, EfRepository<UserEntity, EFDbContext>>();
            services.AddTransient<IUserService, UserService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
