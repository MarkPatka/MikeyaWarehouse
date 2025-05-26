using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MikeyaWarehouse.Wpf.Commands.Abstract;

public class CommandResult<TValue> 
    : INotifyPropertyChanged
{
    private TValue? _value;
    private Exception? _error;

    public TValue? Value 
    { 
        get => _value;
        set
        {
            if (!Equals(_value, value))
            {
                _value = value; 
                OnPropertyChanged(nameof(Value));
            }
        }
    }
    public Exception? Error
    {
        get => _error;
        set
        {
            if (_error != value)
            {
                _error = value;
                OnPropertyChanged();
            }
        }
    }
    public CommandStatus Status { get; set; } = CommandStatus.DEFAULT;

    public CommandResult(TValue value)
    {
        _value = value;
        Status = CommandStatus.SUCCESS;
    }
    public CommandResult(Exception error)
    {
        Error = error;
        Status = CommandStatus.ERROR;
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
