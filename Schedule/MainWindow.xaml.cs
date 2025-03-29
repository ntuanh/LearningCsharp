using System;
using System.Data.SqlClient;
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
            //Round2 round2Window = new Round2();
            //round2Window.WindowState = WindowState.Maximized;
            //round2Window.Show();
            //this.Close();
        }

        private void button_Click_2(object sender, RoutedEventArgs e)
        {
            R2Time round2Window = new R2Time();
            round2Window.WindowState = WindowState.Maximized;
            round2Window.Show();
            this.Close();
        }

        // ✅ Hàm kiểm tra kết nối cơ sở dữ liệu
        private void TestDatabaseConnection()
        {
            string connectionString = "Server=NTUANH\\SQLEXPRESS;Database=KTPM;Trusted_Connection=True;TrustServerCertificate=True;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    MessageBox.Show("✅ Kết nối thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("❌ Lỗi kết nối: " + ex.Message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        // ✅ Gọi hàm này khi nhấn nút kiểm tra kết nối
        //private void button_TestConnection_Click(object sender, RoutedEventArgs e)
        //{
        //    TestDatabaseConnection();
        //}
    }
}
