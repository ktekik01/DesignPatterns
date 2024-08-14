using System;

// Product
public class Pizza
{
    public string Dough { get; private set; }
    public string Sauce { get; private set; }
    public string Meat { get; private set; }

    public void SetDough(string dough)
    {
        Dough = dough;
    }

    public void SetSauce(string sauce)
    {
        Sauce = sauce;
    }

    public void SetMeat(string meat)
    {
        Meat = meat;
    }

    public void DisplayInfo()
    {
        Console.WriteLine("Pizza Configuration:");
        Console.WriteLine($"Dough: {Dough}");
        Console.WriteLine($"Sauce: {Sauce}");
        Console.WriteLine($"Meat: {Meat}\n");
    }
}

// Builder Interface
public interface IPizzaBuilder
{
    void BuildDough();
    void BuildSauce();
    void BuildMeat();
    Pizza GetPizza();
}

// Concrete Builder
public class HawaiianPizzaBuilder : IPizzaBuilder
{
    private Pizza _pizza = new Pizza();

    public void BuildDough()
    {
        _pizza.SetDough("Dough");
    }

    public void BuildSauce()
    {
        _pizza.SetSauce("Sauce");
    }

    public void BuildMeat()
    {
        _pizza.SetMeat("Meat");
    }

    public Pizza GetPizza()
    {
        return _pizza;
    }
}

// Director
public class PizzaDirector
{
    public void Construct(IPizzaBuilder pizzaBuilder)
    {
        pizzaBuilder.BuildDough();
        pizzaBuilder.BuildSauce();
        pizzaBuilder.BuildMeat();
    }
}

// Client
class Program
{
    static void Main(string[] args)
    {
        HawaiianPizzaBuilder pizzaBuilder = new HawaiianPizzaBuilder();
        PizzaDirector director = new PizzaDirector();

        director.Construct(pizzaBuilder);
        Pizza pizza = pizzaBuilder.GetPizza();

        pizza.DisplayInfo();
    }
}
