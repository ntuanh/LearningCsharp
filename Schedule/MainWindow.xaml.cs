using System;
using System.Data.SqlClient;
using System.Text;
using System.Windows;



namespace Schedule
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            TestDatabaseConnection();
        }

        private void button_Click_2(object sender, RoutedEventArgs e)
        {
            R2Time round2Window = new R2Time();
            round2Window.WindowState = WindowState.Maximized;
            round2Window.Show();
            this.Close();
        }

        // ✅ Hàm kiểm tra kết nối và in danh sách bảng
        private void TestDatabaseConnection()
        {
            string connectionString = "Server=NTUANH\\SQLEXPRESS;Database=KTPM;Trusted_Connection=True;TrustServerCertificate=True;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    MessageBox.Show("✅ Kết nối thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);

                    // Lấy danh sách bảng trong database
                    StringBuilder tablesList = new StringBuilder();
                    string query = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE'";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            tablesList.AppendLine(reader["TABLE_NAME"].ToString());
                        }
                    }

                    // Hiển thị danh sách bảng
                    if (tablesList.Length > 0)
                    {
                        MessageBox.Show("📋 Danh sách bảng:\n" + tablesList.ToString(), "Thông tin Database", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("⚠️ Không có bảng nào trong database!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("❌ Lỗi kết nối: " + ex.Message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
