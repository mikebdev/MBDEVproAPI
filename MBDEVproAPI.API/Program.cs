var builder = WebApplication.CreateBuilder(args);
var logger = new LoggerConfiguration()
                    .ReadFrom.Configuration(builder.Configuration)
                    .Enrich.FromLogContext()
                    .CreateLogger();
builder.Host.UseSerilog(logger);




//DATABASE CONNECTION
builder.Services.AddDbContext<MBDEVproAPIDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// SERVICES
builder.Services.AddTransient<ICustomerService, CustomerService>();

// REPOSITORIES
builder.Services.AddTransient<ICustomerRepository, CustomerRepository>();

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();


// Register the Swagger generator; custom details
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "MBDEVproAPI v1 | .NET CORE 10",
        Description = "manages business customers",
        TermsOfService = new Uri("https://images3.alphacoders.com/967/thumb-1920-96797.jpg"),
        Contact = new OpenApiContact
        {
            Name = "MBDEVproAPI Administrator",
            Email = "MBDEVproAPIAdministrator@encom.com",
            Url = new Uri("https://m.media-amazon.com/images/I/71rVfyrUzPL._SL1101_.jpg"),
        },
        License = new OpenApiLicense
        {
            Name = "No license",
            Url = new Uri("https://example.com/license"),
        }
    });
});

//ADD: API security and authentication (OAuth2, OpenID Connect, JWT)

var app = builder.Build();

app.UseSerilogRequestLogging();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.MapOpenApi(); // Expose the OpenAPI JSON endpoint
    //app.MapScalarApiReference(); // Map the Scalar UI endpoint

    app.MapOpenApi();
    app.MapScalarApiReference();
    //app.MapScalarApiReference(options =>
    //{
    //    options.Title = "MBDEVproAPI v1 .NET CORE 10";
    //    options.WithTheme(ScalarTheme.Moon); // Use a specific theme
    //    options.ForceDarkMode(); // Force dark mode
    //});

    // Automatically redirect to Scalar documentation
    //app.MapGet("/", () => Results.Redirect("/scalar"));

    Log.Information("MBDEVproAPI: (Development Environment)");
    app.UseDeveloperExceptionPage();
}



if (app.Environment.EnvironmentName == "Test")
{
    Log.Information("MBDEVproAPI: Test Environment)");
}

if (app.Environment.EnvironmentName == "Uat")
{
    Log.Information("MBDEVproAPI: Uat Environment)");
}

if (app.Environment.EnvironmentName == "Production")
{
    Log.Information("MBDEVproAPI: Production Environment)");
}

//if (app.Environment.IsDevelopment() || app.Environment.EnvironmentName == "Test")
//{
//    //app.UseSwagger();
//    //app.UseSwaggerUI(c =>
//    //{
//    //    //c.SwaggerEndpoint("/MBDEVproAPI/swagger/v1/swagger.json", "MBDEVproAPI v1 .NET CORE 10");
//    //    c.SwaggerEndpoint("../swagger/v1/swagger.json", "MBDEVproAPI v1 .NET CORE 10");
//    //    // ENDPOINTS: https://localhost:7092/swagger/index.html
//    //    // JSON: https://localhost:7092/swagger/v1/swagger.json
//    //});
//}

Log.Information("MBDEVproAPI: (Development Environment)");

app.UseSerilogRequestLogging(); // Add Serilog request logging middleware   

app.UseDeveloperExceptionPage(); // For local only, can change later for testing and production environments, can also add custom error handling middleware for production environment.

//Middleware
app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();
