using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KiemTraTongSoFile
{
    public partial class ConnectionDatabase : Form
    {
        private string connectionString = "Data Source=LAPTOP-VI7NDRKV\\SQLEXPRESS;Initial Catalog=economic;Integrated Security=True";
        public ConnectionDatabase()
        {
            InitializeComponent();
        }

        
        private void ConnectionDatabase_Load(object sender, EventArgs e)
        {
            LoadData(); // Gọi hàm tải dữ liệu khi form được load
        }

        private void LoadData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open(); // Mở kết nối đến cơ sở dữ liệu

                    string query = "SELECT(Id, FirstName, LastName) FROM Customer"; // Câu lệnh SQL để lấy dữ liệu từ bảng

                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection); // Dùng SqlDataAdapter để lấy dữ liệu
                    DataTable dataTable = new DataTable(); // Tạo một DataTable để chứa dữ liệu
                    dataAdapter.Fill(dataTable); // Đổ dữ liệu vào DataTable

                    dataGridView1.DataSource = dataTable; // Hiển thị dữ liệu trên DataGridView
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra khi kết nối với cơ sở dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
