using languages_api;

var builder = WebApplication.CreateBuilder(args);

var languageConfig = builder.Services.Configure<LanguageDatabaseSettings>(builder.Configuration.GetSection("LanguageDatabase"));

builder.Services.AddSingleton<LanguageService>();

builder.Services.AddControllers()
    .AddJsonOptions(
        options => options.JsonSerializerOptions.PropertyNamingPolicy = null);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
