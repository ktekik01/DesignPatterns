using System;
using System.Collections.Generic;

// Observer Interface
public interface IObserver
{
    void Update(string news);
}

// Subject Interface
public interface ISubject
{
    void AddObserver(IObserver observer);
    void RemoveObserver(IObserver observer);
    void NotifyObservers();
}

// Concrete Subject Class
public class NewsAgency : ISubject
{
    private List<IObserver> observers = new List<IObserver>();
    private string latestNews;

    public void AddObserver(IObserver observer)
    {
        observers.Add(observer);
    }

    public void RemoveObserver(IObserver observer)
    {
        observers.Remove(observer);
    }

    public void NotifyObservers()
    {
        foreach (IObserver observer in observers)
        {
            observer.Update(latestNews);
        }
    }

    public void SetLatestNews(string news)
    {
        this.latestNews = news;
        NotifyObservers();
    }
}

// Concrete Observer Class
public class NewsChannel : IObserver
{
    private string news;

    public void Update(string news)
    {
        this.news = news;
        Display();
    }

    private void Display()
    {
        Console.WriteLine("News Channel: Breaking news - " + news);
    }
}

// Concrete Observer Class
public class NewsWebsite : IObserver
{
    private string news;

    public void Update(string news)
    {
        this.news = news;
        Display();
    }

    private void Display()
    {
        Console.WriteLine("News Website: Latest update - " + news);
    }
}

// Usage Class
public class NewsAgencyApp
{
    public static void Main(string[] args)
    {
        NewsAgency newsAgency = new NewsAgency();

        IObserver newsChannel = new NewsChannel();
        IObserver newsWebsite = new NewsWebsite();

        newsAgency.AddObserver(newsChannel);
        newsAgency.AddObserver(newsWebsite);

        // Simulating news updates
        newsAgency.SetLatestNews("New policy changes announced.");
        newsAgency.SetLatestNews("Süper Lig season started.");

        newsAgency.RemoveObserver(newsChannel);

        newsAgency.SetLatestNews("Galatasaray will be the champion.");

        
    }
}
