using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using wpf_di_mvvm.Interfaces;

namespace wpf_di_mvvm.Views;

/// <summary>
/// Interaction logic for CustomerGridView.xaml
/// </summary>
public partial class CustomerGridView : Window
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ICustomerViewModel _customerViewModel;

    public CustomerGridView(IServiceProvider serviceProvider, ICustomerViewModel customerViewModel)
    {
        InitializeComponent();

        _serviceProvider = serviceProvider;
        _customerViewModel = customerViewModel;

        DataContext = _customerViewModel;
    }

    private void RemoteDesktopButton_Click(object sender, RoutedEventArgs e) =>
        LoadCustomerActionView();

    private void EmailButton_Click(object sender, RoutedEventArgs e) =>
        LoadCustomerActionView();

    private void CheckBoldButton_Click(object sender, RoutedEventArgs e) =>
        LoadCustomerActionView();

    private void LoadCustomerActionView()
    {
        var customerActionView = _serviceProvider.GetService<CustomerActionView>();
        customerActionView?.ShowDialog() ;
    }
}
