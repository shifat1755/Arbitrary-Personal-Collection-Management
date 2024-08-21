using APCM.Data;
using APCM.Hubs;
using APCM.Services.CollectionService;
using APCM.Services.CommentService;
using APCM.Services.CommonService;
using APCM.Services.HomeService;
using APCM.Services.ItemService;
using APCM.Services.UserService;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("APCM")));
builder.Services.AddHttpContextAccessor();
builder.Services.AddAuthentication("cookie").AddCookie("cookie", config =>
{
    config.Cookie.Name = "demo"; config.ExpireTimeSpan = TimeSpan.FromDays(7); config.LoginPath = "/User/Login";
});
builder.Services.AddScoped<ICommonService, CommonService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ICollectionService, CollectionService>();
builder.Services.AddScoped<IHomeService, HomeService>();
builder.Services.AddScoped<IItemService, ItemService>();
builder.Services.AddScoped<ICommentService, CommentService>();

builder.Services.AddSignalR();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapHub<CommentHub>("/Home/Index");
});
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
