using System;

// Abstraction in Bridge Pattern
abstract class SmartDevice
{
    protected IManufacturingProcess process1;
    protected IManufacturingProcess process2;

    protected SmartDevice(IManufacturingProcess process1, IManufacturingProcess process2)
    {
        this.process1 = process1;
        this.process2 = process2;
    }

    public abstract void Manufacture();
}

// Refined Abstraction 1
class Smartphone : SmartDevice
{
    public Smartphone(IManufacturingProcess process1, IManufacturingProcess process2)
        : base(process1, process2)
    {
    }

    public override void Manufacture()
    {
        Console.Write("Smartphone ");
        process1.Execute();
        process2.Execute();
    }
}

// Refined Abstraction 2
class Smartwatch : SmartDevice
{
    public Smartwatch(IManufacturingProcess process1, IManufacturingProcess process2)
        : base(process1, process2)
    {
    }

    public override void Manufacture()
    {
        Console.Write("Smartwatch ");
        process1.Execute();
        process2.Execute();
    }
}

// Implementer for Bridge Pattern
interface IManufacturingProcess
{
    void Execute();
}

// Concrete Implementation 1
class Fabrication : IManufacturingProcess
{
    public void Execute()
    {
        Console.Write("Fabricated");
    }
}

// Concrete Implementation 2
class Assembly : IManufacturingProcess
{
    public void Execute()
    {
        Console.Write(" And");
        Console.WriteLine(" Assembled.");
    }
}

// Demonstration of Bridge Design Pattern
class BridgePatternDemo
{
    static void Main(string[] args)
    {
        SmartDevice device1 = new Smartphone(new Fabrication(), new Assembly());
        device1.Manufacture();

        SmartDevice device2 = new Smartwatch(new Fabrication(), new Assembly());
        device2.Manufacture();
    }
}
