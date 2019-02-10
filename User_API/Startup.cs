using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using User_API.Models.Address.DAL;
using User_API.Models.AddressType.DAL;
using User_API.Models.CommunicationPreference.DAL;
using User_API.Models.ContactNumber.DAL;
using User_API.Models.Gender.DAL;
using User_API.Models.HomeLanguage.DAL;
using User_API.Models.Occupation.DAL;
using User_API.Models.OccupationalStatus.DAL;

namespace User_API
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
            services.AddTransient<IAddressDAL, AddressDAL>();
            services.AddTransient<IAddressTypeDAL, AddressTypeDAL>();
            services.AddTransient<ICommunicationPreferenceDAL, CommunicationPreferenceDAL>();
            services.AddTransient<IContactNumberDAL, ContactNumberDAL>();
            services.AddTransient<IGenderDAL, GenderDAL>();
            services.AddTransient<IHomeLanguageDAL, HomeLanguageDAL>();
            services.AddTransient<IOccupationDAL, OccupationDAL>();
            services.AddTransient<IOccupationalStatusDAL, OccupationalStatusDAL>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
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

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
