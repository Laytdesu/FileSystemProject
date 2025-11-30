namespace FileSystemProject;
using System.Text.Json;
using FileSystemProject;

public class FileSystemManager
{
    public Folder RootPath { get; set; }

    public FileSystemManager(string path, string name)
    {
        RootPath = new Folder(name, 0, path);
    }

    public Folder CreateFolder(Folder folderIn, string nameIn)
    {
        var folder = new Folder(nameIn, 0, folderIn.FullPath);
        folderIn.CreateObject(folder);
        return folder;
    }

    public FileObject CreateFile(Folder folderIn, string nameIn, string contents = "")
    {
        var file = new FileObject(nameIn, contents.Length, folderIn.FullPath, contents);
        folderIn.CreateObject(file);
        return file;
    }

    public void CreatePhysical()
    {
        RootPath.FSCreate();
    }
}