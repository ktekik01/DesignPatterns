using System;
using System.Collections.Generic;

// Originator
class TextEditor
{
    private string _content;

    public TextEditor(string content)
    {
        _content = content;
    }

    public void Write(string text)
    {
        _content += text;
    }

    public string GetContent()
    {
        return _content;
    }

    public EditorMemento CreateMemento()
    {
        return new EditorMemento(_content);
    }

    public void RestoreFromMemento(EditorMemento memento)
    {
        _content = memento.GetSavedContent();
    }
}

// Memento
class EditorMemento
{
    private readonly string _content;

    public EditorMemento(string content)
    {
        _content = content;
    }

    public string GetSavedContent()
    {
        return _content;
    }
}

// Caretaker
class VersionHistory
{
    private readonly List<EditorMemento> _mementos;

    public VersionHistory()
    {
        _mementos = new List<EditorMemento>();
    }

    public void AddMemento(EditorMemento memento)
    {
        _mementos.Add(memento);
    }

    public EditorMemento GetMemento(int index)
    {
        return _mementos[index];
    }
}

class Program
{
    static void Main()
    {
        TextEditor editor = new TextEditor("Initial content\n");
        VersionHistory history = new VersionHistory();

        // Write some content
        editor.Write("Additional content\n");
        history.AddMemento(editor.CreateMemento());

        // Write more content
        editor.Write("More content\n");
        history.AddMemento(editor.CreateMemento());

        // Restore to previous state
        editor.RestoreFromMemento(history.GetMemento(1));

        // Print document content
        Console.WriteLine(editor.GetContent());
    }
}
