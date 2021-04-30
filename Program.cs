using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace ASCII_Art_Generator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hi! welcome to the ASCII Art Generator :3"); 
            Console.WriteLine("Type the image path:");
            String path = Console.ReadLine();

            Console.WriteLine("Type the output path:");
            String outputPath = Console.ReadLine();

            using (Bitmap bmp = new Bitmap(path, true))
            {
                Bitmap image = new Bitmap(Console.WindowWidth - 1,Console.WindowHeight - 2);
                Graphics g = Graphics.FromImage(image);
                g.DrawImage(bmp, 0, 0, Console.WindowWidth - 1, Console.WindowHeight - 2);
    
                StringBuilder sb = new StringBuilder();
                String chars = " ..**@";

                for (int y = 0; y < image.Height; y++)
                {
                    for (int x = 0; x < image.Width; x++)
                    {
                        int index = (int)(image.GetPixel(x, y).GetBrightness() * chars.Length);

                        if (index < 0)
                        {
                            index = 0;
                        }
                        else if (index >= chars.Length)
                        {
                            index = chars.Length - 1;
                        }
                        sb.Append(chars[index]);
                    }
                    sb.Append("\n");
                }

                outputPath += "\\ascii_Art.png";
                image.Save(outputPath);
                Console.WriteLine("Saved!!!");

                Console.WriteLine(sb.ToString());
            }
            Console.ReadLine();
        }
    }
}
