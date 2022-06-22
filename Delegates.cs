using System;

namespace Delegates;

class Program
{
    static void Main()
    {
        var processor = new PhotoProcessor();
        var filter = new PhotoFilters();

        Action<Photo> filterHandler = filter.ApplyBrightness;
        filterHandler += filter.Resize;

        processor.Process("somePath", filterHandler);
    }
}

public class Photo
{
    public static Photo Load(string path) =>
        new Photo();

    public void Save()
    {
    }
}

public class PhotoFilters
{
    public void ApplyBrightness(Photo photo) =>
        Console.WriteLine("Brightness applied.");

    public void Resize(Photo photo) =>
        Console.WriteLine("Photo resized.");
}

public class PhotoProcessor
{
    //NOTE THIS
    //The .NET have two delegates
    //Action to queries
    //Func to commands

    public void Process(string path, Action<Photo> filterHandler)
    {
        var photo = Photo.Load(path);

        filterHandler(photo);

        photo.Save();
    }
}
