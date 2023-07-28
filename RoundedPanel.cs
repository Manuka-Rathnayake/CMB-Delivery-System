using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using PointOfSalesSystem;

namespace CMB_Delivery_Management
{
    public partial class RoundedPanel : UserControl
    {
        private int cornerRadius = 20;

        public int CornerRadius
        {
            get { return cornerRadius; }
            set
            {
                cornerRadius = Math.Max(0, value);
                Invalidate();
            }
        }
        public RoundedPanel()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.FillRoundedRectangle(new SolidBrush(Color.White), 5, 5, this.Width, this.Height, 10);
        }
    }
}
