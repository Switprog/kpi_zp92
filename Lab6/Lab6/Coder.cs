using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    class Coder
    {
        private string stringToCode = "";
        StreamWriter streamWriter;

        public Coder(StreamWriter sw)
        {
            streamWriter = sw;
        }
        
        public void Write(string inString)
        {
            if (inString == null || inString == "")
            {
                return;
            } 
            stringToCode = inString;
            int stringLength = stringToCode.Length;
            char currentChar;
            string codedString = "";
            for (int i = 0; i < stringLength; i++)
            {
                currentChar = stringToCode[i];
                codedString += CodeChar(currentChar);
            }
            stringToCode = codedString;
            using (streamWriter)
            {
                streamWriter.Write(stringToCode);
            }
        }

        public char CodeChar(char inChar)
        {
            return (char)(2*(int)inChar);
        }

        public void Close()
        {
            streamWriter.Close();
        }

        public string GetString()
        {
            return stringToCode;
        }
    }
}
