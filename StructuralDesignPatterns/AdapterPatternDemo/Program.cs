using System;

// Target Interface
interface IMediaPlayer
{
    void PlayMedia(string fileName);
}

// Adaptee
class LegacyAudioPlayer
{
    public void PlayAudio(string fileName)
    {
        Console.WriteLine($"Playing audio file: {fileName}");
    }
}

// Adapter
class MediaPlayerAdapter : IMediaPlayer
{
    private readonly LegacyAudioPlayer _legacyAudioPlayer;

    public MediaPlayerAdapter(LegacyAudioPlayer legacyAudioPlayer)
    {
        _legacyAudioPlayer = legacyAudioPlayer;
    }

    public void PlayMedia(string fileName)
    {
        _legacyAudioPlayer.PlayAudio(fileName);
    }
}

// Client Code
class Program
{
    static void PlayMediaFile(IMediaPlayer mediaPlayer, string fileName)
    {
        mediaPlayer.PlayMedia(fileName);
    }

    static void Main(string[] args)
    {
        // Using the Adapter
        LegacyAudioPlayer legacyAudioPlayer = new LegacyAudioPlayer();
        IMediaPlayer adapter = new MediaPlayerAdapter(legacyAudioPlayer);
        PlayMediaFile(adapter, "song.mp3"); // Example audio file
    }
}
