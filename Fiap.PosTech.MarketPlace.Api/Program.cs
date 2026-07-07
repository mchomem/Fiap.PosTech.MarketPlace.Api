var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    // Configuração da documentação
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Fiap.PosTech.MarketPlace API",
        Version = "v1",
        Description = "Documentação oficial dos endpoints."
    });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    options.IncludeXmlComments(xmlPath);
});

#region Services

builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IProductService, ProductService>();

#endregion

#region Repositories

/*
    Em projetos reais o repositório deve ser registrado como Scoped,
    mas como é uma versão em memória, estamos usando Singleton.
*/
builder.Services.AddSingleton<IProductMemoryRepository, ProductMemoryRepository>();

#endregion

#region Mapster

var config = TypeAdapterConfig.GlobalSettings;
ProfileMapping.RegisterMappings(config);
builder.Services.AddSingleton(config);
builder.Services.AddScoped<IMapper, ServiceMapper>();
builder.Services.AddMapster();

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Fiap.PosTech.MarketPlace.Api v1");
        options.RoutePrefix = "swagger";
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
await app.RunAsync();
