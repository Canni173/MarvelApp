using MarvelLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MarvelConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            MarvelManager marvelManager = new MarvelManager();

            foreach (var character in marvelManager.GetCharacters())
            {
                Console.WriteLine($"{character.Name}");
                Console.WriteLine($"{character.ImageUrl}");
                Console.WriteLine();
            }    
        }
    }
}
