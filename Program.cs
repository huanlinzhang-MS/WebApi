using WebApi;
using WebApi.DataParser;
using WebApi.DataSource;
using WebApi.TestService;

var builder = WebApplication.CreateBuilder(args);

Environment.SetEnvironmentVariable("ConnectionString", "Endpoint=https://huanlin.azconfig.io;Id=a2Cy-la-s0:bjQWEzyHjycNTVhS10b1;Secret=ErWipxLduExiw/4WwrvqaKWc+4k6obuAzfnQupl/cJI=");

builder.Configuration.AddAzureAppConfiguration(options =>
{
    options.Connect(Environment.GetEnvironmentVariable("ConnectionString"))
           .Select("*") 
           .ConfigureRefresh(refreshOptions =>
           {
               refreshOptions.Register("test_Sentinel", refreshAll: true);
           })
           .GetRefresher();
});

// Add services to the container.
builder.Services.AddAzureAppConfiguration();
builder.Services.AddSingleton<ITestService, TestServiceImpl>();
builder.Services.AddSingleton(new DataParserManager());
builder.Services.AddSingleton(new DataSourceManager());
builder.Services.AddSingleton<QueryGlobalManager>();

builder.Services.AddControllers()
                .AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAzureAppConfiguration();

app.UseAuthorization();

app.MapControllers();

app.Run();
