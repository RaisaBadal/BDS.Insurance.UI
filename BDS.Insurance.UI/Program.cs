using BDS.Insurance.Core.DBContexti;
using BDS.Insurance.Core.Interfaces;
using BDS.Insurance.Core.Services;
using BDS.Insurance.Infrastructure.Repositories;
using BDS.Insurance.Presentation.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.


builder.Services.AddDbContext<DbBds>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("RaisasString"));
});

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddControllers();

builder.Services.AddScoped<ICar, CarService>();
builder.Services.AddScoped<ICarRepos, CarServiceRepos>();
builder.Services.AddScoped<IError, ErrorService>();
builder.Services.AddScoped<IErrorRepos, ErrorServiceRepos>();
builder.Services.AddScoped<ILog, LogService>();
builder.Services.AddScoped<IlogRepos, LogServiceRepos>();
builder.Services.AddScoped<IPolicy, PolicyService>();
builder.Services.AddScoped<IPolicyRepos, PolicyServiceRepos>();
builder.Services.AddScoped<IUser,UserService>();
builder.Services.AddScoped<IUserRepos, UserServiceRepos>();



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Your API", Version = "v1" });

    // Add JWT token configuration for Swagger
    var securityScheme = new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Description = "Please enter Token",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT"
    };

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "please enter token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        { new OpenApiSecurityScheme
        {
            Reference=new OpenApiReference
            {
                Type=ReferenceType.SecurityScheme,
                Id="Bearer"
            }
        }, new List<string>() }
    });
});

builder.Services.AddAuthentication(ops =>
{
    ops.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    ops.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(ops =>
{
    ops.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateActor = true,
        ValidateIssuer = true,
        ValidateAudience = true,
        RequireExpirationTime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = "http://localhost:52087",
        ValidAudience = "http://localhost:52087",
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("123dsasdsy76715265e726ghvshavd"))
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseAuthentication();

app.MapControllers();

app.Run();
