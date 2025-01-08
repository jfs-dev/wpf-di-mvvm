using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using wpf_di_mvvm.Data;
using wpf_di_mvvm.Interfaces;
using wpf_di_mvvm.Models;
using wpf_di_mvvm.ViewModels;
using wpf_di_mvvm.Views;

namespace wpf_di_mvvm;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private readonly ServiceProvider _serviceProvider;

    public App()
    {
        var serviceCollection = new ServiceCollection();
        
        ConfigureServices(serviceCollection);
        
        _serviceProvider = serviceCollection.BuildServiceProvider();

        using var scope = _serviceProvider.CreateScope();
        
        var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

        dbContext.Customers.AddRange(
            new Customer { Name = "Peter Parker", Email = "peter.parker@marvel.com" },
            new Customer { Name = "Mary Jane", Email = "mary.jane@marvel.com" },
            new Customer { Name = "Ben Parker", Email = "ben.parker@marvel.com" }
        );

        dbContext.SaveChanges();
    }

    private void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseInMemoryDatabase("wpf-di-mvvm"));

        services.AddSingleton<IServiceProvider>(provider => _serviceProvider);
        services.AddSingleton<CustomerGridView>();
        
        services.AddTransient<ICustomerViewModel, CustomerViewModel>();
        services.AddTransient<CustomerActionView>();
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        var customerGridView = _serviceProvider.GetService<CustomerGridView>();
        customerGridView?.Show();

        base.OnStartup(e);
    }
}
