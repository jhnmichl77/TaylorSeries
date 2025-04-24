using System;
using System.Text;
using System.Windows.Forms;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.WindowsForms;

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

                
                var plotModel = new PlotModel { Title = "Taylor Series Approximation" };

                
                var actualSeries = new LineSeries { Title = "Actual", Color = OxyColors.Blue };
                var taylorSeries = new LineSeries { Title = "Taylor Approximation", Color = OxyColors.Red };

               
                for (double xi = a - 2; xi <= a + 2; xi += 0.1)
                {
                    double actualVal = 0;
                    double approxVal = 0;

                    switch (selectedFunction)
                    {
                        case "sin(x)":
                            actualVal = Math.Sin(xi);
                            approxVal = ApproxTaylorSin(xi, a, n);
                            expansion = TaylorSinCenteredAt(x, a, n);
                            break;
                        case "cos(x)":
                            actualVal = Math.Cos(xi);
                            approxVal = ApproxTaylorCos(xi, a, n);
                            expansion = TaylorCosCenteredAt(x, a, n);
                            break;
                        case "e^x":
                            actualVal = Math.Exp(xi);
                            approxVal = ApproxTaylorExp(xi, a, n);
                            expansion = TaylorExpCenteredAt(x, a, n);
                            break;
                    }

                    actualSeries.Points.Add(new DataPoint(xi, actualVal));
                    taylorSeries.Points.Add(new DataPoint(xi, approxVal));
                }

                
                plotModel.Series.Add(actualSeries);
                plotModel.Series.Add(taylorSeries);

                
                plotView.Model = plotModel;

                plotView.InvalidatePlot(true); 

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

            symbolic.AppendLine($"\nEvaluated at x = {x}:sin({x}) ≈ \n{evaluated.ToString().Trim()}\n         ≈ {sum:F6}");
            double actual = Math.Sin(x);
            symbolic.AppendLine($"Actual value: {actual:F6}");
            symbolic.AppendLine($"Absolute error: {Math.Abs(actual - sum):E6}");
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

            symbolic.AppendLine($"\nEvaluated at x = {x}:cos({x}) ≈ \n{evaluated.ToString().Trim()}\n         ≈ {sum:F6}");
            double actual = Math.Cos(x);
            symbolic.AppendLine($"Actual value: {actual:F6}");
            symbolic.AppendLine($"Absolute error: {Math.Abs(actual - sum):E6}");
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

            symbolic.AppendLine($"\nEvaluated at x = {x}:e^{x} ≈ \n{evaluated.ToString().Trim()}\n         ≈ {sum:F6}");
            double actual = Math.Exp(x);
            symbolic.AppendLine($"Actual value: {actual:F6}");
            symbolic.AppendLine($"Absolute error: {Math.Abs(actual - sum):E6}");
            return symbolic.ToString();
        }
        private double ApproxTaylorSin(double x, double a, int n)
        {
            double sum = 0;
            for (int i = 0; i < n; i++)
            {
                int power = 2 * i + 1;
                sum += Math.Pow(-1, i) * Math.Pow(x - a, power) / Factorial(power);
            }
            return sum;
        }

        private double ApproxTaylorCos(double x, double a, int n)
        {
            double sum = 0;
            for (int i = 0; i < n; i++)
            {
                int power = 2 * i;
                sum += Math.Pow(-1, i) * Math.Pow(x - a, power) / Factorial(power);
            }
            return sum;
        }

        private double ApproxTaylorExp(double x, double a, int n)
        {
            double sum = 0;
            for (int i = 0; i < n; i++)
            {
                sum += Math.Pow(x - a, i) / Factorial(i);
            }
            return sum;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
