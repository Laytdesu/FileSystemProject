namespace FileSystemProject;
using System;
using System.IO;

public abstract class FileSystemObject
{
    public string Name { get; set; }
    public DateTime DateOfCreation { get; set; }
    public int Size { get; set; }
    public string FullPath { get; set; }

    public FileSystemObject(string name, int size, string fullPath)
    {
        Name = name;
        Console.WriteLine($"Constructor Name: {name}");
        DateOfCreation = DateTime.Now;
        Console.WriteLine($"Constructor Date of Creation: {DateOfCreation}");
        Size = size;
        Console.WriteLine($"Constructor Size: {Size}");
        FullPath = Path.Combine(fullPath, name);
        Console.WriteLine($"Constructor Full Path: {FullPath}");
    }

    public virtual void ShowInfo()
    {
        Console.Write($"Name: {Name}\nDate of Creation: {DateOfCreation}\nFile Size: {Size}\nFull Path: {FullPath}");
    }

    public abstract void FSCreate();

}

public class FileObject : FileSystemObject
{
    private string Content { get; set; }
    
    public FileObject(string name, int size, string fullPath, string content) : base(name, size, fullPath)
    {
        Content = content;
    }

    public override void ShowInfo()
    {
        base.ShowInfo();
        Console.Write($"\nFile contents: {Content}");
    }

    public override void FSCreate()
    {
        File.WriteAllText(FullPath, Content);
    }
}

public class Folder : FileSystemObject
{

    public Dictionary<string, FileSystemObject> Contents { get; private set; }
    
    public Folder(string name, int size, string fullPath) : base(name, size, fullPath)
    {
        Contents = new Dictionary<string, FileSystemObject>();
    }

    public void CreateObject(FileSystemObject objectInput)
    {
        if (Contents.ContainsKey(objectInput.Name))
        {
            Console.WriteLine("Oops, an item with this name already exists in this directory, would you like to keep both items(1) or cancel the operation(2)?");
            int input = Convert.ToInt32(Console.ReadLine());
            if (input == 1)
            {
                Contents[objectInput.Name + " (1)"] = objectInput;
                Console.WriteLine($"Added {objectInput.Name} as a copy");
            }
            else if (input == 2)
            {
                Console.WriteLine($"Did not add anything, aborted by user");
                return;
            }
        }
        else
        {
            Contents[objectInput.Name] = objectInput;
            Console.WriteLine($"Added {objectInput}");
        }
    }

    public bool RemoveObject(string objectName)
    {
        return Contents.Remove(objectName);
    }
    
    public override void FSCreate()
    {
        if (!(Directory.Exists(FullPath)))
        {
            Directory.CreateDirectory(FullPath);
        }
        else
        {
            foreach (var currFile in Contents.Values)
            {
                currFile.FSCreate();
            }
        }
    }
}

/*
 *
 *
 * Root/
 *      Documents/
 *                file1.txt
 *      Images/
 *              sda.jpeg
 *      Music/
 *              123.mp3

 * Dictionary(map)
 *
 * <TKey, TValue>
 * <filePath, typeObject>
 *
 * FileSystemItem - abstract class
 *         prop: Name, Created (dt), Size, FullPath
 *         methods*: Print
 * File - class parent FileSystemItem
 *          prop: Content, Print
 *
 * Folder - class parent FileSystemItem
 *          prop: Dictionary<stringFolderName, FileSystemItem> Items
 *          methods: GetItem, Print(override), AddItem
*/
