using api_pospizzeria.Features.FAccess;
using api_pospizzeria.Features.FCli1;
using api_pospizzeria.Features.FOcli;
using api_pospizzeria.Features.FOdr1;
using api_pospizzeria.Features.FOinv;
using api_pospizzeria.Features.FOodr;
using api_pospizzeria.Features.FOpct;
using api_pospizzeria.Features.FOpmt;
using api_pospizzeria.Features.FOprt;
using api_pospizzeria.Features.FOrol;
using api_pospizzeria.Features.FOusr;
using api_pospizzeria.Features.Services;
using api_pospizzeria.Infrastructure.Databases.DB01_pos_pizzeria;
using api_pospizzeria.Infrastructure.Middlewares;
using api_pospizzeria.Mappings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var MyCors = "MyCors";

//Politicas
builder.Services.AddControllers(options =>
{
    var policy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();
    options.Filters.Add(new AuthorizeFilter(policy));
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();

//Configurar origenes de accesos
builder.Services.AddCors(options =>
{
    options.AddPolicy(MyCors, builder2 =>
    {
        builder2.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
    });
});

//Configuracion a servidor de SQL Server
builder.Services.AddDbContext<DB01_ApiContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("ConnectionSQL_pos_pizzeria")
    ));

// Add services to the container.
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddScoped<IAccessService, AccessService>();
builder.Services.AddScoped<GenerateToken>();
builder.Services.AddScoped<ValidateToken>();
builder.Services.AddScoped<ClaimFromToken>();
builder.Services.AddScoped<PasswordService>();
builder.Services.AddTransient<IOrolService, OrolService>();
builder.Services.AddTransient<IOusrService, OusrService>();
builder.Services.AddTransient<IOpctService, OpctService>();
builder.Services.AddTransient<IOpmtService, OpmtService>();
builder.Services.AddTransient<IOprtService, OprtService>();
builder.Services.AddTransient<IOcliService, OcliService>();
builder.Services.AddTransient<ICli1Service, Cli1Service>();
builder.Services.AddTransient<IOodrService, OodrService>();
builder.Services.AddTransient<IOdr1Service, Odr1Service>();
builder.Services.AddTransient<IOinvService, OinvService>();

// Configure JWT authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"])),
        ValidateIssuer = false,
        ValidateAudience = false
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

app.UseCors("MyCors");

app.UseMiddleware<CustomExceptionMiddleware>();

app.UseAuthentication();

app.UseMiddleware<ExtractClaim>();

app.UseAuthorization();

app.MapControllers();

app.Run();
