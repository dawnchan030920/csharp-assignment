namespace CayleyTree
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Graphics graphics;

        int n = 10;
        double x0 = 200;
        double y0 = 310;
        double leng = 100;
        double th = -90;
        double th1 = 30;
        double th2 = 20;
        double per1 = 0.6;
        double per2 = 0.7;
        Color color = Color.Black;

        private void button1_Click(object sender, EventArgs e)
        {
            this.Refresh();
            try
            {
                n = (int)ParsePositiveNumber(NumberNumericBox.Text);
                x0 = ParseRealNumber(X0Box.Text);
                y0 = ParseRealNumber(Y0Box.Text);
                leng = ParsePositiveNumber(LengthBox.Text);
                th = ParseAngle(ThBox.Text);
                th1 = ParseAngle(Th1Box.Text);
                th2 = ParseAngle(Th2Box.Text);
                per1 = ParsePositiveNumberLessThanOne(Per1Box.Text);
                per2 = ParsePositiveNumberLessThanOne(Per2Box.Text);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            if (graphics == null) graphics = this.CreateGraphics();
            drawCayleyTree(n, x0, y0, leng, th, th1, th2, per1, per2);
        }

        void drawCayleyTree(int n, double x0, double y0, double leng, double th, double th1, double th2, double per1, double per2)
        {
            if (n == 0) return;

            double angle = Math.PI / 180;

            double x1 = x0 + leng * Math.Cos(th * angle);
            double y1 = y0 + leng * Math.Sin(th * angle);

            drawLine(x0, y0, x1, y1);

            drawCayleyTree(n - 1, x1, y1, per1 * leng, th + th1, th1, th2, per1, per2);
            drawCayleyTree(n - 1, x1, y1, per2 * leng, th - th2, th1, th2, per1, per2);
        }

        void drawLine(double x0, double y0, double x1, double y1)
        {
            graphics.DrawLine(
                new Pen(color), (int)x0, (int)y0, (int)x1, (int)y1);
        }

        double ParseRealNumber(string input)
        {
            double result;
            if (double.TryParse(input, out result))
            {
                return result;
            }
            else
            {
                throw new ArgumentException("Invalid input. Please enter a valid real number.");
            }
        }

        double ParseAngle(string input)
        {
            double result;
            if (double.TryParse(input, out result))
            {
                if (result >= -360 && result <= 360)
                {
                    return result;
                }
                else
                {
                    throw new ArgumentException("Invalid input. Please enter a valid angle between -360 and 360.");
                }
            }
            else
            {
                throw new ArgumentException("Invalid input. Please enter a valid angle between -360 and 360.");
            }
        }

        double ParsePositiveNumber(string input)
        {
            double result;
            if (double.TryParse(input, out result))
            {
                if (result > 0)
                {
                    return result;
                }
                else
                {
                    throw new ArgumentException("Invalid input. Please enter a positive number.");
                }
            }
            else
            {
                throw new ArgumentException("Invalid input. Please enter a valid number.");
            }
        }

        double ParsePositiveNumberLessThanOne(string input)
        {
            double result;
            if (double.TryParse(input, out result))
            {
                if (result > 0 && result < 1)
                {
                    return result;
                }
                else
                {
                    throw new ArgumentException("Invalid input. Please enter a positive number less than 1.");
                }
            }
            else
            {
                throw new ArgumentException("Invalid input. Please enter a valid number.");
            }
        }

        private void ColorPickerButton_Click(object sender, EventArgs e)
        {
            var colorDialog = new ColorDialog();
            DialogResult result = colorDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                color = colorDialog.Color;
            }
        }
    }
}
