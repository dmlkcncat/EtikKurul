using Business.Abstract;
using Business.Concrete;
using Core.Services;
using Core.Settings;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI;

namespace WebAPP
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
            services.AddControllers().AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            var key = "D2E2fc3TH2HN5K6PbNluKFDJ6RJjSYS9mYsCMSKvnDGcSfnLXSioZB6IdfymCuG5";
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            services.AddSingleton<IJWTAuthenticationManager>(new JWTAuthenticationManager(key));

            services.AddSingleton<IApplicantUserService, ApplicantUserManager>();
            services.AddSingleton<IApplicantUserDal, ApplicantUserDal>();

            services.AddSingleton<IApplicationService, ApplicationManager>();
            services.AddSingleton<IApplicationDal, ApplicationDal>();

            services.AddSingleton<IApplicationFormService, ApplicationFormManager>();
            services.AddSingleton<IApplicationFormDal, ApplicationFormDal>();

            services.AddSingleton<IApplicationQualificationService, ApplicationQualificationManager>();
            services.AddSingleton<IApplicationQualificationDal, ApplicationQualificationDal>();

            services.AddSingleton<IApplicationStatusService, ApplicationStatusManager>();
            services.AddSingleton<IApplicationStatusDal, ApplicationStatusDal>();

            services.AddSingleton<IAsistantInvestigatorService, AsistantInvestigatorManager>();
            services.AddSingleton<IAsistantInvestigatorDal, AsistantInvestigatorDal>();

            services.AddSingleton<IDocumentFileService, DocumentFileManager>();
            services.AddSingleton<IDocumentFileDal, DocumentFileDal>();

            services.AddSingleton<IFormService, FormManager>();
            services.AddSingleton<IFormDal, FormDal>();

            services.AddSingleton<IUpdateApplicationService, UpdateApplicationManager>();
            services.AddSingleton<IUpdateApplicationDal, UpdateApplicationDal>();

            services.AddSingleton<IUnderTakingFormService, UnderTakingFormManager>();
            services.AddSingleton<IUnderTakingFormDal, UnderTakingFormDal>();

            services.AddSingleton<IRoleService, RoleManager>();
            services.AddSingleton<IRoleDal, RoleDal>();

            services.AddSingleton<IUserService, UserManager>();
            services.AddSingleton<IUserDal, UserDal>();

            services.AddSingleton<IRedApplicationService, RedApplicationManager>();
            services.AddSingleton<IRedApplicationDal, RedApplicationDal>();

            services.Configure<MailSettings>(Configuration.GetSection("MailSettings"));
            services.AddTransient<IMailService, MailService>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebAPP", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPP v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors(x => x
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowAnyMethod()
                    .AllowAnyOrigin()
            );

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
