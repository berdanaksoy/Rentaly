using Rentaly.BusinessLayer.Container;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRentalyServices(builder.Configuration);

builder.Services.AddControllersWithViews(options =>
{
    options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true;

    options.ModelBindingMessageProvider
        .SetValueMustNotBeNullAccessor(_ => "Bu alan boş bırakılamaz.");
    options.ModelBindingMessageProvider
        .SetAttemptedValueIsInvalidAccessor((value, field) => $"'{value}' geçerli bir değer değil.");
    options.ModelBindingMessageProvider
        .SetValueIsInvalidAccessor(value => $"'{value}' geçersiz.");
    options.ModelBindingMessageProvider
        .SetMissingBindRequiredValueAccessor(field => $"{field} alanı gönderilmedi.");
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();