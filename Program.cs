// Приложение начинается с настройки конфигурации
var builder = WebApplication.CreateBuilder(args);

// Включаем поддержку MVC
builder.Services.AddControllersWithViews();

// Строим приложение
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    // Если среда не Development, включаем обработку ошибок
    app.UseExceptionHandler("/Home/Error");
    // Устанавливаем строгую политику безопасности содержимого
    app.UseHsts();
}

// Использовать HTTPS перенаправления
app.UseHttpsRedirection();

// Поддерживаем статические файлы
app.UseStaticFiles();

// Запускаем систему маршрутизации
app.UseRouting();

// Регистрация маршрутов MVC
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Стартуем веб-приложение
app.Run();
