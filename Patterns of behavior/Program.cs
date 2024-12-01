using System;

// Интерфейс команды
public interface ICommand
{
    void Execute();
}

// Конкретные команды
public class DigitCommand : ICommand
{
    private int _digit;
    private Calculator _calculator;

    public DigitCommand(Calculator calculator, int digit)
    {
        _calculator = calculator;
        _digit = digit;
    }

    public void Execute()
    {
        _calculator.InputDigit(_digit);
    }
}

public class AddCommand : ICommand
{
    private Calculator _calculator;

    public AddCommand(Calculator calculator)
    {
        _calculator = calculator;
    }

    public void Execute()
    {
        _calculator.Add();
    }
}

// Класс калькулятора
public class Calculator
{
    private int _currentValue = 0;

    public void InputDigit(int digit)
    {
        Console.WriteLine($"Ввод цифры: {digit}");
        _currentValue = _currentValue * 10 + digit;
    }

    public void Add()
    {
        Console.WriteLine("Выполнение операции сложения");
        _currentValue += _currentValue; // Пример логики сложения
        Console.WriteLine($"Текущее значение после сложения: {_currentValue}");
    }

    public void DisplayCurrentValue()
    {
        Console.WriteLine($"Текущее значение: {_currentValue}");
    }

    // Другие арифметические операции
}

// Класс кнопки
public class Button
{
    private ICommand _command;

    public Button(ICommand command)
    {
        _command = command;
    }

    public void Press()
    {
        _command.Execute();
    }

    public void SetCommand(ICommand command)
    {
        _command = command;
    }
}

// Использование
public class Program
{
    public static void Main()
    {
        Calculator calculator = new Calculator();

        // Фиксированные кнопки
        Button digitButton = new Button(new DigitCommand(calculator, 5));
        Button addButton = new Button(new AddCommand(calculator));

        // Настраиваемая кнопка
        Button customButton = new Button(new DigitCommand(calculator, 9));

        // Нажатие кнопок
        digitButton.Press();
        calculator.DisplayCurrentValue(); // Показать текущее значение
        addButton.Press();
        calculator.DisplayCurrentValue(); // Показать текущее значение
        customButton.Press();
        calculator.DisplayCurrentValue(); // Показать текущее значение

        // Изменение команды настраиваемой кнопки
        customButton.SetCommand(new AddCommand(calculator));
        customButton.Press();
        calculator.DisplayCurrentValue(); // Показать текущее значение
    }
}
