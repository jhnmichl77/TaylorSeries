    using System.Text;

    namespace TaylorSeries
    {
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            cmbFunction.SelectedItem = "e^x";
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            if (double.TryParse(txtA.Text, out double a) &&
                  double.TryParse(txtX.Text, out double x) &&
                  int.TryParse(numOrder.Value.ToString(), out int n))
            {
                string selectedFunction = cmbFunction.SelectedItem.ToString();
                string expansion = "";

                switch (selectedFunction)
                {
                    case "sin(x)":
                        expansion = TaylorSinCenteredAt(x, a, n);
                        break;
                    case "cos(x)":
                        expansion = TaylorCosCenteredAt(x, a, n);
                        break;
                    case "e^x":
                        expansion = TaylorExpCenteredAt(x, a, n);
                        break;
                }

                txtSteps.Text = expansion;
            }
            else
            {
                MessageBox.Show("Please enter valid numeric values.");
            }
        }


        private double Factorial(int num)
        {
            double result = 1;
            for (int i = 2; i <= num; i++)
                result *= i;
            return result;
        }
        private string TaylorSinCenteredAt(double x, double a, int n)
        {
            double sum = 0;
            StringBuilder symbolic = new StringBuilder();
            StringBuilder evaluated = new StringBuilder();

            symbolic.AppendLine($"Function f(x): sin(x)");
            symbolic.AppendLine($"Expansion point a: {a}");
            symbolic.AppendLine($"Order n: {n}");
            symbolic.AppendLine($"\nTaylor Series:\nsin(x) ≈ ∑ [(-1)^n * (x - a)^(2n+1)] / (2n+1)!\n");


            if (Math.Abs(x - a) < 1e-6)
            {
                symbolic.AppendLine($"Evaluated at x = {x}: sin({x}) ≈ 1.000000");
                return symbolic.ToString();
            }

            for (int i = 0; i < n; i++)
            {
                int power = 2 * i + 1;
                double term = Math.Pow(-1, i) * Math.Pow(x - a, power) / Factorial(power);
                sum += term;
                string sign = i == 0 ? "" : (term >= 0 ? " + " : " - ");
                string termDisplay = $"(x - {a})^{power} / {power}!";

                symbolic.AppendLine($"{sign}{termDisplay}");
                evaluated.AppendLine($"{sign}{term:F6}");
            }

            symbolic.AppendLine($"\nEvaluated at x = {x}:sin({x}) ≈ {evaluated.ToString().Trim()}\n         ≈ {sum:F6}");
            return symbolic.ToString();
        }

        private string TaylorCosCenteredAt(double x, double a, int n)
        {
            double sum = 0;
            StringBuilder symbolic = new StringBuilder();
            StringBuilder evaluated = new StringBuilder();

            symbolic.AppendLine($"Function f(x): cos(x)");
            symbolic.AppendLine($"Expansion point a: {a}");
            symbolic.AppendLine($"Order n: {n}");
            symbolic.AppendLine($"\nTaylor Series:\ncos(x) ≈ ∑ [(-1)^n * (x - a)^(2n)] / (2n)!\n");

            for (int i = 0; i < n; i++)
            {
                int power = 2 * i;
                double term = Math.Pow(-1, i) * Math.Pow(x - a, power) / Factorial(power);
                sum += term;
                string sign = i == 0 ? "" : (term >= 0 ? " + " : " - ");
                string termDisplay = $"(x - {a})^{power} / {power}!";

                symbolic.AppendLine($"{sign}{termDisplay}");
                evaluated.AppendLine($"{sign}{term:F6}");
            }

            symbolic.AppendLine($"\nEvaluated at x = {x}:cos({x}) ≈ {evaluated.ToString().Trim()}\n         ≈ {sum:F6}");
            return symbolic.ToString();
        }

        private string TaylorExpCenteredAt(double x, double a, int n)
        {
            double sum = 0;
            StringBuilder symbolic = new StringBuilder();
            StringBuilder evaluated = new StringBuilder();

            symbolic.AppendLine($"Function f(x): e^x");
            symbolic.AppendLine($"Expansion point a: {a}");
            symbolic.AppendLine($"Order n: {n}");
            symbolic.AppendLine($"\nTaylor Series:\ne^x ≈ ∑ [(x - a)^n] / n!\n");

            for (int i = 0; i < n; i++)
            {
                double term = Math.Pow(x - a, i) / Factorial(i);
                sum += term;
                string sign = i == 0 ? "" : " + ";
                string termDisplay = $"(x - {a})^{i} / {i}!";

                symbolic.AppendLine($"{sign}{termDisplay}");
                evaluated.AppendLine($"{sign}{term:F6}");
            }

            symbolic.AppendLine($"\nEvaluated at x = {x}:e^{x} ≈ {evaluated.ToString().Trim()}\n         ≈ {sum:F6}");
            return symbolic.ToString();
        }

        private void numOrder_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
