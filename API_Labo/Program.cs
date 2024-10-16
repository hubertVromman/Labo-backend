using API_Labo.Controllers;
using API_Labo.Tools;
using BLL_Labo.Interfaces;
using BLL_Labo.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace API_Labo {
    public class Program {
        public static void Main(string[] args) {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(setup => {
                // Include 'SecurityScheme' to use JWT Authentication
                var jwtSecurityScheme = new OpenApiSecurityScheme {
                    BearerFormat = "JWT",
                    Name = "JWT Authentication",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = JwtBearerDefaults.AuthenticationScheme,
                    Description = "Put **_ONLY_** your JWT Bearer token on textbox below!",

                    Reference = new OpenApiReference {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme
                    }
                };

                setup.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);

                setup.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    { jwtSecurityScheme, Array.Empty<string>() }
                });

            });

            builder.Services.AddScoped<DatabaseContext>();
            builder.Services.AddScoped<JwtGenerator>();

            builder.Services.AddScoped<IVenteService, VenteService>();
            builder.Services.AddScoped<IPretService, PretService>();
            builder.Services.AddScoped<IAuteurService, AuteurService>();
            builder.Services.AddScoped<IUtilisateurService, UtilisateurService>();
            builder.Services.AddScoped<IBibliothequeService, BibliothequeService>();
            builder.Services.AddScoped<ILivreService, LivreService>();

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
                options.AddPolicy("AdminRequired", policy => policy.RequireRole("Admin"));
                options.AddPolicy("EmployeeRequired", policy => policy.RequireRole("Admin", "Employee"));
                options.AddPolicy("UserRequired", policy => policy.RequireAuthenticatedUser());
            });

            builder.Services.AddCors(options => options.AddPolicy("CorsPolicy",
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

            app.UseCors("CorsPolicy");
            //app.UseCors(o => o.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin());

            if (app.Environment.IsDevelopment())
                app.MapControllers().AllowAnonymous();
            else
                app.MapControllers();

            app.Run();
        }
    }
}
