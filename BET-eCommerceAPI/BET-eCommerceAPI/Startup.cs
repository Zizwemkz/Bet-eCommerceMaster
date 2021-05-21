using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using BET_eCommerceAPI.Authentication;
using BET_eCommerceAPI.Interface;
using BET_eCommerceAPI.Models;
using BET_eCommerceAPI.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace BET_eCommerceAPI
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddDbContext<ApplicationDbContext>(option => option.UseSqlServer(Configuration.GetConnectionString("ConString")));


            //For Identity
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

        
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<IOrderItemService, OrderItemService>();
            services.AddTransient<IItemService, ItemService>();
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IAuthService, AuthService>();

            services.AddTransient<IDepartmentService, DepartmentService>();
            services.AddTransient<ICartService, CartService>();
            services.AddTransient<ICartItemService, CartItemService>();


        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

         
            app.UseMvc();
        }
    }
}
