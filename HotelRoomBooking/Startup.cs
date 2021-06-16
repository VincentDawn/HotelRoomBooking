using HotelRoomBookingBLL.Helpers;
using HotelRoomBookingBLL.IHelpers;
using HotelRoomBookingDAL.IRepository;
using HotelRoomBookingDAL.Repository;
using HotelRoomCodeFirstDb;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace HotelRoomBooking
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
            services.AddDbContext<HotelBookingDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("HotelDB"), x => x.MigrationsAssembly("HotelRoomBooking"));
            });

            // Register all the services
            services.AddScoped<IBookingHelper, BookingHelper>();
            services.AddScoped<IHotelHelper, BookingHelper>();
            services.AddScoped<IRoomHelper, BookingHelper>();
            services.AddScoped<ITestHelper, TestHelper>();


            services.AddScoped<IBookingRepository, BookingRepository>();
            services.AddScoped<IHotelRepository, HotelRepository>();
            services.AddScoped<IRoomRepository, RoomRepository>();
            services.AddScoped<ITestRepository, TestRepository>();

            // Automapper
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            // Swagger
            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, HotelBookingDbContext dbContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Migrate on startup
            dbContext.Database.Migrate();

            // Swagger
            app.UseSwagger();

            app.UseSwaggerUI(x =>
            {
                x.SwaggerEndpoint("/swagger/v1/swagger.json", "HotelBooking API");
                x.RoutePrefix = string.Empty; // so it loads on index instead of /swagger
            });

            //app.UseHttpsRedirection();

            app.UseRouting();

            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
