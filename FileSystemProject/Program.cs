// See https://aka.ms/new-console-template for more information
using FileSystemProject;
using FSFile = FileSystemProject.FileObject;
using FSFolder = FileSystemProject.Folder;

FileSystemManager FSMan = new FileSystemManager("/Users/radionintouch/Documents", "Example");

var Docs = FSMan.CreateFolder(FSMan.RootPath, "Docs");
var Images = FSMan.CreateFolder(FSMan.RootPath, "Images");
FSMan.CreateFile(Docs, "Secrets.txt", "Sicret");
FSMan.CreateFile(Images, "ARealImage.png", "");
FSMan.CreatePhysical();