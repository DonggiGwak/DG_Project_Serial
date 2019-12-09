using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Serial_SharpThreadExample
{
    public partial class ucSerialPort : UserControl
    {
        [Description("ClickEvent"), Category("LED_MouseEvent")]
        public event EventHandler Click;
        
        public ucSerialPort()
        {
            InitializeComponent();
        }

        private void pic_led_Click(object sender, EventArgs e)
        {

        }
    }
}
