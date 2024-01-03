using Microsoft.AspNetCore.Identity;
using SimpleEcommerce.Api;
using SimpleEcommerce.Application;
using SimpleEcommerce.Domain.Entities;
using SimpleEcommerce.Infrastructure;
using SimpleEcommerce.Infrastructure.Helpers;
using SimpleEcommerce.Infrastructure.Seeding;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddApiService().AddInfrastructureRegistration(builder.Configuration).AddApplicationServices();

var app = builder.Build();
using (var Scope = app.Services.CreateScope())
{
    var UserManger = Scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
    var RoleManger = Scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

    await new SeedinitialData(RoleManger, UserManger).SeedData();
}

app.UseStaticFiles();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();