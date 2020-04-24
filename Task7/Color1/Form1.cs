using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ColorPicker
{
    public partial class Form : System.Windows.Forms.Form
    {
        private ToolTip toolTip;
        public Form()
        {
            InitializeComponent();
        }

        private void Form_Load(object sender, EventArgs e)
        {
            canvas.BackColor = Color.FromArgb(125, 125, 125);
            RedTrack.Value = 125;
            GreenTrack.Value = 125;
            BlueTrack.Value = 125;

            toolTip = new ToolTip();

            toolTip.InitialDelay = 1000;
            toolTip.ReshowDelay = 500;

            toolTip.SetToolTip(canvas, ColorTranslator.ToHtml(canvas.BackColor));
        }

        private void RedTrack_Scroll(object sender, EventArgs e)
        {
            UpdateValues();
        }

        private void GreenTrack_Scroll(object sender, EventArgs e)
        {
            UpdateValues();
        }

        private void BlueTrack_Scroll(object sender, EventArgs e)
        {
            UpdateValues();
        }

        private void UpdateValues()
        {
            canvas.BackColor = Color.FromArgb(RedTrack.Value, GreenTrack.Value, BlueTrack.Value);
            var hex = ColorTranslator.ToHtml(canvas.BackColor);
            toolTip.SetToolTip(canvas, hex);
            Clipboard.SetText(hex);
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
