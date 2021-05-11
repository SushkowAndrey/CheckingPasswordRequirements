using System;

namespace CheckingPasswordRequirements
{
    //делегат логирования
    public delegate void InformationCheck(string message);
    public class CheckingPassword
    {
        public event InformationCheck Success;//успешно
        public event InformationCheck Warning;//предупреждение
        public event InformationCheck Error;//ошибка
        private PasswordRequirementsModel passwordRequirementsModel = new PasswordRequirementsModel();
        //проверка длинны пароля
        public int CheckingLength(string userPassword)
        {
            if (userPassword.Length >= passwordRequirementsModel.GetMinCountSymbol())
            {
                Success?.Invoke($"Число символов соответствует требованиям");   // 2.Вызов события
                return 1;
            }
            else
            {
                Error?.Invoke($"Введенный пароль слишком короткий, число введенный символов - {userPassword.Length}. Число символов должно быть не менее {passwordRequirementsModel.GetMinCountSymbol()}"); // 2.Вызов события
                return 0;
            }
        }
        //проверка наличия цифр, количества цифр
        public int CheckingAcceptableDigits(string userPassword)
        {
            int count = 0;
            for(int i = 0; i < passwordRequirementsModel.GetAcceptableDigits().Length; i++)
            {
                for (int j = 0; j < userPassword.Length; j++)
                {
                    if (userPassword[j] == passwordRequirementsModel.GetAcceptableDigits()[i])
                    {
                        count++;
                        if (count > passwordRequirementsModel.GetMinCountDigits()) break;
                    }
                }
                if (count > passwordRequirementsModel.GetMinCountDigits()) break;
            }
            if (count > passwordRequirementsModel.GetMinCountDigits())
            {
                Success?.Invoke($"Количество цифр соответствует требованиям");   // 2.Вызов события
                return 1;
            }
            else
            {
                Error?.Invoke($"Число цифр не соответстует требованиям. Число цифр должно быть не менее {passwordRequirementsModel.GetMinCountDigits()}"); // 2.Вызов события
                return 0;
            }
        }
        //проверка наличия символов большого регистра
        public int CheckingUpperСase(string userPassword)
        {
            int count = 0;
            for(int i = 0; i < passwordRequirementsModel.GetUpperСaseСharacters().Length; i++)
            {
                for (int j = 0; j < userPassword.Length; j++)
                {
                    if (userPassword[j] == passwordRequirementsModel.GetUpperСaseСharacters()[i])
                    {
                        count++;
                        if (count > passwordRequirementsModel.GetMinCountUpperCharacters()) break;
                    }
                }
                if (count > passwordRequirementsModel.GetMinCountUpperCharacters()) break;
            }
            if (count > passwordRequirementsModel.GetMinCountUpperCharacters())
            {
                Success?.Invoke($"Количество букв большого регистра соответствует требованиям");   // 2.Вызов события
                return 1;
            }
            else
            {
                Error?.Invoke($"Число букв большого регистра не соответстует требованиям. Число букв большого регистра должно быть не менее {passwordRequirementsModel.GetMinCountUpperCharacters()}"); // 2.Вызов события
                return 0;
            }
        }
        //проверка наличия символов малого регистра
        public int CheckinLowerCase(string userPassword)
        {
            int count = 0;
            for(int i = 0; i < passwordRequirementsModel.GetLowerCaseCharacters().Length; i++)
            {
                for (int j = 0; j < userPassword.Length; j++)
                {
                    if (userPassword[j] == passwordRequirementsModel.GetLowerCaseCharacters()[i])
                    {
                        count++;
                        if (count > passwordRequirementsModel.GetMinCountLowerCharacters()) break;
                    }
                }
                if (count > passwordRequirementsModel.GetMinCountLowerCharacters()) break;
            }
            if (count > passwordRequirementsModel.GetMinCountLowerCharacters())
            {
                Success?.Invoke($"Количество букв малого регистра соответствует требованиям");   // 2.Вызов события
                return 1;
            }
            else
            {
                Error?.Invoke($"Число букв малого регистра не соответстует требованиям. Число букв малого регистра должно быть не менее {passwordRequirementsModel.GetMinCountLowerCharacters()}"); // 2.Вызов события
                return 0;
            }
        }
        //проверка наличия специальных символов
        public int CheckintSpecialCharacters(string userPassword)
        {
            int count = 0;
            for(int i = 0; i < passwordRequirementsModel.GetSpecialCharacters().Length; i++)
            {
                for (int j = 0; j < userPassword.Length; j++)
                {
                    if (userPassword[j] == passwordRequirementsModel.GetSpecialCharacters()[i])
                    {
                        count++;
                        if (count > passwordRequirementsModel.GetMinCountSpecialCharacters()) break;
                    }
                }
                if (count > passwordRequirementsModel.GetMinCountSpecialCharacters()) break;
            }
            if (count > passwordRequirementsModel.GetMinCountLowerCharacters())
            {
                Success?.Invoke($"Количество спецсимволов соответствует требованиям");   // 2.Вызов события
                return 1;
            }
            else
            {
                Error?.Invoke($"Число спецсимволов не соответстует требованиям. Число спецсимволов должно быть не менее {passwordRequirementsModel.GetMinCountLowerCharacters()}"); // 2.Вызов события
                return 0;
            }
        }
        public int DegreePasswordSecurity(string userPassword)
        {
            int degreePasswordSecurity = 0;
            degreePasswordSecurity += CheckingLength(userPassword);
            degreePasswordSecurity += CheckingAcceptableDigits(userPassword);
            degreePasswordSecurity += CheckingUpperСase(userPassword);
            degreePasswordSecurity += CheckinLowerCase(userPassword);
            degreePasswordSecurity += CheckintSpecialCharacters(userPassword);
            if (degreePasswordSecurity==5)
            {
                Success?.Invoke($"Пароль соответствует требованиям надежности. Уровень надежности - {degreePasswordSecurity} из 5");   // 2.Вызов события
            }
            else if (degreePasswordSecurity<5&&degreePasswordSecurity>2)
            {
                Warning?.Invoke($"Пароль ненадежный. Уровень надежности - {degreePasswordSecurity} из 5"); // 2.Вызов события
            }
            else if (degreePasswordSecurity<=2)
            {
                Error?.Invoke($"Пароль не соответствует требованиям. Уровень надежности - {degreePasswordSecurity} из 5"); // 2.Вызов события
            }
            return degreePasswordSecurity;
        }
    }
}