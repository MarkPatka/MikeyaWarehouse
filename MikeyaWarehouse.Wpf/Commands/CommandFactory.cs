using Microsoft.Extensions.DependencyInjection;
using MikeyaWarehouse.Wpf.Commands.Abstract;
using System.Windows.Input;

namespace MikeyaWarehouse.Wpf.Commands;

public class CommandFactory(IServiceProvider serviceProvider) : ICommandFactory
{
    private readonly IServiceProvider _serviceProvider = serviceProvider;

    public T GetCommand<T>() where T : notnull, ICommand
    {
        var service = _serviceProvider.GetRequiredService<T>();
        return service;
    }
}
