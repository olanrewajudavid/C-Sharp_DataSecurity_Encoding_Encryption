//Assignment-1_DataSecurity_Encoding_Encryption

// Task 1 : Add code that would receive a string from the user through the console
using Assignment_1_DataSecurity_Encoding_Encryption;

Console.WriteLine("\n========================= Task 1 : User Input =========================");
Console.Write("Enter your full name here :=> ");
string inputName = Console.ReadLine();
int token = 3;

// Task 2 : BinaryConverter
BinaryConverter base2 = new BinaryConverter();
base2.DisplayHeader();
string binaryData = base2.StringToBinary(inputName);
base2.BinaryToString(binaryData);

// Task 3 : BinaryConverter
HexadecimalConverter base16 = new HexadecimalConverter();
base16.DisplayHeader();
string hexadecimalData = base16.StringToHexadecimal(inputName);
base16.HexadecimalToString(hexadecimalData);

// Task 4 : BinaryConverter
Base64Converter base64 = new Base64Converter();
base64.DisplayHeader();
string base64Data = base64.StringToBase64(inputName);
base64.Base64ToString(base64Data);

// Task 5 : EncryptDecrypt
EncryptDecrypt Enc_Decrypt = new EncryptDecrypt();
Enc_Decrypt.DisplayHeader();
string encryptedData = Enc_Decrypt.Cipher(inputName, token);
Enc_Decrypt.Decipher(encryptedData, token);





