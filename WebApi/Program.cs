using Microsoft.Extensions.Options;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers().AddNewtonsoftJson(Options => 
Options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(options =>
{
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
}
);

var app = builder.Build();

if(app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
app.UseSwagger();
app.UseSwaggerUI();
// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
