// Library classes
public abstract class Document
{
    public abstract void PrintDocument();
}

public class WordDocument : Document
{
    public override void PrintDocument()
    {
        Console.WriteLine("Word");
    }
}

public class PdfDocument : Document
{
    public override void PrintDocument()
    {
        Console.WriteLine("PDF");
    }
}

// Factory Interface
public interface IDocumentFactory
{
    Document CreateDocument();
}

// Concrete Factory for WordDocument
public class WordDocumentFactory : IDocumentFactory
{
    public Document CreateDocument()
    {
        return new WordDocument();
    }
}

// Concrete Factory for PdfDocument
public class PdfDocumentFactory : IDocumentFactory
{
    public Document CreateDocument()
    {
        return new PdfDocument();
    }
}

// Client class
public class Client
{
    private Document _document;

    public Client(IDocumentFactory factory)
    {
        _document = factory.CreateDocument();
    }

    public Document GetDocument()
    {
        return _document;
    }
}

// Driver program
public class Program
{
    public static void Main(string[] args)
    {
        IDocumentFactory wordFactory = new WordDocumentFactory();
        Client wordClient = new Client(wordFactory);
        Document wordDoc = wordClient.GetDocument();
        wordDoc.PrintDocument();

        IDocumentFactory pdfFactory = new PdfDocumentFactory();
        Client pdfClient = new Client(pdfFactory);
        Document pdfDoc = pdfClient.GetDocument();
        pdfDoc.PrintDocument();
    }
}
