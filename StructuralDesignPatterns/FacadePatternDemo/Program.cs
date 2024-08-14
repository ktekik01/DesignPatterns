using System;

// Subsystem 1
public class TV
{
    public void TurnOn()
    {
        Console.WriteLine("TV is now onn.");
    }

    public void TurnOff()
    {
        Console.WriteLine("TV is now Off.");
    }
}

// Subsystem 2
public class DVDPlayer
{
    public void Play()
    {
        Console.WriteLine("DVD Player is now playing.");
    }

    public void Stop()
    {
        Console.WriteLine("DVD Player has stopped.");
    }
}

// Subsystem 3
public class SoundSystem
{
    public void SetVolume(int level)
    {
        Console.WriteLine($"Sound System volume set to {level}.");
    }
}

// Facade
public class HomeTheaterFacade
{
    private TV tv;
    private DVDPlayer dvdPlayer;
    private SoundSystem soundSystem;

    public HomeTheaterFacade(TV tv, DVDPlayer dvdPlayer, SoundSystem soundSystem)
    {
        this.tv = tv;
        this.dvdPlayer = dvdPlayer;
        this.soundSystem = soundSystem;
    }

    public void WatchMovie()
    {
        tv.TurnOn();
        dvdPlayer.Play();
        soundSystem.SetVolume(5);
    }

    public void EndMovie()
    {
        Console.WriteLine("Shutting down the home theater.");
        dvdPlayer.Stop();
        tv.TurnOff();
    }
}

// Client
class Program
{
    static void Main()
    {
        // Create components
        TV tv = new TV();
        DVDPlayer dvdPlayer = new DVDPlayer();
        SoundSystem soundSystem = new SoundSystem();

        // Create facade
        HomeTheaterFacade homeTheater = new HomeTheaterFacade(tv, dvdPlayer, soundSystem);

        // Use the facade
        homeTheater.WatchMovie();
        homeTheater.EndMovie();
    }
}
