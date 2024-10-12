using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace KiemTraTongSoFile
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path = textBox1.Text;

            if (Directory.Exists(path))
            {
                int fileCount = Directory.GetFiles(path, "*", SearchOption.AllDirectories).Length;
                int directoryCount = Directory.GetDirectories(path, "*", SearchOption.AllDirectories).Length;

                textBox2.Text = fileCount.ToString();
                textBox3.Text = directoryCount.ToString();
            }
            else
            {
                MessageBox.Show("Đường dẫn không tồn tại, vui lòng kiểm tra lại.");
            }
        }
    }
}
