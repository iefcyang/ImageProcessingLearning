using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2021HWK05
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void EditColorWatch(object sender, EventArgs e)
        {

        }

        PointF[] corners = { new PointF(0, 0), new PointF(255, 0), new PointF(0, 255), new PointF(255, 255) };
        double[] dis = new double[4];

        private void splitContainer2_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
