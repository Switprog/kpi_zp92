using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    class Decoder
    {
        private StreamReader streamReader;

        public Decoder(StreamReader sr)
        {
            streamReader = sr;
        }

        public string Read()
        {
            string codedStr = streamReader.ReadToEnd();
            string decodedStr = "";
            foreach(char c in codedStr)
            {
                decodedStr += DecodeChar(c);
            }
            return decodedStr;
        }

        public char DecodeChar(int charCode)
        {
            return (char)(charCode / 2);
        }

        public void Close()
        {
            streamReader.Close();
        }
    }
}
