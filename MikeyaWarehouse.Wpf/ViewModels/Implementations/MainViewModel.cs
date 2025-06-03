using MikeyaWarehouse.Contracts.DTO;
using MikeyaWarehouse.Wpf.Commands;
using MikeyaWarehouse.Wpf.Commands.Abstract;
using MikeyaWarehouse.Wpf.Models.Domain;
using MikeyaWarehouse.Wpf.ViewModels.Interfaces;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MikeyaWarehouse.Wpf.ViewModels.Implementations;

public class MainViewModel
    : ViewModelBase, IMainViewModel
{
    public static string Title => "Mikeya Warehouse Application";

    private readonly ICommandFactory _commandFactory;
    private readonly LoadShipmentDataCommand _loadShipmentDataCommand;
    private readonly LoadProductDataCommand _loadProductDataCommand;
    private readonly LoadPalletDataCommand _loadPalletDataCommand;

    private ObservableCollection<PalletModel> _pallets = [];
    private ObservableCollection<ProductModel> _products = [];
    private ObservableCollection<ShipmentModel> _shipments = [];
    
    public MainViewModel(ICommandFactory commandFactory)
    {
        _commandFactory = commandFactory;
        
        _loadPalletDataCommand = _commandFactory.GetCommand<LoadPalletDataCommand>();
        _loadPalletDataCommand.CommandCompleted += OnPalletsLoaded;

        _loadProductDataCommand = _commandFactory.GetCommand<LoadProductDataCommand>();
        _loadProductDataCommand.CommandCompleted += OnProductsLoaded;


        _loadShipmentDataCommand = _commandFactory.GetCommand<LoadShipmentDataCommand>();
        _loadShipmentDataCommand.CommandCompleted += OnShipmentsLoaded;
    }
    
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
    public ObservableCollection<ShipmentModel> Shipments
    {
        get => _shipments;
        set
        {
            _shipments = value;
            OnPropertyChanged();
        }
    }
   
    public ICommand LoadPallets => _loadPalletDataCommand;
    public ICommand LoadProducts => _loadProductDataCommand;
    public ICommand LoadShipments => _loadShipmentDataCommand;
    
    
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
    private void OnShipmentsLoaded(object? sender, CommandResult<LoadShipmentDataCommandResult> result)
    {
        if (result.Status == CommandStatus.SUCCESS && result.Value is LoadShipmentDataCommandResult data)
        {
            Shipments = [.. data.Shipments];
        }
    }
}
