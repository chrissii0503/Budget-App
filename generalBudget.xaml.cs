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
using System.Windows.Shapes;

namespace BudgetWPF
{
    /// <summary>
    /// Interaction logic for generalBudget.xaml
    /// </summary>
    public partial class generalBudget : Window
    {
        calculations calc = new calculations();

        double income, tax, groceries, travel, cellphone, other, deductions;
        double vprice, vinsurance, vinterest, vdeposit, vtotal, princip, inter, insure, gtotal;
        double pprice, pinterest, interest, total_amnt, months, deposit, principal, hire;
        double check1, incomes;
        double after, save, newav;
        Int16 year;
        double calculation, calculate;

        public generalBudget()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(@"Data Source=CHRISLYNN\SQLEXPRESS;Initial Catalog=task2;Integrated Security=True");
            sqlCon.Open();
            SqlCommand sCmd = new SqlCommand("INSERT INTO tblBudget (GrossIncome,Tax,Groceries,TravelCosts,Cellphone,Other) VALUES (@GrossIncome,@Tax,@Groceries,@TravelCosts,@Cellphone,@Other)", sqlCon);
            sCmd.Parameters.AddWithValue("@GrossIncome", txtGross.Text);
            sCmd.Parameters.AddWithValue("@Tax", txtTax.Text);
            sCmd.Parameters.AddWithValue("@Groceries", txtGroceries.Text);
            sCmd.Parameters.AddWithValue("@TravelCosts", txtTravel.Text);
            sCmd.Parameters.AddWithValue("@Cellphone", txtCellphone.Text);
            sCmd.Parameters.AddWithValue("@Other", txtOther.Text);
            sCmd.ExecuteNonQuery();

            income = Convert.ToDouble(txtGross.Text);
            tax = Convert.ToDouble(txtTax.Text);
            groceries = Convert.ToDouble(txtGroceries.Text);
            travel = Convert.ToDouble(txtTravel.Text);
            cellphone = Convert.ToDouble(txtCellphone.Text);
            other = Convert.ToDouble(txtOther.Text);


            deductions = calc.GeneralAddition(tax, groceries, cellphone, travel, other);

            txtTotal.Text = deductions.ToString();
        }
        private void btnPCalculate_Click(object sender, RoutedEventArgs e)
        {

            SqlConnection sqlCon = new SqlConnection(@"Data Source=CHRISLYNN\SQLEXPRESS;Initial Catalog=task2;Integrated Security=True");
            sqlCon.Open();
            SqlCommand sCmd = new SqlCommand("INSERT INTO tblBudget (Rent,BuyProperty,Deposit,InterestRate,Years) VALUES (@Rent,@BuyProperty,@Deposit,@InterestRate,@Years)", sqlCon);
            sCmd.Parameters.AddWithValue("@Rent", txtRent.Text);
            sCmd.Parameters.AddWithValue("@BuyProperty", txtPPrice.Text);
            sCmd.Parameters.AddWithValue("@Deposit", txtPDeposit.Text);
            sCmd.Parameters.AddWithValue("@InterestRate", txtPInterest.Text);
            sCmd.Parameters.AddWithValue("@Years", txtYears.Text);
            sCmd.ExecuteNonQuery();

            pprice = Convert.ToDouble(txtPPrice.Text);
            pinterest = Convert.ToDouble(txtPInterest.Text);
            year = Convert.ToInt16(txtYears.Text);
            deposit = Convert.ToDouble(txtPDeposit.Text);
            hire = Convert.ToDouble(txtRent.Text);


            principal = calc.propertyminus(deposit, pprice);
            interest = calc.propertymultiply(principal, pinterest) * year / 100;
            total_amnt = calc.ptotal(principal, interest);
            months = calc.pmonth(total_amnt) / year;

            txtPRepayment.Text = months.ToString();
        }
        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            incomes = Convert.ToDouble(txtGross.Text);
            check1 = incomes / 3.3333; // income divided by a third
        }
        private void btnVCalculate_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(@"Data Source=CHRISLYNN\SQLEXPRESS;Initial Catalog=task2;Integrated Security=True");
            sqlCon.Open();
            SqlCommand sCmd = new SqlCommand("INSERT INTO tblBudget (VehicleMake,VehiclePrice,VehicleDeposit,VehicleInterest,Insurance) VALUES (@VehicleMake,@VehiclePrice,@VehicleDeposit,@VehicleInterest,@Insurance)", sqlCon);
            sCmd.Parameters.AddWithValue("@VehicleMake", txtVMake.Text);
            sCmd.Parameters.AddWithValue("@VehiclePrice", txtVPrice.Text);
            sCmd.Parameters.AddWithValue("@VehicleDeposit", txtVDeposit.Text);
            sCmd.Parameters.AddWithValue("@VehicleInterest", txtVInterest.Text);
            sCmd.Parameters.AddWithValue("@Insurance", txtVInsurance.Text);
            sCmd.ExecuteNonQuery();

            vprice = Convert.ToDouble(txtVPrice.Text);
            vinsurance = Convert.ToDouble(txtVInterest.Text);
            vinterest = Convert.ToDouble(txtVInterest.Text);
            vdeposit = Convert.ToDouble(txtVDeposit.Text);

            princip = calc.VehicleSubtraction(vprice, vdeposit);
            inter = calc.VehicleInterest(princip, vinterest) * 5 / 100;
            vtotal = calc.VehiclePlus(princip, inter);
            insure = calc.VehicleAdd(vinsurance, vtotal);
            gtotal = calc.VehicleDiv(insure) / 60;

            txtVLoan.Text = insure.ToString();
            txtInstalment.Text = gtotal.ToString();

        }
        private void btnAvailable_Click(object sender, RoutedEventArgs e)
        {
            calculate = calc.Calculate(deductions, hire, months, gtotal);
            calculation = calc.Calculation(income) - calculate;

            txtAvailability.Text = calculation.ToString();
        }

        private void btnShow_Click(object sender, RoutedEventArgs e)
        {
            save = Convert.ToDouble(txtAmount.Text);
            after = Convert.ToDouble(txtNewAvail.Text);

            calculate = calc.Calculate(deductions, hire, months, gtotal);
            calculation = calc.Calculation(income) - calculate;

            newav = calc.Calculation(income) - calc.Saved(save);
           
            txtNewAvail.Text = newav.ToString();
        }
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

    }
}
