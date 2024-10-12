using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KiemTraTongSoFile
{
    public partial class MoFileAnh : Form
    {
        public MoFileAnh()
        {
            InitializeComponent();
        }

        private void buttonOpenImage_Click_Click(object sender, EventArgs e)
        {
            // Tạo một OpenFileDialog để chọn file ảnh
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Chọn ảnh";
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

            // Kiểm tra xem người dùng đã chọn file hay chưa
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Lấy đường dẫn file được chọn
                string filePath = openFileDialog.FileName;

                // Hiển thị ảnh lên PictureBox
                pictureBox1.Image = new System.Drawing.Bitmap(filePath);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }
    }
}
