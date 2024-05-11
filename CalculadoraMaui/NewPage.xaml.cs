namespace CalculadoraMaui;

public partial class NewPage : ContentPage
{
	public NewPage()
	{
		InitializeComponent();
	}
    private string currentNumber = string.Empty;
    private string operation = string.Empty;
    private double firstNumber = 0;
    private double secondNumber = 0;

    private async void btn1_Clicked(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        string pressed = button.Text;

        if (pressed == "C")
        {
            resultLabel.Text = "0";
            currentNumber = string.Empty;
            operation = string.Empty;
            firstNumber = 0;
            secondNumber = 0;
        }
        else if (pressed == "Del")
        {
            if (!string.IsNullOrEmpty(currentNumber))
            {
                currentNumber = currentNumber.Remove(currentNumber.Length - 1);
                resultLabel.Text = currentNumber;
            }
        }
        else if (pressed == "+" || pressed == "-" || pressed == "×" || pressed == "/")
        {
            if (!string.IsNullOrEmpty(currentNumber))
            {
                if (operation != string.Empty)
                {
                    // Si ya se ha ingresado un operador antes, calcula el resultado parcial
                    if (double.TryParse(currentNumber, out secondNumber))
                    {
                        double result = Calculate(firstNumber, secondNumber, operation);
                        resultLabel.Text = result.ToString();
                        currentNumber = result.ToString();
                    }
                    else
                    {

                    }
                }
                else
                {
                    if (double.TryParse(currentNumber, out firstNumber))
                    {
                        // El primer número se establece solo si la conversión es exitosa
                        // de lo contrario, se ignora y se mantiene en cero
                    }

                }

                currentNumber = string.Empty;
                operation = pressed;
            }
        }
        else if (pressed == "=")
        {
            if (!string.IsNullOrEmpty(currentNumber) && operation != string.Empty)
            {
                if (double.TryParse(currentNumber, out secondNumber))
                {
                    double result = Calculate(firstNumber, secondNumber, operation);
                    resultLabel.Text = result.ToString();
                    currentNumber = result.ToString();
                    operation = string.Empty;
                }
                else
                {
                    await DisplayAlert("AVISO","ERROR, sintaxis de operacion incorrecta","CERRAR");
                }
            }
        }
        else if (pressed == ".")
        {
            if (!currentNumber.Contains("."))
            {
                currentNumber += ".";
                resultLabel.Text = currentNumber;
            }
        }
        else
        {
            currentNumber += pressed;
            resultLabel.Text = currentNumber;
        }
    }
    private double Calculate(double num1, double num2, string operation)
    {
        double result = 0;

        switch (operation)
        {
            case "+":
                result = num1 + num2;
                break;
            case "-":
                result = num1 - num2;
                break;
            case "×":
                result = num1 * num2;
                break;
            case "/":
                result = num1 / num2;
                break;
        }

        return result;
    }

}