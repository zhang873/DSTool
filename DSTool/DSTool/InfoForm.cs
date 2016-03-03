using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DSTool
{
    public partial class InfoForm : Form
    {
        public InfoForm(string info)
        {
            InitializeComponent();
            lab_info.Text = info;
        }
    }
}
