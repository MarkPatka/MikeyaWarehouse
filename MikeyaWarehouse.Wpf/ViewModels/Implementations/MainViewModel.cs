using MikeyaWarehouse.Application.Common.Persistence;
using MikeyaWarehouse.Domain.PalletAggregate;
using MikeyaWarehouse.Wpf.ViewModels.Interfaces;
using System.Collections.ObjectModel;

namespace MikeyaWarehouse.Wpf.ViewModels.Implementations;

public class MainViewModel 
    : ViewModelBase, IMainViewModel
{
    private readonly IPalletsRepository _palletRepository;

    public MainViewModel(IPalletsRepository palletRepository)
    {
        _palletRepository = palletRepository;
    }

    public string Title => "Mikeya Warehouse Application";
    public ObservableCollection<Pallet> Pallets { get; set; } = [];















}
