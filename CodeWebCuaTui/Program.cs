using CodeWebCuaTui.IServices;
using CodeWebCuaTui.Services;
using Microsoft.CodeAnalysis.Options;

var builder = WebApplication.CreateBuilder(args);
//chang
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<ICategoryServices, CategoryServices>();
builder.Services.AddTransient<IColorServices, ColorServices>();
builder.Services.AddTransient<IImageServices, ImagesServices>();
builder.Services.AddTransient<ISupplierServices, SupplierServices>();
builder.Services.AddTransient<IProductServices, ProductServices>();
builder.Services.AddSession(option => { option.IdleTimeout = TimeSpan.FromMinutes(30); });
var app = builder.Build();
////Khai báo sử dụng Session với thời gian timeout là 30 giây
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
//app.UseSession();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
