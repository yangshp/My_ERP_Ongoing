using System;

namespace ABS.Reports.Accounting
{
    /// <summary>
    /// Summary description for ReceivedVoucherNew.
    /// </summary>
    public partial class ReceivedVoucherNew : Telerik.Reporting.Report
    {
        public ReceivedVoucherNew()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }


        public static object EtoWDO(object value1)
        {
            double d1 = Convert.ToDouble(value1);
            ABSClass ns1 = new ABSClass();
            return ns1.changeNumericToWords(d1);

        }


        public string pvparam
        {
            get
            {
                return (string)sqlDataSource1.Parameters[0].Value;
            }
            set
            {
                sqlDataSource1.Parameters[0].Value = value;
            }

        }

        public string pvparam1
        {
            get
            {
                return (string)sqlDataSource1.Parameters[1].Value;
            }
            set
            {
                sqlDataSource1.Parameters[1].Value = value;
            }

        }
    }
}