using System;

// Abstract Factory Interface
interface ISmartphoneFactory
{
    ISmartphone CreateSmartphone();
    ISpecification CreateSpecification();
}

// Concrete Factory for Android Smartphones
class AndroidSmartphoneFactory : ISmartphoneFactory
{
    public ISmartphone CreateSmartphone()
    {
        return new AndroidPhone();
    }

    public ISpecification CreateSpecification()
    {
        return new AndroidSpecification();
    }
}

// Concrete Factory for iOS Smartphones
class IosSmartphoneFactory : ISmartphoneFactory
{
    public ISmartphone CreateSmartphone()
    {
        return new IosPhone();
    }

    public ISpecification CreateSpecification()
    {
        return new IosSpecification();
    }
}

// Abstract Product Interface for Smartphones
interface ISmartphone
{
    void Assemble();
}

// Abstract Product Interface for Specifications
interface ISpecification
{
    void Display();
}

// Concrete Product for Android Phone
class AndroidPhone : ISmartphone
{
    public void Assemble()
    {
        Console.WriteLine("Assembling Android smartphone.");
    }
}

// Concrete Product for iOS Phone
class IosPhone : ISmartphone
{
    public void Assemble()
    {
        Console.WriteLine("Assembling iOS smartphone.");
    }
}

// Concrete Product for Android Phone Specification
class AndroidSpecification : ISpecification
{
    public void Display()
    {
        Console.WriteLine("Android Specification: Something 1");
    }
}

// Concrete Product for iOS Phone Specification
class IosSpecification : ISpecification
{
    public void Display()
    {
        Console.WriteLine("iOS Specification: Something 2");
    }
}

// Client Code
class SmartphoneFactoryClient
{
    static void Main(string[] args)
    {
        // Creating Android Smartphone
        ISmartphoneFactory androidFactory = new AndroidSmartphoneFactory();
        ISmartphone androidPhone = androidFactory.CreateSmartphone();
        ISpecification androidSpec = androidFactory.CreateSpecification();

        androidPhone.Assemble();
        androidSpec.Display();

        // Creating iOS Smartphone
        ISmartphoneFactory iosFactory = new IosSmartphoneFactory();
        ISmartphone iosPhone = iosFactory.CreateSmartphone();
        ISpecification iosSpec = iosFactory.CreateSpecification();

        iosPhone.Assemble();
        iosSpec.Display();
    }
}
