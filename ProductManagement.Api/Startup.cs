using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using ProductManagement.Api.Extensions;
using ProductManagement.Api.Model;
using ProductManagement.Api.Model.Campaign;
using ProductManagement.Api.Model.Order;
using ProductManagement.Api.Model.Product;
using ProductManagement.Api.Validation;
using ProductManagement.Business.Abstract;
using ProductManagement.Business.Concrete;
using ProductManagement.DataAccess.Abstract;
using ProductManagement.DataAccess.Concrete;
using ProductManagement.DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManagement.Api
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ProductManagement.Api", Version = "v1" });
            });


            services.AddDbContext<ApplicationDbContext>();

            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<ICampaignService, CampaignService>();
            services.AddScoped<ITimeService, TimeService>();

            services.AddScoped<IProductDal, ProductDal>();
            services.AddScoped<IOrderDal, OrderDal>();
            services.AddScoped<ICampaignDal, CampaignDal>();
            services.AddScoped<ITimeDal, TimeDal>();



            services.AddMvc()
                 .AddJsonOptions(i =>
                 {
                     i.JsonSerializerOptions.PropertyNamingPolicy = null;
                     i.JsonSerializerOptions.DictionaryKeyPolicy = null;
                     i.JsonSerializerOptions.WriteIndented = true;
                 })
                   .ConfigureApiBehaviorOptions(options =>
                   {
                       options.InvalidModelStateResponseFactory = c =>
                       {
                           var errors = string.Join('\n', c.ModelState.Values.Where(v => v.Errors.Count > 0)
                             .SelectMany(v => v.Errors)
                             .Select(v => v.ErrorMessage));

                           return new BadRequestObjectResult(new ResponseModel<string>
                           {
                               Success = false,
                               StatusCode = 400,
                               Message = errors,
                               Response = null
                           });
                       };
                   })
                 .AddFluentValidation();



            services.AddTransient<IValidator<CreateProductDto>, ProductValidator>();
            services.AddTransient<IValidator<CreateOrderDto>, OrderValidator>();
            services.AddTransient<IValidator<CreateCampaignDto>, CampaignValidator>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,ApplicationDbContext db)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ProductManagement.Api v1"));
            }

            db.Database.EnsureCreated();

            app.UseRouting();

            app.UseAuthorization();

            app.UseExceptionMiddleware();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
