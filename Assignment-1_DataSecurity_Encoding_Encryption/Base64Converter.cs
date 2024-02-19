// Task 4 : Base64 Converter
// Encoding : Covert your name to Base64
// Decoding : from Base64 to original string

namespace Assignment_1_DataSecurity_Encoding_Encryption
{
    internal class Base64Converter
    {
        public void DisplayHeader()
        {
            Console.WriteLine("\n=================== Task 4: Base64 Converter =======================\n");
        }

        // Encoding
        public string StringToBase64(string inputName)
        {
            Console.WriteLine($"Entered String: (Your Name) = {inputName}"); // Entered String

            // Declare empty variables for base 64 and binary numbers
            string base64Value = "";
            string binaryData = "";

            //Retrive binary value for the input string
            foreach (char character in inputName) 
            {
                binaryData += Convert.ToString(character, 2).PadLeft(8, '0');
            }

            //Confirm if there is padding
            string padding = "";
            if ((binaryData.Length % 3) != 0) // Confirm if not multiple of 3
            {
                int remainderValue = binaryData.Length % 3;
                
                // Confirm for padding character : 1 => 00, 2 => 0000  
                if (remainderValue == 1)
                {
                    binaryData += "00";
                    padding = "=";
                }

                if (remainderValue == 2)
                {
                    binaryData += "0000";
                    padding = "==";
                }

            }
            Console.WriteLine($"The Binary value for {inputName} is => {binaryData}");
            string base64 = string.Empty;

            for (int i = 0; i < binaryData.Length; i += 6) 
            {
                // Create the group of 6 bits
                string grouped6_bits = binaryData.Substring(i, 6);
                Console.Write($"{grouped6_bits} => ");
                
                //Convert to from BInary to decimal Decimal number
                int decimalNumber = 0;
                int powerDigit = grouped6_bits.Length - 1;
                for (int j = 0; j < grouped6_bits.Length; j++)
                {
                    int digit_Number = grouped6_bits[j] - '0'; // Declare digit of each binary number
                    // Multiply the current integer value by 16 and add the current binary digit
                    decimalNumber += digit_Number * (int)Math.Pow(2, (powerDigit - j));
                }
                Console.WriteLine(decimalNumber);

                //Retrieve Base64 value from the base 64 table
                base64 += Base64Letters[decimalNumber];
            }
            base64 += padding; // Adding padding behind the string
            Console.WriteLine($"Your name {inputName} in base 64 is : {base64}");
            return base64Value = base64;

        }

        private static readonly char[] Base64Letters = new[]
               {  'A','B','C','D','E','F','G','H','I','J','K','L','M',
            'N','O','P','Q','R','S','T','U','V','W','X','Y','Z',
            'a','b','c','d','e','f','g','h','i','j','k','l','m',
            'n','o','p','q','r','s','t','u','v','w','x','y','z',
            '0','1','2','3','4','5','6','7','8','9','+','/'
        };

         //Decoding (converting Base64 back to String)
        public void Base64ToString(string base64data)
        {
            string output = "";
            string binaryString = "";

            foreach (char base64Char in base64data)
            {
                if (base64Char != '=') // If the char is not a padding character '='
                {
                    int index = -1;
                    for (int i = 0; i < Base64Letters.Length; i++)
                    {
                        if (Base64Letters[i] == base64Char)
                        {
                            index = i;
                            i = Base64Letters.Length;
                        }
                    }
                    if (index != -1)
                    {
                        string binarySring = Convert.ToString(index, 2).PadLeft(6, '0'); // Convert to 6-bit binary
                        binaryString += binarySring; //to binaryString
                    }
                }
            }
            int number = binaryString.Length / 8;
            for (int i = 0; i < number; i++)
            {
                string eightBits_bunch = binaryString.Substring(i * 8, 8); // Captures 8-bits bunch
         
                char decimalValue = (char)Convert.ToInt32(eightBits_bunch, 2); // Convert to decimal then to character
                output += decimalValue;
            }

            Console.WriteLine("The Base64 string converted back to original string is => " + output.ToString());
        }

    }
}
