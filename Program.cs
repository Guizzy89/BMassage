// ���������� ���������� � ��������� ������������
using BMassage.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// �������� ��������� MVC
builder.Services.AddControllersWithViews();

// ����������� ��������� ���� ������
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// ������ ����������
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    // ���� ����� �� Development, �������� ��������� ������
    app.UseExceptionHandler("/Home/Error");
    // ������������� ������� �������� ������������ �����������
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
}

// ������������ HTTPS ���������������
app.UseHttpsRedirection();

// ������������ ����������� �����
app.UseStaticFiles();

// ��������� ������� �������������
app.UseRouting();

// ����������� ��������� MVC
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// �������� ���-����������
app.Run();
