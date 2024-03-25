using System;
using System.IO;
using System.IO.Compression;
public class FileHelper 
{
    const String WorkingFolder = "./CodeFiles/";
    public  void WriteFile(string filename, string fileData)
    {
        File.WriteAllText(WorkingFolder + filename,fileData);
    }

    public void ZipFiles()
    {
       ZipFile.CreateFromDirectory(WorkingFolder,"Code.zip");
    }

    public void Cleanup()
    {
        File.Delete(WorkingFolder);
    }
}