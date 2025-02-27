namespace Calculator_Windows;

public partial class Form1 : Form
{
    private double firstNumber;
    private string operation = "";
    private bool isNewNumber = true;

    public Form1()
    {
        InitializeComponent();
        for (int i = 0; i < numberButtons.Length; i++)
        {
            int number = i;
            numberButtons[i].Click += (sender, e) => NumberButton_Click(number);
        }
        addButton.Click += (sender, e) => OperatorButton_Click("+");
        subtractButton.Click += (sender, e) => OperatorButton_Click("-");
        multiplyButton.Click += (sender, e) => OperatorButton_Click("*");
        divideButton.Click += (sender, e) => OperatorButton_Click("/");
        equalsButton.Click += EqualsButton_Click!;
        clearButton.Click += ClearButton_Click!;
    }

    private void NumberButton_Click(int number)
    {
        if (isNewNumber)
        {
            displayTextBox.Text = number.ToString();
            isNewNumber = false;
        }
        else
        {
            displayTextBox.Text += number.ToString();
        }
    }

    private void OperatorButton_Click(string op)
    {
        if (double.TryParse(displayTextBox.Text, out firstNumber))
        {
            operation = op;
            isNewNumber = true;
        }
    }

    private void EqualsButton_Click(object? sender, EventArgs e)
    {
        if (!double.TryParse(displayTextBox.Text, out double secondNumber))
        {
            return;
        }

        double result = 0;
        bool validOperation = true;

        switch (operation)
        {
            case "+":
                result = firstNumber + secondNumber;
                break;
            case "-":
                result = firstNumber - secondNumber;
                break;
            case "*":
                result = firstNumber * secondNumber;
                break;
            case "/":
                if (secondNumber != 0)
                    result = firstNumber / secondNumber;
                else
                {
                    MessageBox.Show("除数不能为零！");
                    validOperation = false;
                }
                break;
            default:
                validOperation = false;
                break;
        }

        if (validOperation)
        {
            displayTextBox.Text = result.ToString();
        }
        isNewNumber = true;
    }

    private void ClearButton_Click(object? sender, EventArgs e)
    {
        displayTextBox.Text = "0";
        firstNumber = 0;
        operation = "";
        isNewNumber = true;
    }
}
