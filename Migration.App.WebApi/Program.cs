using Migration.App.Infrastructure.Extensions;
using Migration.App.WebApi.Extensions;
using Migration.App.WebApi.Filters;
using Migration.App.WebApi.Middleware;

// configure services
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .ConfigureApiBehaviorOptions(opt =>
    {
        opt.SuppressModelStateInvalidFilter = true;
    });

builder.Services.AddMvcCore(opt =>
{
    opt.Filters.Add(typeof(ModelStateValidationActionFilter));
});

builder.Services.AddRouting(opt =>
{
    opt.LowercaseUrls = true;
    opt.LowercaseQueryStrings = true;
})
.AddRepositories()
.AddSwaggerServiceConfig()
.AddConfigurationOptions(builder.Configuration)
.AddFluentMigrationToApp(builder.Configuration);


// configure app
var app = builder.Build();

app.AddSwaggerApplicationConfig();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.UseMiddleware<ErrorHandlerMiddleware>();

app.Run();
