namespace ABS.Reports.Commercial
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;

    /// <summary>
    /// Summary description for rptBillOfExchange2.
    /// </summary>
    public partial class rptBillOfExchange2 : Telerik.Reporting.Report
    {
        public rptBillOfExchange2()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }
        public int pramDCID
        {
            get
            {
                return (int)rpt_ComBillOfExchange.Parameters[0].Value;
            }
            set
            {
                rpt_ComBillOfExchange.Parameters[0].Value = value;
            }
        }

        public static object EtoWDO(object value1)
        {
            double d1 = Convert.ToDouble(value1);

            ABSConversion ns1 = new ABSConversion();
            return ns1.changeNumericToWords(d1);
        }
    }
}