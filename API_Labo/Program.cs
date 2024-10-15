using API_Labo.Controllers;
using API_Labo.Tools;
using BLL_Labo.Interfaces;
using BLL_Labo.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace API_Labo
{
    public class Program {
        public static void Main(string[] args) {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<DatabaseContext, DatabaseContext>();
            builder.Services.AddScoped<IVenteService, VenteService>();
            builder.Services.AddScoped<IPretService, PretService>();
            builder.Services.AddScoped<IUtilisateurService, UtilisateurService>();
            builder.Services.AddScoped<JwtGenerator>();


            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(
                    options => {
                        options.TokenValidationParameters = new TokenValidationParameters() {
                            ValidateIssuerSigningKey = true,
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtGenerator.secretKey)),
                            ValidateLifetime = true,
                            ValidateIssuer = true,
                            ValidIssuer = "monapi.com",
                            ValidateAudience = false,
                        };
                    }
                );

            builder.Services.AddAuthorization(options => {
                options.AddPolicy("adminRequired", policy => policy.RequireRole("Admin"));
                options.AddPolicy("userRequired", policy => policy.RequireAuthenticatedUser());
            });

            builder.Services.AddCors(options => options.AddPolicy("MyPolicy",
                o => o.AllowCredentials()
                      .WithOrigins("https://localhost:7041")
                      .AllowAnyHeader()
                      .AllowAnyMethod()));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment()) {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            // OBLIGATOIREMENT DANS CE SENS
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseCors("MyPolicy");
            //app.UseCors(o => o.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin());

            app.MapControllers();

            app.Run();
        }
    }
}
