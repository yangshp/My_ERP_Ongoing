namespace ABS.Reports.Production
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
    public partial class rptSizeStopage : Telerik.Reporting.Report
    {
        public rptSizeStopage()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }
       
        public DateTime paramDateFrom
        {
            get
            {
                return (DateTime)sqlDataSource1.Parameters[0].Value;
            }
            set
            {
                sqlDataSource1.Parameters[0].Value = value;
            }
        }

        public DateTime ?paramDateTo
        {
            get
            {
                return (DateTime)sqlDataSource1.Parameters[1].Value;
            }
            set
            {
                sqlDataSource1.Parameters[1].Value = value;
            }
        }

        public int? paramShift
        {
            get
            {
                return (int)sqlDataSource1.Parameters[2].Value;
            }
            set
            {
                sqlDataSource1.Parameters[2].Value = value;
            }
        }
        public int ?paramMachine
        {
            get
            {
                return (int)sqlDataSource1.Parameters[3].Value;
            }
            set
            {
                sqlDataSource1.Parameters[3].Value = value;
            }

        }
 
        public int companyId
        {
            get
            {
                return (int)sqlDataSource1.Parameters[4].Value;
            }
            set
            {
                sqlDataSource1.Parameters[4].Value = value;
            }
        }
    }
}