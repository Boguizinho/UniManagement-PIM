var builder = WebApplication.CreateBuilder(args);

// Adicionar serviços ao contêiner.
builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

// LINHA IMPORTANTE 1: Habilita o uso de arquivos padrão como index.html
app.UseDefaultFiles();

// LINHA IMPORTANTE 2: Habilita o serviço de arquivos estáticos (da pasta wwwroot)
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// A linha abaixo foi removida para que o index.html seja a prioridade.
// app.MapControllerRoute(
//     name: "default",
//     pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();