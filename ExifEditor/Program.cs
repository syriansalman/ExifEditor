// See https://aka.ms/new-console-template for more information
using ExifLibrary;
using System.Globalization;
using System.IO;


//string path = @"D:\";
string path = @"C:\Users\syria\OneDrive\الصور\لفة كاميرا\2022";

//IMG-20201126-WA0023

DirectoryInfo d = new DirectoryInfo(path); //Assuming Test is your Folder

FileInfo[] Files = d.GetFiles("IMG*WA*"); //Getting Text files



CultureInfo provider = CultureInfo.InvariantCulture;
// It throws Argument null exception  
int cnt = 1;
foreach (FileInfo file in Files)
{

    string[] arr = file.Name.Split("-");
    string dateString = arr[1];
    if (file.Name.Contains("IMG-20210628-WA0001"))
    {
        int x = 6;
        Console.WriteLine(x);
    
    }
    DateTime dtt = DateTime.ParseExact(dateString, "yyyyMMdd", provider);
    Console.Write(cnt++ +": "+ file.Name);

    ImageFile fil_exif = ImageFile.FromFile(path + "/" + file.Name);


    ExifProperty xx = null;

    xx = fil_exif.Properties.Get(ExifTag.DateTimeDigitized);
    if (xx == null)
    {
        Console.Write("\tset "+dtt.ToShortDateString());
        fil_exif.Properties.Set(ExifTag.DateTimeDigitized, dtt);
    }
   else {
        Console.Write("\tget ");
        Console.Write(xx.Value);
    
    }

    xx = fil_exif.Properties.Get(ExifTag.DateTimeOriginal);
    if ( xx== null )
    {
        Console.Write("\tset " + dtt.ToShortDateString());
        fil_exif.Properties.Set(ExifTag.DateTimeOriginal, dtt);
    }
    else
    {
        Console.Write("\tget ");
   
        Console.Write(xx.Value);
    }

    xx = fil_exif.Properties.Get(ExifTag.Make);
    if ( xx== null )
    {
        Console.Write("\tset WhatsApp");
        fil_exif.Properties.Set(ExifTag.Make, "WhatsApp");
    }
    else
    {
        Console.Write("\tget ");
        Console.Write(xx.Value);

    }
    xx = fil_exif.Properties.Get(ExifTag.Model);
    if (xx == null )
    {
        Console.Write("\tset ");
        fil_exif.Properties.Set(ExifTag.Model, "WhatsApp");
    }
    else
    {
        Console.Write("\tget ");
        Console.Write(xx.Value);

    }


    xx = fil_exif.Properties.Get(ExifTag.Copyright);
    if (xx == null )
    {
        Console.Write("\tset ");
        fil_exif.Properties.Set(ExifTag.Copyright, "Salman");
    }
    else
    {
        Console.Write("\tget ");
        Console.Write(xx.Value);

    }

    //
    try
    {

        fil_exif.Save(path + "/" + file.Name);
        Console.Write("\tDONE");
    }
    catch (System.UnauthorizedAccessException  xxx)
    {

        Console.WriteLine("\tUnauthorizedAccessException");
    }

    Console.WriteLine("\n-------");

    //  str = str + ", " + file.Name;
}