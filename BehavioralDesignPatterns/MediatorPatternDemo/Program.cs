using System;

// Colleague Interface
public interface IAirplane
{
    void RequestTakeoff();
    void RequestLanding();
    void NotifyAirTrafficControl(string message);
}

// Concrete Colleague
public class CommercialAirplane : IAirplane
{
    private readonly IAirTrafficControlTower _mediator;

    public CommercialAirplane(IAirTrafficControlTower mediator)
    {
        _mediator = mediator;
    }

    public void RequestTakeoff()
    {
        _mediator.RequestTakeoff(this);
    }

    public void RequestLanding()
    {
        _mediator.RequestLanding(this);
    }

    public void NotifyAirTrafficControl(string message)
    {
        Console.WriteLine("Commercial Airplane: " + message);
    }
}

// Mediator Interface
public interface IAirTrafficControlTower
{
    void RequestTakeoff(IAirplane airplane);
    void RequestLanding(IAirplane airplane);
}

// Concrete Mediator
public class AirportControlTower : IAirTrafficControlTower
{
    public void RequestTakeoff(IAirplane airplane)
    {
        // Logic for coordinating takeoff
        airplane.NotifyAirTrafficControl("Requesting takeoff clearance.");
    }

    public void RequestLanding(IAirplane airplane)
    {
        // Logic for coordinating landing
        airplane.NotifyAirTrafficControl("Requesting landing clearance.");
    }
}

// Main class
public class MediatorAirplaneExample
{
    public static void Main(string[] args)
    {
        // Instantiate the Mediator (Airport Control Tower)
        IAirTrafficControlTower controlTower = new AirportControlTower();

        // Instantiate Concrete Colleagues (Commercial Airplanes)
        IAirplane airplane1 = new CommercialAirplane(controlTower);
        IAirplane airplane2 = new CommercialAirplane(controlTower);

        // Set up the association between Concrete Colleagues and the Mediator
        airplane1.RequestTakeoff();
        airplane2.RequestLanding();
        
    }
}
