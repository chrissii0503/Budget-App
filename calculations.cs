using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetWPF
{
    public class calculations
    {
        public double GeneralAddition(double tax, double groceries, double travel,
                    double cellphone, double other)
        {
            return tax + groceries + travel + cellphone + other;
        }

        public double VehicleSubtraction(double vprice, double vdeposit)
        {
            return vprice - vdeposit;

        }
        public double VehicleDiv(double insure)
        {
            return insure;
        }
        public double VehicleAdd(double vinsurance, double vtotal)
        {
            return vinsurance + vtotal;

        }
        public double VehiclePlus(double princi, double inter)
        {
            return princi + inter;
        }
        public double VehicleInterest(double princip, double vinterest)
        {
            return princip * vinterest;
        }
        public double propertyminus(double deposit, double pprice)
        {
            return pprice - deposit;
        }
        public double propertymultiply(double principal, double pinterest)
        {
            return principal * pinterest;
        }
        public double ptotal(double principal, double interest)
        {
            return principal + interest;
        }
        public double pmonth(double total_amnt)
        {
            return total_amnt;
        }
        public double Save(double sav)
        {
            return sav;
        }
        public double Calculate(double deductions , double hire, double months, double gtotal)
        {
            return deductions + hire + months + gtotal;
        }
        public double Calculation (double income)
        {
            return income;
        }
        public double Saved(double save)
        {
            return save;
        }
    }


}
