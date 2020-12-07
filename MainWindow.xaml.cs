using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BudgetWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            SqlConnection sqlCon = new SqlConnection(@"Data Source=CHRISLYNN\SQLEXPRESS;Initial Catalog=task2;Integrated Security=True");
            sqlCon.Open();
            SqlCommand sCmd = new SqlCommand("INSERT INTO tblUser (FullName,Email,Username,Password,ConfirmPassword) VALUES (@FullName,@Email,@Username,@Password,@ConfirmPassword)", sqlCon);
            sCmd.Parameters.AddWithValue("@FullName", txtName.Text);
            sCmd.Parameters.AddWithValue("@Email", txtEmail.Text);
            sCmd.Parameters.AddWithValue("@Username", txtUsername.Text);
            sCmd.Parameters.AddWithValue("@Password", txtPassword.Text);
            sCmd.Parameters.AddWithValue("@ConfirmPassword", txtConfirmPassword.Text);
            sCmd.ExecuteNonQuery();

            generalBudget gb = new generalBudget();
            gb.Show();
            this.Close();
        }
        private void btnLogins_Click(object sender, RoutedEventArgs e)
        {
            login log = new login();
            log.Show();
            this.Close();
        }

    }
}
