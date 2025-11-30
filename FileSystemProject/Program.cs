// See https://aka.ms/new-console-template for more information
using FileSystemProject;
using FSFile = FileSystemProject.File;
using FSFolder = FileSystemProject.Folder;

FSFile testFile = new FSFile("Secret files", 69, "C://Users//User//Documents//Example", "Lalalalala");
FSFolder testFolder = new FSFolder("Example", 69, "C://Users//User//Documents");


testFile.ShowInfo();
testFolder.CreateObject(testFile);
testFolder.ShowInfo();
testFolder.CreateObject(testFile);
testFolder.ShowInfo();
