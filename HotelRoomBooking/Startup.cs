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
                options.UseSqlServer(Configuration.GetConnectionString("LocalDB"), x => x.MigrationsAssembly("HotelRoomBooking"));
            });

            // Register all the services
            services.AddScoped<ITestHelper, TestHelper>();
            services.AddScoped<ITestRepository, TestRepository>();

            // Automapper
            services.AddAutoMapper(typeof(Startup));

            services.AddControllers();
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
