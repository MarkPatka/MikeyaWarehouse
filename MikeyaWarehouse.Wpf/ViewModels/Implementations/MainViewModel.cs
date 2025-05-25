using MikeyaWarehouse.Application.Common.Persistence;
using MikeyaWarehouse.Wpf.ViewModels.Interfaces;

namespace MikeyaWarehouse.Wpf.ViewModels.Implementations;

public class MainViewModel 
    : ViewModelBase, IMainViewModel, IDisposable
{
    private readonly IPalletsRepository _palletRepository;

    public MainViewModel(IPalletsRepository palletRepository)
    {
        _palletRepository = palletRepository;
    }


    public string Title => "Mikeya Warehouse Application";





    public void Dispose() { }
}
