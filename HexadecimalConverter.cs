// Task 3 : Hexadecimal Converter
// Encoding : Covert your name to Hexadecimal
// Decoding : from Hexadecimal to original string

using System.Xml;

namespace Assignment_1_DataSecurity_Encoding_Encryption
{
    internal class HexadecimalConverter
    {
        public void DisplayHeader()
        {
            Console.WriteLine("\n=================== Task 3: Hexadecimal Converter =======================\n");
        }

        // Encoding
        public string StringToHexadecimal(string inputName)
        {
            Console.WriteLine($"Entered String: (Your Name) = {inputName}"); // Entered String

            string HexadecimalData = ""; // Declare initial Hexadecimal variable

            foreach (char character in inputName)
            {
                int character_acscii = (int)character;  // store ascii value
                string output = "";

                while (character_acscii != 0)
                {
                    if ((character_acscii % 16) < 10)
                        output = character_acscii % 16 + output;
                    else
                    {
                        string hexa_val = ""; // declare initial hexadecimal  for 10-15
                        switch (character_acscii % 16)
                        {
                            case 10: hexa_val = "A"; break;
                            case 11: hexa_val = "B"; break;
                            case 12: hexa_val = "C"; break;
                            case 13: hexa_val = "D"; break;
                            case 14: hexa_val = "E"; break;
                            case 15: hexa_val = "F"; break;
                        }
                        output = hexa_val + output;

                    }

                    character_acscii /= 16;
                }
                HexadecimalData += output;
                Console.WriteLine("ASCII for {0}  =  {1}, Hexadecimal value for {1} = {2}", character, (int)character, output);
            }
            Console.WriteLine($"The hexadecimal conversion of {inputName} is = {HexadecimalData}");
            return HexadecimalData;

        }   

        // Decoding
        public void HexadecimalToString(string HexadecimalData)
        {
            string output = "";
            for (int i = 0; i < HexadecimalData.Length; i += 2)
            {
                string two_bits_bunch = HexadecimalData.Substring(i, 2); // Captures the hexadecimal in two bits bunch

                //int ConvertToNumber = Convert.ToInt32(two_bits_bunch, 16); // 
                int decimalValue = 0;
                for (int j = 0; j < two_bits_bunch.Length; j++)
                {
                    char hexDigit = two_bits_bunch[j];

                    int digitValue = 0;

                    if (hexDigit >= '0' && hexDigit <= '9')
                    {
                        digitValue = hexDigit - '0';
                    }
                    else if (hexDigit >= 'A' && hexDigit <= 'F')
                    {
                        digitValue = 10 + hexDigit - 'A';
                    }
                    else if (hexDigit >= 'a' && hexDigit <= 'f')
                    {
                        digitValue = 10 + hexDigit - 'a';
                    }
                    decimalValue = 16 * decimalValue + digitValue;
                }
                output += (char)decimalValue;
            }

            Console.WriteLine("Conversion from the hexadecimal number to your name is = " + output.ToString());
        }

    }
}
