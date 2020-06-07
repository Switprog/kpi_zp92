using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "Hello";

            Coder coder = new Coder(new StreamWriter("buffer.txt"));
            coder.Write(str);
            coder.Close();
            Console.WriteLine("Coded string: " + coder.GetString());
            
            Decoder decoder = new Decoder(new StreamReader("buffer.txt"));
            Console.WriteLine("Decoded string: " + decoder.Read());
            decoder.Close();

            Console.ReadKey();
        }
    }
}
