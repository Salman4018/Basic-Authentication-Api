using System.Reflection;
using Basic_Authentication_Api.Auth;
using Microsoft.AspNetCore.Authentication;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Implementing Basic Authentication
builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", 
        new OpenApiInfo
        {
            Title = "Basic Authentication Demo API", 
            Version = "v1",
            Contact = new OpenApiContact
            {
                Name = "Contact",
                Email = "contact@gmail.com",
                Url = new Uri("https://twitter.com/Contact")
            },
            License = new OpenApiLicense
            {
                Name = "License Information",
                Url = new Uri("https://example.com/license"),
            }
        }
    );

    option.AddSecurityDefinition("Basic", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter Credentials",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Basic"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Basic"
                }
            },
            new string[]{}
        }
    });

    // Set the comments path for the Swagger JSON and UI.
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    option.IncludeXmlComments(xmlPath);
});

builder.Services.AddAuthentication("BasicAuthentication")
    .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>
        ("BasicAuthentication", null);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//Implementing Basic Authentication
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endPoints =>
{
    endPoints.MapControllers();
});

app.Run();
