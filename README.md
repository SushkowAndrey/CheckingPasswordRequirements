# CheckingPasswordRequirements
# API
Для работы с модулем используется класс `CheckingPassword`

## Делегат
- `InformationCheck(string message)` типа `void` - для логирования результатов проверки. Через него определяется события `event` с именем `Success`, `Warning` и `Error`, которые представляют делегат и передают результат проверки при подключении к логу;

## Метод
- `DegreePasswordSecurity(string userPassword)` типа `int` - принимает сам пароль для проверки. Данный метод проверяет несколько требований к паролю:
    - число символов;
    - наличие и число цифр;
    - последовательность цифр;
    - наличие и число символов нижнего регистра;
    - последовательность букв верхнего регистра;
    - наличие и число символов верхнего регистра;
    - последовательность букв нижнего регистра;
    - число спецсимволов;

Каждая успешная проверка присваивает один балл. В результате выполнения метода возвращается степень надежности пароля от 0 до 8 и пользователь сам решает, в каком диапазоне разрешено использовать данный пароль.
Результат проверки каждого требования записывается в лог
