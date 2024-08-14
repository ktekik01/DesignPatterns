using System;

// Component
public interface IPizza
{
    string GetDescription();
    double GetCost();
}

// Concrete Component
public class PlainPizza : IPizza
{
    public string GetDescription()
    {
        return "Plain Pizza";
    }

    public double GetCost()
    {
        return 8.0;
    }
}

// Decorator
public abstract class PizzaDecorator : IPizza
{
    protected IPizza decoratedPizza;

    protected PizzaDecorator(IPizza decoratedPizza)
    {
        this.decoratedPizza = decoratedPizza;
    }

    public virtual string GetDescription()
    {
        return decoratedPizza.GetDescription();
    }

    public virtual double GetCost()
    {
        return decoratedPizza.GetCost();
    }
}

// Concrete Decorator for Cheese
public class CheeseDecorator : PizzaDecorator
{
    public CheeseDecorator(IPizza decoratedPizza) : base(decoratedPizza) { }

    public override string GetDescription()
    {
        return decoratedPizza.GetDescription() + ", Cheese";
    }

    public override double GetCost()
    {
        return decoratedPizza.GetCost() + 1.5;
    }
}

// Concrete Decorator for Olives
public class OlivesDecorator : PizzaDecorator
{
    public OlivesDecorator(IPizza decoratedPizza) : base(decoratedPizza) { }

    public override string GetDescription()
    {
        return decoratedPizza.GetDescription() + ", Olives";
    }

    public override double GetCost()
    {
        return decoratedPizza.GetCost() + 1.0;
    }
}

// Main Program
class Program
{
    static void Main()
    {
        // Plain Pizza
        IPizza pizza = new PlainPizza();
        Console.WriteLine("Description: " + pizza.GetDescription());
        Console.WriteLine("Cost: $" + pizza.GetCost());

        // Pizza with Cheese
        IPizza cheesePizza = new CheeseDecorator(new PlainPizza());
        Console.WriteLine("\nDescription: " + cheesePizza.GetDescription());
        Console.WriteLine("Cost: $" + cheesePizza.GetCost());

        // Pizza with Olives and Cheese
        IPizza olivesCheesePizza = new OlivesDecorator(new CheeseDecorator(new PlainPizza()));
        Console.WriteLine("\nDescription: " + olivesCheesePizza.GetDescription());
        Console.WriteLine("Cost: $" + olivesCheesePizza.GetCost());
    }
}
