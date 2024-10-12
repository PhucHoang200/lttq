using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KiemTraTongSoFile
{
    public partial class DocFile : Form
    {
        public DocFile()
        {
            InitializeComponent();
        }

        private void DocFile_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string content = textBox1.Text;  
                string fileName = textBox2.Text; 

                if (!string.IsNullOrWhiteSpace(fileName))
                {
                    File.WriteAllText(fileName, content);
                    MessageBox.Show("Lưu dữ liệu thành công!", "Thông báo");
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập tên file để lưu.", "Lỗi");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string fileName = textBox3.Text; 

                if (File.Exists(fileName))
                {
                    using (StreamReader reader = new StreamReader(fileName))
                    {
                        string content = reader.ReadToEnd(); 
                        textBox4.Text = content; 
                    }
                }
                else
                {
                    MessageBox.Show("File không tồn tại.", "Lỗi");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi");
            }
        }
    }
}
