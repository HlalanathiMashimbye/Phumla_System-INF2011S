﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Phumla_System.Business;
using Phumla_System;
using Phumla_System.Presentation;

namespace Phumla_System
{
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            BookingController bookingController = new BookingController();
            CustomerController customerController = new CustomerController();

            Application.Run(new LogIn());
            //Application.Run(new TestForm());
        }
    }
}
