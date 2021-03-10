using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace O_Natashao
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

            aboutTextbox.Text = "The 'ONeillo v1.0' application was developed by Dr Peter O’Neill of Sheffield Hallam University for his level 4 students on the module 'Programming for Computing.'" + Environment.NewLine + Environment.NewLine + Environment.NewLine + "This 'ONeillo v1.0' application uses most, if not all of the techniques explained and demonstrated throughout the year. (The GUIImageArray used within the application was provided to the students).";
        }

        private void okayButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
