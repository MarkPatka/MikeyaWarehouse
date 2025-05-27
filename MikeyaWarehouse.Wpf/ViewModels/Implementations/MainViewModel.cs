using MikeyaWarehouse.Application.Common.Persistence;
using MikeyaWarehouse.Domain.PalletAggregate;
using MikeyaWarehouse.Wpf.Commands;
using MikeyaWarehouse.Wpf.Commands.Abstract;
using MikeyaWarehouse.Wpf.Models;
using MikeyaWarehouse.Wpf.ViewModels.Interfaces;
using Sprache;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MikeyaWarehouse.Wpf.ViewModels.Implementations;

public class MainViewModel
    : ViewModelBase, IMainViewModel
{
    private readonly ICommandFactory _commandFactory;
    private readonly LoadPalletDataCommand _loadPalletDataCommand;
    private readonly LoadProductDataCommand _loadProductDataCommand;
    
    private ObservableCollection<PalletModel> _pallets = [];
    private ObservableCollection<ProductModel> _products = [];

    public MainViewModel(
        ICommandFactory commandFactory)
    {
        _commandFactory = commandFactory;
        
        _loadPalletDataCommand = _commandFactory.GetCommand<LoadPalletDataCommand>();
        _loadPalletDataCommand.CommandCompleted += OnPalletsLoaded;

        _loadProductDataCommand = _commandFactory.GetCommand<LoadProductDataCommand>();
        _loadProductDataCommand.CommandCompleted += OnProductsLoaded;

    }

    public string Title => "Mikeya Warehouse Application";
    public ObservableCollection<PalletModel> Pallets
    {
        get => _pallets;
        set
        {
            _pallets = value;
            OnPropertyChanged();
        }
    }
    public ObservableCollection<ProductModel> Products
    {
        get => _products;
        set
        {
            _products = value;
            OnPropertyChanged();
        }
    }
    public ICommand LoadPallets => _loadPalletDataCommand;
    public ICommand LoadProducts => _loadProductDataCommand;

    private void OnPalletsLoaded(object? sender, CommandResult<LoadPalletDataCommandResult> result)
    {
        if (result.Status == CommandStatus.SUCCESS && result.Value is LoadPalletDataCommandResult data)
        {
            Pallets = [.. data.Pallets.Select(p => new PalletModel(p))];
        }
    }
    private void OnProductsLoaded(object? sender, CommandResult<LoadProductDataCommandResult> result)
    {
        if (result.Status == CommandStatus.SUCCESS && result.Value is LoadProductDataCommandResult data)
        {
            Products = [.. data.Products.Select(p => new ProductModel(p))];
        }
    }














}
