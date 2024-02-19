// Task 2 : Binary Converter
// Encoding : Covert your name to Binary
// Decoding : from Binary to original string

namespace Assignment_1_DataSecurity_Encoding_Encryption
{
    internal class BinaryConverter
    {
        public void DisplayHeader()
        {
            Console.WriteLine("\n=================== Task 2: Binary Converter =======================\n");
        }

        // Encoding
        public string StringToBinary(string inputName)
        {
            Console.WriteLine($"Entered String: (Your Name) = {inputName}"); // Entered String
            string binaryData = ""; // declare an empty variable

            //iterate through each character of the string
            foreach (char c in inputName)
            {
                string binary = "";
                int AsciiValue = (int)c;   //stores ascii value
                while (AsciiValue > 1)
                {
                    int remainder = AsciiValue % 2;
                    binary = Convert.ToString(remainder) + binary;
                    AsciiValue /= 2;
                }
                binary = Convert.ToString(AsciiValue) + binary;
                binaryData = binaryData + binary.PadLeft(8, '0');
                Console.WriteLine($"ASCII for {c} = {(int)c} Binary = {binary.PadLeft(8, '0')}"); //8 bit data
            }
            Console.WriteLine($"Lengh of string is : {binaryData.Length} = {binaryData}");
            Console.WriteLine($"Binary data = {binaryData}"); //entire binary string

            return binaryData; // return output 
        }

        // Decoding
        public void BinaryToString(string binaryData) // Receives converted binary Data 
        {
            string result = "";
            for (int i = 0; i < binaryData.Length; i += 8)  // loops through the binary data
            {
                var first8_bits = binaryData.Substring(i, 8); // Captures the first 8 bits
                int NumberValue = 0; // Declare the each digit  number 
                int powerDigit = first8_bits.Length - 1; // Declare maximum power digit of the binaray number
                
                //Loop through each character in the binary string
                for (int j = 0; j < first8_bits.Length; j++)
                {
                    int digit_Number = first8_bits[j] - '0'; // Declare digit of each binary number
                    // Multiply the current integer value by 2 and add the current binary digit
                    NumberValue += digit_Number * (int)Math.Pow(2, (powerDigit-j));
                }

                result += (char)NumberValue; // Converts to the ASCII value to the associated character

            }
            Console.WriteLine($"Binary {binaryData} to string = {result}");
        }
    }
}
