var builder = WebApplication.CreateBuilder(args);

const string toDoCorsPolicy = "_toDoCorsPolicy";

builder.Services.AddCors(options =>
{
    // TODO: Limit CORS to specific client URL 
    options.AddPolicy(toDoCorsPolicy,
        o => { o.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader(); });
});

builder.Services.AddControllers().AddFluentValidation();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddIPersistenceServices(builder.Configuration);

builder.Services.AddApplicationServices();

builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors(toDoCorsPolicy);

var env = builder.Environment;

app.UseMiddleware<ExceptionMiddleware>();

app.UseStatusCodePagesWithReExecute("/errors/{0}");

if (env.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.MapControllers();

// Migrate database at runtime
using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
var loggerFactory = services.GetRequiredService<ILoggerFactory>();

try
{
    var context = services.GetRequiredService<WhatToDoContext>();
    await context.Database.MigrateAsync();
}
catch (Exception ex)
{
    var logger = loggerFactory.CreateLogger<Program>();
    logger.LogError(ex, "An error occurred during migration");
}

await app.RunAsync();