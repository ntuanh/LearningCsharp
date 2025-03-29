using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Schedule
{
    public partial class R2Time
    {
        private string connectionString = "Server=NTUANH\\SQLEXPRESS;Database=KTPM;Integrated Security=True;";

        public R2Time()
        {
            InitializeComponent();
        }

        private void backToHomepage(object sender, RoutedEventArgs e)
        {
            MainWindow homepage = new MainWindow();
            homepage.WindowState = WindowState.Maximized;
            homepage.Show();
            this.Close();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string userInput = SearchBox.Text.Trim(); // Lấy MSSV từ TextBox
            if (string.IsNullOrEmpty(userInput))
            {
                MessageBox.Show("Vui lòng nhập MSSV để tìm kiếm.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            SearchMSSV(userInput);
        }



        private void SearchMSSV(string mssv)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM Hoso WHERE MSSV = @MSSV";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MSSV", mssv);
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);

                            if (dt.Rows.Count > 0)
                            {
                                string result = "Kết quả tìm kiếm:\n";
                                foreach (DataRow row in dt.Rows)
                                {
                                    result += $"MSSV: {row["MSSV"]}, Họ tên: {row["HoTen"]}\n";
                                    break;
                                }

                                ResultText.Text = result;  // Hiển thị kết quả
                                ResultBox.Visibility = Visibility.Visible;  // Hiện Rectangle
                            }
                            else
                            {
                                ResultText.Text = "Không tìm thấy sinh viên này.";
                                ResultBox.Visibility = Visibility.Visible;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    ResultText.Text = "Lỗi khi tìm kiếm: " + ex.Message;
                    ResultBox.Visibility = Visibility.Visible;
                }
            }
        }

    }
}
