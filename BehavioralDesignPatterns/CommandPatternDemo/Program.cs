using System;

// Command interface
public interface ICommand
{
    void Execute();
}

// Concrete command for turning a device on
public class TurnOnCommand : ICommand
{
    private readonly IDevice _device;

    public TurnOnCommand(IDevice device)
    {
        _device = device;
    }

    public void Execute()
    {
        _device.TurnOn();
    }
}

// Concrete command for turning a device off
public class TurnOffCommand : ICommand
{
    private readonly IDevice _device;

    public TurnOffCommand(IDevice device)
    {
        _device = device;
    }

    public void Execute()
    {
        _device.TurnOff();
    }
}

// Concrete command for adjusting the volume of a stereo
public class AdjustVolumeCommand : ICommand
{
    private readonly IStereo _stereo;

    public AdjustVolumeCommand(IStereo stereo)
    {
        _stereo = stereo;
    }

    public void Execute()
    {
        _stereo.AdjustVolume();
    }
}

// Concrete command for changing the channel of a TV
public class ChangeChannelCommand : ICommand
{
    private readonly ITv _tv;

    public ChangeChannelCommand(ITv tv)
    {
        _tv = tv;
    }

    public void Execute()
    {
        _tv.ChangeChannel();
    }
}

// Receiver interface
public interface IDevice
{
    void TurnOn();
    void TurnOff();
}

// Receiver interface for TV
public interface ITv : IDevice
{
    void ChangeChannel();
}

// Receiver interface for Stereo
public interface IStereo : IDevice
{
    void AdjustVolume();
}

// Concrete receiver for a TV
public class Tv : ITv
{
    public void TurnOn()
    {
        Console.WriteLine("TV is now on");
    }

    public void TurnOff()
    {
        Console.WriteLine("TV is now off");
    }

    public void ChangeChannel()
    {
        Console.WriteLine("Channel changed");
    }
}

// Concrete receiver for a stereo
public class Stereo : IStereo
{
    public void TurnOn()
    {
        Console.WriteLine("Stereo is now on");
    }

    public void TurnOff()
    {
        Console.WriteLine("Stereo is now off");
    }

    public void AdjustVolume()
    {
        Console.WriteLine("Volume adjusted");
    }
}

// Invoker
public class RemoteControl
{
    private ICommand _command;

    public void SetCommand(ICommand command)
    {
        _command = command;
    }

    public void PressButton()
    {
        _command.Execute();
    }
}

// Example usage
public class CommandPatternExample
{
    public static void Main()
    {
        // Create devices
        ITv tv = new Tv();
        IStereo stereo = new Stereo();

        // Create command objects
        ICommand turnOnTvCommand = new TurnOnCommand(tv);
        ICommand turnOffTvCommand = new TurnOffCommand(tv);
        ICommand adjustVolumeStereoCommand = new AdjustVolumeCommand(stereo);
        ICommand changeChannelTvCommand = new ChangeChannelCommand(tv);

        // Create remote control
        RemoteControl remote = new RemoteControl();

        // Set and execute commands
        remote.SetCommand(turnOnTvCommand);
        remote.PressButton();

        remote.SetCommand(adjustVolumeStereoCommand);
        remote.PressButton();

        remote.SetCommand(changeChannelTvCommand);
        remote.PressButton(); 

        remote.SetCommand(turnOffTvCommand);
        remote.PressButton(); 
    }
}
