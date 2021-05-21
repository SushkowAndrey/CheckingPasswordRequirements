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
        private int CheckingLength(string userPassword)
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
        private int CheckingAcceptableDigits(string userPassword)
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
        //последовательсть цифр
        public int SequenceDigits(string userPassword)
        {
            bool count = true;
            if (userPassword.Length < 3)
            {
                return 0;
            }
            else
            {
                for (int i = 0; i < passwordRequirementsModel.GetAcceptableDigits().Length - 2; i++)
                {
                    for (int j = 0; j < userPassword.Length - 2; j++)
                    {
                        if (userPassword[j] == passwordRequirementsModel.GetAcceptableDigits()[i] &&
                            userPassword[j + 1] == passwordRequirementsModel.GetAcceptableDigits()[i + 1] &&
                            userPassword[j + 2] == passwordRequirementsModel.GetAcceptableDigits()[i + 2])
                        {
                            count = false;
                            break;
                        }
                    }

                    if (!count) break;
                }

                if (count)
                {
                    Success?.Invoke($"Порядок цифр надежный"); // 2.Вызов события
                    return 1;
                }
                else
                {
                    Error?.Invoke("Порядок цифр ненадежный"); // 2.Вызов события
                    return 0;
                }
            }
        }
        //проверка наличия символов большого регистра
        private int CheckingUpperСase(string userPassword)
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
        //последовательсность букв малого регистра
        public int SequenceUpperСase(string userPassword)
        {
            bool count = true;
            if (userPassword.Length < 3)
            {
                return 0;
            }
            else
            {
                for (int i = 0; i < passwordRequirementsModel.GetUpperСaseСharacters().Length - 2; i++)
                {
                    for (int j = 0; j < userPassword.Length - 2; j++)
                    {
                        if (userPassword[j] == passwordRequirementsModel.GetUpperСaseСharacters()[i] &&
                            userPassword[j + 1] == passwordRequirementsModel.GetUpperСaseСharacters()[i + 1] &&
                            userPassword[j + 2] == passwordRequirementsModel.GetUpperСaseСharacters()[i + 2])
                        {
                            count = false;
                            break;
                        }
                    }

                    if (!count) break;
                }

                if (count)
                {
                    Success?.Invoke($"Порядок символов верхнего регистра надежный"); // 2.Вызов события
                    return 1;
                }
                else
                {
                    Error?.Invoke("Порядок символов верхнего регистра ненадежный"); // 2.Вызов события
                    return 0;
                }
            }
        }
        
        //проверка наличия символов малого регистра
        private int CheckinLowerCase(string userPassword)
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
        //последовательсность букв малого регистра
        public int SequenceLowerCase(string userPassword)
        {
            bool count = true;
            if (userPassword.Length < 3)
            {
                return 0;
            }
            else
            {
                for (int i = 0; i < passwordRequirementsModel.GetLowerCaseCharacters().Length - 2; i++)
                {
                    for (int j = 0; j < userPassword.Length - 2; j++)
                    {
                        if (userPassword[j] == passwordRequirementsModel.GetLowerCaseCharacters()[i] &&
                            userPassword[j + 1] == passwordRequirementsModel.GetLowerCaseCharacters()[i + 1] &&
                            userPassword[j + 2] == passwordRequirementsModel.GetLowerCaseCharacters()[i + 2])
                        {
                            count = false;
                            break;
                        }
                    }

                    if (!count) break;
                }

                if (count)
                {
                    Success?.Invoke($"Порядок символов нижнего регистра надежный"); // 2.Вызов события
                    return 1;
                }
                else
                {
                    Error?.Invoke("Порядок символов нижнего регистра ненадежный"); // 2.Вызов события
                    return 0;
                }
            }
        }
        //проверка наличия специальных символов
        private int CheckintSpecialCharacters(string userPassword)
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
            degreePasswordSecurity += SequenceDigits(userPassword);
            degreePasswordSecurity += CheckingUpperСase(userPassword);
            degreePasswordSecurity += SequenceUpperСase(userPassword);
            degreePasswordSecurity += CheckinLowerCase(userPassword);
            degreePasswordSecurity += SequenceLowerCase(userPassword);
            degreePasswordSecurity += CheckintSpecialCharacters(userPassword);
            if (degreePasswordSecurity==8)
            {
                Success?.Invoke($"Пароль соответствует требованиям надежности. Уровень надежности - {degreePasswordSecurity} из 8");   // 2.Вызов события
            }
            else if (degreePasswordSecurity<8&&degreePasswordSecurity>2)
            {
                Warning?.Invoke($"Пароль ненадежный. Уровень надежности - {degreePasswordSecurity} из 8"); // 2.Вызов события
            }
            else if (degreePasswordSecurity<=2)
            {
                Error?.Invoke($"Пароль не соответствует требованиям. Уровень надежности - {degreePasswordSecurity} из 8"); // 2.Вызов события
            }
            return degreePasswordSecurity;
        }
    }
}