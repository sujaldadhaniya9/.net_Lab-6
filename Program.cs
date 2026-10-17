var builder = WebApplication.CreateBuilder(args);

// Add MVC (controllers + views) to the app
builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

// Routing: opening the site root goes straight to GadgetController -> Index
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Gadget}/{action=Index}/{id?}");

app.Run();
