using Financeiro.App.Client.Services;
using Financeiro.App.Components;
using Financeiro.App.Components.Account;
using Financeiro.App.Endpoints;
using Financeiro.Application;
using Financeiro.Infrastructure;
using Financeiro.Infrastructure.Data;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<IdentityUserAccessor>();
builder.Services.AddScoped<IdentityRedirectManager>();
builder.Services.AddScoped<AuthenticationStateProvider, PersistingRevalidatingAuthenticationStateProvider>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = IdentityConstants.ApplicationScheme;
    options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
})
.AddIdentityCookies();


builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);    

builder.Services.AddHttpClient<DashboardService>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration["ApplicationUrl"]
        ?? "https://localhost:5001");
});


builder.Services.AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();


app.MapDashboardEndpoints();
app.MapIncomeEndpoints();
app.MapExpenseEndpoints();


app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(Financeiro.App.Client._Imports).Assembly);

app.MapAdditionalIdentityEndpoints();

app.Run();
