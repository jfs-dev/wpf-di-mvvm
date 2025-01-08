using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using wpf_di_mvvm.Data;
using wpf_di_mvvm.Models;
using wpf_di_mvvm.Interfaces;

namespace wpf_di_mvvm.ViewModels;

public partial class CustomerViewModel (AppDbContext dbContext) : ICustomerViewModel
{
    public ObservableCollection<Customer> Customers { get ; set ; } = [];

    [RelayCommand]
    public void GetAll()
    {
        Customers.Clear();

        foreach (var item in dbContext.Customers.OrderBy(x => x.Id).ToList())
        {
            Customers.Add(item);
        }
    }
}
