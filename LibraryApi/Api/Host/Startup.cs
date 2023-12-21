﻿using DatabaseModel;
using DomainService.Exceptions;
using DomainService.Operations;
using Host.Middlewares;
using Microsoft.EntityFrameworkCore;

namespace Host
{
    public class Startup
    {
        private readonly IConfiguration configuration;
        private readonly IWebHostEnvironment env;

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            this.configuration = configuration;
            this.env = env;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            #region Api

            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            #endregion

            #region EntityFramework

            string connectionString = configuration.GetValue<string>("EntityFramework:ConnectionString");
            services.AddDbContext<MainDbContext>(opt => opt.UseSqlServer(connectionString));

            HibernatingRhinos.Profiler.Appender.EntityFramework.EntityFrameworkProfiler.Initialize();

            #endregion

            #region Cors

            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            #endregion

            #region Registrations

            services.AddTransient<CategoryOperations>();
            services.AddTransient<BookOperations>();
            services.AddTransient<AuthorOperations>();
            services.AddTransient<CustomerOperations>();
            services.AddTransient<RezervationOperations>();
            services.AddTransient<BookAuthorsOperations>();
            services.AddTransient<BookCategoriesOperations>();


            #endregion
        }

        public void Configure(WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseMiddleware<ExceptionMiddleware>();

            app.UseCors("MyPolicy");

            app.UseStaticFiles();

            app.UseRouting();

            app.MapControllers();
        }
    }
}