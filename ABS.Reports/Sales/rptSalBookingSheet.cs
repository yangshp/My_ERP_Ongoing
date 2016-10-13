namespace ABS.Reports.Sales
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;

    /// <summary>
    /// Summary description for rptGRR.
    /// </summary> 
    public partial class rptSalBookingSheet : Telerik.Reporting.Report
    {
        public rptSalBookingSheet()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent(); 

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        public DateTime StartDate
        {
            get { return (DateTime)rpt_SalBookingReport.Parameters[0].Value; }
            set { rpt_SalBookingReport.Parameters[0].Value = value; }

        }
        public DateTime EndDate 
        {
            get { return (DateTime)rpt_SalBookingReport.Parameters[1].Value; }
            set { rpt_SalBookingReport.Parameters[1].Value = value; }
        }
        public int CompanyID
        {
            get { return (int)rpt_SalBookingReport.Parameters[2].Value; }
            set { rpt_SalBookingReport.Parameters[2].Value = value; }
        }

        public static object EtoWDO(object value1)
        {
            double d1 = Convert.ToDouble(value1);

            ABSConversion ns1 = new ABSConversion();
            return ns1.changeNumericToWords(d1);
        }
    }
}