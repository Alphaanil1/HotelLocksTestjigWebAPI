using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using HotelLockVave.DAL.Context;
using HotelLockVave.BusinessObjects.Models;
using HotelLockVave.DAL.Repositories.InterfaceRepositories;
using HotelLockVave.BLL;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using HotelLockVave.DAL.Repositories;
using Microsoft.AspNetCore.Http;
using System.Net;
using HotelLockWebAPI.APIAuthentication;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using System.IO;


namespace HotelLocksWebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {
                var Key = Encoding.UTF8.GetBytes(Configuration["JWT:JWTKey"]);
                o.SaveToken = true;
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Configuration["JWT:JWTIssuer"],
                    ValidAudience = Configuration["JWT:JWTAudience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Key)
                };

            });
            // Unauthorized (401) MiddleWare
            ////backgroud services
           
            services.AddSingleton<IJWTManagerRepository, JWTManagerRepository>();
            
            services.AddSingleton<ITokenBlacklistService, TokenBlacklistService>();
            services.AddCors();
            services.AddControllers();



            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "HotelLockWebAPI", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer"
                });


                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                    {
                        new OpenApiSecurityScheme{
                        Reference=new OpenApiReference{
                            Type=ReferenceType.SecurityScheme,
                            Id="Bearer"
                         }
                       },
                       new string[]{}
                    }
                    });
            });

            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new OpenApiInfo { Title = "HotelLockWebAPI", Version = "v1" });
            //});

            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v2", new OpenApiInfo { Title = "HotelLockWebAPI", Version = "v2" });
            //});

            services.AddCors(o => o.AddPolicy("CorsPolicy", builder =>
            {

                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();

            }));

            // // services.AddDbContext<HRMSContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DevConnection")));
            services.Configure<EmailSettings>(Configuration.GetSection("EmailSettings"));
            services.AddTransient<IEmailService, EmailService>();
            //services.AddCors();
            // Default Policy
            //services.AddCors(options =>
            //{
            //    options.AddDefaultPolicy(
            //        builder =>
            //        {
            //            builder.WithOrigins("http://64.202.191.110:2241", "http://localhost:4200", "http://64.202.191.110:4122")
            //                                .AllowAnyHeader()
            //                                .AllowAnyMethod();
            //        });
            //});
            // Add Firebase Admin SDK initialization here
            //FirebaseApp.Create(new AppOptions()
            //{
            //    Credential = GoogleCredential.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "hotel-lock-vave-sdk-firebase-adminsdk-yr2e2-caedabaf32.json")),
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            // Only allow TLS 1.2
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;


            app.UseCors(options =>
            options.WithOrigins("http://localhost:4200", "http://64.202.191.110:4078")
            .AllowAnyMethod()
            .AllowAnyHeader()
            );


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseCors("CorsPolicy");
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "HotelLockWebAPI v1"));
            }

            app.Use(async (context, next) =>
            {
                await next();

                if (context.Response.StatusCode == (int)HttpStatusCode.Unauthorized)
                {
                    string retrunvalue = "{\"result\": null,\"responseCode\": 401,\"message\": \"Failure\",\"userMessage\": \"Token Validation Has Failed. Request Access Denied\"}";
                    await context.Response.WriteAsync(retrunvalue);
                }
            });


            app.UseHttpsRedirection();
            // app.UseMiddleware<AuthenticationMiddleware>();
            //app.UseMiddleware<TokenBlacklistMiddleware>();
            

            app.UseRouting();

            //// global cors policy
            //app.UseCors(x => x
            //    .AllowAnyMethod()
            //    .AllowAnyHeader()
            //    .SetIsOriginAllowed(origin => true) // allow any origin
            //    .AllowCredentials()); // allow credentials

            app.UseAuthentication(); // This need to be added	
            app.UseAuthorization();
           
            
            //app.UseTokenBlacklist();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }

    }
}
