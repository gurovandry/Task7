using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RunningButton
{
    public partial class Form : System.Windows.Forms.Form
    {
        private Point prev = Point.Empty;
        Random rnd = new Random();

        public Form()
        {
            InitializeComponent();
            MouseMove += new MouseEventHandler(OnMouseMove);
        }

        private void button_Click(object sender, EventArgs e)
        {
            button.Text = "Yeah!";
            MessageBox.Show("Congratulations!");
        }

        private void OnMouseMove(object sender, EventArgs e)
        {
            var cp = Cursor.Position;
            cp.X -= Left + 32;
            cp.Y -= Top + 32;

            if (prev != Point.Empty && cp != prev)
            {
                var pos = cp;
                pos.X -= prev.X;
                pos.Y -= prev.Y;
                pos.X /= 2;
                pos.Y /= 2;
                pos.X += button.Location.X;
                pos.Y += button.Location.Y;
                pos.X = Math.Min(Math.Max(pos.X, 0), Form.ActiveForm.Width - button.Size.Width - 15);
                pos.Y = Math.Min(Math.Max(pos.Y, 0), Form.ActiveForm.Height - button.Size.Height - 37);
                button.Location = pos;
            }
            prev = cp;
        }

        private double Distance(Point a, Point b)
        {
            return Math.Sqrt((a.X - b.X) * (a.X - b.X) + (a.Y - b.Y) * (a.Y - b.Y));
        }
    }
}