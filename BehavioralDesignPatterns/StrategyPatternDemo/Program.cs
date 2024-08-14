using System;

// Strategy Interface
public interface IPaymentStrategy
{
    void ProcessPayment(decimal amount);
}

// Concrete Strategy: Credit Card Payment
public class CreditCardPayment : IPaymentStrategy
{
    public void ProcessPayment(decimal amount)
    {
        Console.WriteLine($"Processing credit card payment of ${amount}");
        // Actual credit card payment logic here
    }
}

// Concrete Strategy: PayPal Payment
public class PayPalPayment : IPaymentStrategy
{
    public void ProcessPayment(decimal amount)
    {
        Console.WriteLine($"Processing PayPal payment of ${amount}");
        // Actual PayPal payment logic here
    }
}

// Concrete Strategy: Bitcoin Payment
public class BitcoinPayment : IPaymentStrategy
{
    public void ProcessPayment(decimal amount)
    {
        Console.WriteLine($"Processing Bitcoin payment of ${amount}");
        // Actual Bitcoin payment logic here
    }
}

// Context
public class PaymentContext
{
    private IPaymentStrategy _paymentStrategy;

    public PaymentContext(IPaymentStrategy paymentStrategy)
    {
        _paymentStrategy = paymentStrategy;
    }

    public void SetPaymentStrategy(IPaymentStrategy paymentStrategy)
    {
        _paymentStrategy = paymentStrategy;
    }

    public void MakePayment(decimal amount)
    {
        _paymentStrategy.ProcessPayment(amount);
    }
}

// Client
public class Program
{
    public static void Main(string[] args)
    {
        // Create PaymentContext with CreditCardPayment strategy
        PaymentContext paymentContext = new PaymentContext(new CreditCardPayment());
        decimal amount1 = 100.00m;
        paymentContext.MakePayment(amount1); 

        // Change strategy to PayPalPayment
        paymentContext.SetPaymentStrategy(new PayPalPayment());
        decimal amount2 = 200.00m;
        paymentContext.MakePayment(amount2); 

        // Change strategy to BitcoinPayment
        paymentContext.SetPaymentStrategy(new BitcoinPayment());
        decimal amount3 = 300.00m;
        paymentContext.MakePayment(amount3); 
    }
}
