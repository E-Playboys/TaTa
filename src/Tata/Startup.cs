using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Tata.Data;
using Tata.Services;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Tata.Areas.Backend.Models.Order;
using Tata.Areas.Backend.Models.Product;
using Tata.Entities;
using TaTa.DataAccess;
using TaTa.DataAccess.Uow;
using TaTa.DataAccess.Entities;
using Microsoft.AspNetCore.Http;
using Tata.Models.ProductModels;

namespace Tata
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsDevelopment())
            {
                // For more details on using the user secret store see http://go.microsoft.com/fwlink/?LinkID=532709
                builder.AddUserSecrets();

                // This will push telemetry data through Application Insights pipeline faster, allowing you to view results immediately.
                builder.AddApplicationInsightsSettings(developerMode: true);
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();

            ConfigureAutoMapper();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddApplicationInsightsTelemetry(Configuration);

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            // Config application authentication
            services.AddIdentity<User, IdentityRole>(options => 
            {
                // Password settings
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = false;

                // Lockout settings
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                options.Lockout.MaxFailedAccessAttempts = 10;

                // Cookie settings
                options.Cookies.ApplicationCookie.ExpireTimeSpan = TimeSpan.FromDays(150);
                options.Cookies.ApplicationCookie.LoginPath = "/Account/Login";
                options.Cookies.ApplicationCookie.LogoutPath = "/Account/Logoff";

                // User settings
                options.User.RequireUniqueEmail = true;

            }).AddEntityFrameworkStores<ApplicationDbContext>()
              .AddDefaultTokenProviders();

            services.AddDataAccess<ApplicationDbContext>();

            services.AddMvc(options =>
            {
                //options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
            });

            // Add session
            services.AddDistributedMemoryCache();
            services.AddSession();

            // Add application services.
            services.AddTransient<IUowProvider, UowProvider>();
            services.AddTransient<IEmailSender, AuthMessageSender>();
            services.AddTransient<ISmsSender, AuthMessageSender>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseApplicationInsightsRequestTelemetry();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseApplicationInsightsExceptionTelemetry();

            app.UseStaticFiles();

            app.UseIdentity();

            // Add external authentication middleware below. To configure them please see http://go.microsoft.com/fwlink/?LinkID=532715
            app.UseCookieAuthentication(new CookieAuthenticationOptions()
            {
                AuthenticationScheme = "TaTaHosingAuthentication",
                AccessDeniedPath = "/Home/AccessDenied",
                LoginPath = "/Account/Login",
                LogoutPath = "/Account/Logoff",
                AutomaticAuthenticate = true,
                AutomaticChallenge = true
            });

            app.UseSession();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "areaRoute",
                    template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        private void ConfigureAutoMapper()
        {
            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Product, ProductModel>();
                cfg.CreateMap<ProductModel, Product>();

                cfg.CreateMap<Product, ProductDetailsViewModel>();
                cfg.CreateMap<ProductDetailsViewModel, Product>();

                cfg.CreateMap<ProductPropertyGroup, ProductPropertyGroupModel>();
                cfg.CreateMap<ProductPropertyGroupModel, ProductPropertyGroup>();

                cfg.CreateMap<ProductPropertyGroupValue, ProductPropertyGroupValueModel>();
                cfg.CreateMap<ProductPropertyGroupValueModel, ProductPropertyGroupValue>();

                cfg.CreateMap<ProductProperty, ProductPropertyModel>();
                cfg.CreateMap<ProductPropertyModel, ProductProperty>();

                cfg.CreateMap<ProductPrice, ProductPriceModel>().ForMember(x => x.ProductName, o => o.MapFrom(m => m.Product.Name));
                cfg.CreateMap<ProductPriceModel, ProductPrice>();

                cfg.CreateMap<ProductCategory, ProductCategoryModel>();
                cfg.CreateMap<ProductCategoryModel, ProductCategory>();

                cfg.CreateMap<Order, OrderModel>();
                cfg.CreateMap<OrderModel, Order>();

                cfg.CreateMap<OrderItem, OrderItemModel>();
                cfg.CreateMap<OrderItemModel, OrderItem>();

                cfg.CreateMap<Billing, BillingModel>();
                cfg.CreateMap<BillingModel, Billing>();
            });
        }

        public class ApplicationDbContextFactory : IDbContextFactory<ApplicationDbContext>
        {
            public ApplicationDbContext Create(DbContextFactoryOptions options)
            {
                var config = new ConfigurationBuilder()
                                .SetBasePath(options.ContentRootPath)
                                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                                .AddJsonFile($"appsettings.{options.EnvironmentName}.json", optional: true);
                var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
                var configuration = config.Build();

                builder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
                return new ApplicationDbContext(builder.Options);
            }
        }
    }
}
