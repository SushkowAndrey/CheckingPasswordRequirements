using System;
using System.IO;
using System.Text.Json;

namespace CheckingPasswordRequirements
{
    public class SerializationJSON
    {
        /*
        private int minCountSymbol = 8;//минимальная длинна пароля
        private char[] acceptableDigits = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };//допустимые цифры
        private int minCountDigits = 2;//минимальное число цифр
        private char[] upperСaseСharacters = new char[] {'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'};//допустимые буквы верхнего регистра
        private int minCountUpperCharacters = 2;//минимальное число символов верхнего регистра
        private char[] lowerCaseCharacters = new char[] {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'};//допустимые буквы нижнего регистра
        private int minCountLowerCharacters = 2;//минимальное число символов нижнего регистра
        private char[] specialCharacters = new char[] {'!', '@', '#', '$', '%', '&', '*', '(', ')', '-', '=', '+', '/', '?', '№'};//допустимые буквы нижнего регистра
        private int minCountSpecialCharacters = 2;//минимальное число специальный символов
        //сериализация
        public void WritingFile(PasswordRequirementsModel passwordRequirementsModel)
        {
            using (StreamWriter file = new StreamWriter("passwordRequirementsModel.json", false))
            {
                passwordRequirementsModel.SetDataPasswordRequirementsModel(minCountSymbol, acceptableDigits, minCountDigits,
                    upperСaseСharacters, minCountUpperCharacters, lowerCaseCharacters, minCountLowerCharacters,
                    specialCharacters, minCountSpecialCharacters);
                string json = JsonSerializer.Serialize(passwordRequirementsModel);
                file.WriteLine(json);
            }
        }
        */
    }
}