
namespace MauiApp_PagesLayouts
{
    public partial class CalculatorPage : ContentPage
    {
        public CalculatorPage()
        {
            InitializeComponent();
        }

        private void NumClicked(object sender, EventArgs e)
        {
            var btn = (Button)sender;

            var str = cScreen.Text+ btn.Text;
            double.TryParse(str, out double value);
            cScreen.Text = value.ToString();
        }

        double number1 =0;
        string operatorSymbol = "";
        private void OperatorClicked(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            lblHistory.Text = cScreen.Text + " " + btn.Text;
            number1 = double.Parse(cScreen.Text);
            cScreen.Text = "0";
            operatorSymbol = btn.Text;
        }

        private void EqualClicked(object sender, EventArgs e)
        {
            double number2 = double.Parse(cScreen.Text);
            double result = 0;
            switch (operatorSymbol)
            {
                case "+":
                    result = (number1 + number2);
                    break;                      
                case "-":                       
                    result = (number1 - number2);
                    break;                      
                case "*":                       
                    result = (number1 * number2);
                    break;                      
                case "/":                       
                    result = (number1 / number2);
                    break;
            }

            cScreen.Text = result.ToString();
            lblHistory.Text = $"{number1} {operatorSymbol} {number2}";
            number1 = result;
        }

        private void Clear_Clicked(object sender, EventArgs e)
        {
            cScreen.Text = "0";
            lblHistory.Text = "";
            number1 = 0;
            operatorSymbol = "";
        }

        private void Square_Clicked(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            lblHistory.Text = cScreen.Text + " " + btn.Text;

            number1 = double.Parse(cScreen.Text);
            var result = number1 * number1;
            cScreen.Text = result.ToString();
        }

        private void BackSpaceClicked(object sender, EventArgs e)
        {
            cScreen.Text = cScreen.Text.Length > 1 ? cScreen.Text[..^1] : "0";
        }
    }
}
