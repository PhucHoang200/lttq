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
    public partial class CopyTepTin : Form
    {
        private BackgroundWorker backgroundWorker;
        public CopyTepTin()
        {
            InitializeComponent();
            InitializeComboBox();
            InitializeBackgroundWorker();
        }

        private void InitializeComboBox()
        {          
            comboBox1.Items.Add("JPG");
            comboBox1.Items.Add("PNG");
            comboBox1.Items.Add("XLS");
            comboBox1.Items.Add("XLSX");
            comboBox1.Items.Add("DOC");
            comboBox1.Items.Add("DOCX");
            comboBox1.Items.Add("PPT");
            comboBox1.Items.Add("PPTX");
            comboBox1.Items.Add("PDF");
            comboBox1.SelectedIndex = 0; 
        }

        private void InitializeBackgroundWorker()
        {
            backgroundWorker = new BackgroundWorker();
            backgroundWorker.DoWork += BackgroundWorker_DoWork; // Xử lý công việc
            backgroundWorker.RunWorkerCompleted += BackgroundWorker_RunWorkerCompleted; // Xử lý khi công việc hoàn thành
            backgroundWorker.WorkerReportsProgress = true; // Cho phép báo cáo tiến độ
            backgroundWorker.ProgressChanged += BackgroundWorker_ProgressChanged; // Xử lý sự kiện thay đổi tiến độ
        }
        private void button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = folderBrowserDialog.SelectedPath; 
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string fileExtension = GetSelectedFileExtension(); 
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = $"Files (*.{fileExtension})|*.{fileExtension}"; 

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFileDialog.FileName;
            }
        }

        private void button_Thoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát chương trình không?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit(); 
            }
        }

        private void button_CatFile_Click(object sender, EventArgs e)
        {
            if (!backgroundWorker.IsBusy)
            {
                progressBar1.Value = 0; // Đặt lại giá trị của ProgressBar
                backgroundWorker.RunWorkerAsync("cut"); // Bắt đầu công việc cắt
            }
        }

        private void button_Copy_Click(object sender, EventArgs e)
        {
            if (!backgroundWorker.IsBusy)
            {
                progressBar1.Value = 0; // Đặt lại giá trị của ProgressBar
                backgroundWorker.RunWorkerAsync("copy"); // Bắt đầu công việc sao chép
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            string action = e.Argument.ToString();
            string sourceFile = textBox1.Text;
            string destinationFile = Path.Combine(textBox2.Text, Path.GetFileName(sourceFile));

            if (File.Exists(sourceFile))
            {
                for (int i = 0; i <= 10; i++)
                {
                    // Giả lập việc cắt hoặc sao chép
                    System.Threading.Thread.Sleep(100); // Thời gian chờ để giả lập
                    backgroundWorker.ReportProgress(i * 10); // Cập nhật tiến độ
                }

                if (action == "cut")
                {
                    File.Move(sourceFile, destinationFile); // Cắt tệp
                }
                else if (action == "copy")
                {
                    File.Copy(sourceFile, destinationFile, true); // Sao chép tệp
                }
            }
            else
            {
                throw new FileNotFoundException("Tệp không tồn tại.");
            }
        }

        private void BackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage; // Cập nhật giá trị của ProgressBar
        }

        private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show("Có lỗi xảy ra: " + e.Error.Message, "Lỗi");
            }
            else
            {
                MessageBox.Show("Hoàn thành thao tác thành công!", "Thông báo");
            }
        }
        private string GetSelectedFileExtension()
        {
            switch (comboBox1.SelectedItem.ToString())
            {
                case "JPG":
                    return "jpg";
                case "PNG":
                    return "png";
                case "XLS":
                    return "xls";
                case "XLSX":
                    return "xlsx";
                case "DOC":
                    return "doc";
                case "DOCX":
                    return "docx";
                case "PPT":
                    return "ppt";
                case "PPTX":
                    return "pptx";
                case "PDF":
                    return "pdf";
                default:
                    return string.Empty;
            }
        }
    }
}
