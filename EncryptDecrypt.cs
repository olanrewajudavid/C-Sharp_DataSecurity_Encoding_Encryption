// Task 5 : Encryption Decryption
// Encoding : Encrypt your name
// Decoding : Decrypt your name to original string

namespace Assignment_1_DataSecurity_Encoding_Encryption
{
    internal class EncryptDecrypt
    {
        public void DisplayHeader()
        {
            Console.WriteLine("\n=================== Task 5: Encryption Decryption =======================\n");
        }

        public string Cipher(string inputName, int token)
        {
            Console.WriteLine($"Entered String that needs to be encrypted = {inputName}"); // Entered String
            string encryptedData = "";

            foreach (char c in inputName)
            {
                if (char.IsLetter(c)) //Check if character is a letter 
                {
                    int ascii = (int)c;
                    ascii += token; //add key to ascii value to encrypt 
                    char encryptedChar = (char)ascii;

                    encryptedData += encryptedChar;
                }
                else
                {
                    encryptedData += c;
                }
            }
            Console.WriteLine($"The encrypted Data is => {encryptedData}");
            return encryptedData;
        }

        //Decryption

        public void Decipher(string encryptedData, int token)
        {
            string decipherData = "";

            foreach (char encryptedChar in encryptedData)
            {
                if (char.IsLetter(encryptedChar))
                {
                    int ascii = (int)encryptedChar;
                    ascii -= token;
                    char decryptedChar = (char)(ascii); //convert the new ascii value back a character 

                    decipherData += decryptedChar;
                }
                else
                {
                    decipherData += encryptedChar;
                }
            }
            Console.WriteLine($"The decrypted data => {decipherData}");
        }
    }
}
