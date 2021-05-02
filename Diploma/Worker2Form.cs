using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diploma
{
    public partial class Worker2Form : Form
    {
        Dictionary<int, int> _addTask;
        int _userID;
        bool status;

        public Worker2Form()
        {
            InitializeComponent();
            _addTask = new Dictionary<int, int>();
            status = true;
        }

        private void Worker2Form_Load(object sender, EventArgs e)
        {
            
        }
    }
}
