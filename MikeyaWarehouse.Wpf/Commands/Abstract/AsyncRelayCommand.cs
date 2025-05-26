using System.Windows.Input;

namespace MikeyaWarehouse.Wpf.Commands.Abstract;

public abstract class AsyncRelayCommand<TResult> : ICommand
{
    private bool _isExecuting;
    private CommandResult<TResult> commandResult = null!;

    public abstract Func<object?, Task> ExecuteCommand { get; }
    public abstract Predicate<object?>? CanExecuteCommand { get; }
    public abstract Action<Exception>? ErrorHandler { get; }

    protected CommandResult<TResult> CommandResult 
    { 
        get => commandResult; 
        set => commandResult = value; 
    }

    public event EventHandler? CanExecuteChanged
    {
        add { CommandManager.RequerySuggested += value; }
        remove { CommandManager.RequerySuggested -= value; }
    }
    
    public bool CanExecute(object? parameter = null)
    {
        if (_isExecuting) return false;

        return CanExecuteCommand == null || CanExecuteCommand(parameter);
    }

    public async void Execute(object? parameter = null)
    {
        await ExecuteAsync(parameter)
            .ConfigureAwait(false);
    }

    private async Task ExecuteAsync(object? parameter = null)
    {
        try
        {
            if (!CanExecute(parameter)) return;

            _isExecuting = true;
            RaiseCanExecuteChanged();

            await ExecuteCommand(parameter)
                .ConfigureAwait(false);
        }
        catch (Exception ex) when (ErrorHandler is not null)
        {
            ErrorHandler(ex);
        }
        finally
        {
            _isExecuting = false;
            RaiseCanExecuteChanged();
        }
    }

    private static void RaiseCanExecuteChanged() => 
        CommandManager.InvalidateRequerySuggested();


}
