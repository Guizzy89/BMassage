// ���������� ���������� � ��������� ������������
var builder = WebApplication.CreateBuilder(args);

// �������� ��������� MVC
builder.Services.AddControllersWithViews();

// ������ ����������
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    // ���� ����� �� Development, �������� ��������� ������
    app.UseExceptionHandler("/Home/Error");
    // ������������� ������� �������� ������������ �����������
    app.UseHsts();
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
