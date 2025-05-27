using System.Windows.Input;

namespace MikeyaWarehouse.Wpf.Commands.Abstract;

public interface ICommandFactory
{
    public T GetCommand<T>() where T : notnull, ICommand;
   
}
