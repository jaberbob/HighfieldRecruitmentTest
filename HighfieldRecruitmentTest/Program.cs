using HighfieldRecruitmentTest.BL;
using HighfieldRecruitmentTest.Models.Dto;
using HighfieldRecruitmentTest.Models.Entities;
using HighfieldRecruitmentTest.Repos;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

builder.Services.AddSingleton<IDataProvider<UserEntity>>(s => new UserRepo());
builder.Services.AddSingleton<IBusinessLogic<ResponseDto, UserEntity>>(s => new RecruitmentTestBl());

builder.Services.AddHttpContextAccessor();
builder.Services.Configure<ForwardedHeadersOptions>(options =>
{
    options.ForwardedHeaders =
        ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
});

// Swagger UI
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "HighfieldRecruitmentTest API",
        Description = "An example WebApi for a coding test."
    });

    c.IncludeXmlComments(Path.Combine(System.AppContext.BaseDirectory, "HighfieldRecruitmentTest.xml"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "HighfieldRecruitmentTest");
});

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
