using Phumla_System.Business;
using Phumla_System.Data;
using System;
using System.Windows.Forms;

namespace Phumla_System.Presentation
{
    public partial class MainForm : Form
    {
        #region Variables
        private int childFormNumber = 0;

        //forms
        private CreateBookingForm createBookingForm;
        private CreateNewCustomer createNewCustomer;
        private BookingSearch bookingSearch;
        private CancelBooking cancelBooking;
        private CustomerListing customerListing;
        private LogIn logIn;
        private ChangeBooking changeBooking;
        private OccupancyLevelReport occupancyLevelReport;
        private ReservationCancellationReport reservationCancellationReport;
        private Payment payment;

        //controllers
        private BookingController bookingController;
        private CustomerController customerController;
        private RoomController roomController;
        private Booking booking;
        #endregion

        #region Constructor
        public MainForm()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            bookingController = new BookingController();
            customerController = new CustomerController();
            roomController = new RoomController();
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.MdiChildActivate += MainForm_MdiChildActivate;
        }

        #endregion

        private void MainForm_MdiChildActivate(object sender, EventArgs e)
        {
            ShowLogo();
        }

        #region create childforms
        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }
        #endregion

        #region Create a New ChildForm
        public void CreateBookingForm()
        {
            createBookingForm = new CreateBookingForm(bookingController, customerController);
            createBookingForm.MdiParent = this;
            createBookingForm.StartPosition = FormStartPosition.CenterParent;
            createBookingForm.Dock = DockStyle.Fill;
        }

        public void CreateNewCustomerForm()
        {
            createNewCustomer = new CreateNewCustomer();
            createNewCustomer.MdiParent = this;
            createNewCustomer.StartPosition = FormStartPosition.CenterParent;
            createNewCustomer.Dock = DockStyle.Fill;
        }

        public void BookingSearchForm()
        {
            bookingSearch = new BookingSearch();
            bookingSearch.MdiParent = this;
            bookingSearch.StartPosition = FormStartPosition.CenterParent;
            bookingSearch.Dock = DockStyle.Fill;
        }

        public void CancelBookingForm()
        {
            cancelBooking = new CancelBooking();
            cancelBooking.MdiParent = this;
            cancelBooking.StartPosition = FormStartPosition.CenterParent;
            cancelBooking.Dock = DockStyle.Fill;
        }

        public void ChangeBookingForm()
        {
            changeBooking = new ChangeBooking();
            changeBooking.MdiParent = this;
            changeBooking.StartPosition = FormStartPosition.CenterParent;
            changeBooking.Dock = DockStyle.Fill;
        }

        public void CustomerListingForm()
        {
            customerListing = new CustomerListing();
            customerListing.MdiParent = this;
            customerListing.StartPosition = FormStartPosition.CenterParent;
            customerListing.Dock = DockStyle.Fill;
        }

        public void LoginForm()
        {
            logIn = new LogIn();
            logIn.MdiParent = this;
            logIn.StartPosition = FormStartPosition.CenterParent;
            logIn.Dock = DockStyle.Fill;
        }

        public void OccupancyLevelReportForm()
        {
            occupancyLevelReport = new OccupancyLevelReport();
            occupancyLevelReport.MdiParent = this;
            occupancyLevelReport.StartPosition = FormStartPosition.CenterParent;
            occupancyLevelReport.Dock = DockStyle.Fill;
        }

        public void ReservationCancellationReportForm()
        {
            reservationCancellationReport = new ReservationCancellationReport();
            reservationCancellationReport.MdiParent = this;
            reservationCancellationReport.StartPosition = FormStartPosition.CenterParent;
            reservationCancellationReport.Dock = DockStyle.Fill;
        }

        public void PaymentForm()
        {
            payment = new Payment(booking);
            payment.MdiParent = this;
            payment.StartPosition = FormStartPosition.CenterParent;
            payment.Dock = DockStyle.Fill;
        }
        #endregion

        #region ToolStrip Menus for Listing
        private void OpenChildForm(Form childForm)
        {
            // Close all existing child forms
            foreach (Form f in this.MdiChildren)
            {
                f.Close();
            }

            // Clear main form content
            //this.pictureBox1.Visible = false;

            // Set up the child form
            childForm.MdiParent = this;
           // childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            childForm.Show();
            ShowLogo();
        }

        private void ShowLogo()
        {
            if (this.MdiChildren.Length == 0)
            {
                pictureBox1.Visible = true;
                pictureBox1.BringToFront();
            }
            else
            {
                pictureBox1.Visible = false;
            }
        }

        private void customerSearchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (customerListing == null || customerListing.IsDisposed)
            {
                customerListing = new CustomerListing();
            }
            OpenChildForm(customerListing);
        }

        private void createNewCustomerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (createNewCustomer == null || createNewCustomer.IsDisposed)
            {
                createNewCustomer = new CreateNewCustomer();
            }
            OpenChildForm(createNewCustomer);
        }


        private void changeBookingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (changeBooking == null || changeBooking.IsDisposed)
            {
                changeBooking = new ChangeBooking();
            }
            OpenChildForm(changeBooking);
        }

        private void cancelBookingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cancelBooking == null || cancelBooking.IsDisposed)
            {
                cancelBooking = new CancelBooking();
            }
            OpenChildForm(cancelBooking);
        }

        private void occupancyLevelReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (occupancyLevelReport == null || occupancyLevelReport.IsDisposed)
            {
                occupancyLevelReport = new OccupancyLevelReport();
            }
            OpenChildForm(occupancyLevelReport);
        }

        private void reservationCancellationReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (reservationCancellationReport == null || reservationCancellationReport.IsDisposed)
            {
                reservationCancellationReport = new ReservationCancellationReport();
            }
            OpenChildForm(reservationCancellationReport);
        }
        #endregion

        private void MainForm_Load(object sender, EventArgs e)
        {
            // This line of code loads data into the 'bookingsDatabaseDataSet.Booking' table.
            this.bookingTableAdapter.Fill(this.bookingsDatabaseDataSet.Booking);
            this.IsMdiContainer = true;
        }

        private void notificationsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void createNewBookingToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (createBookingForm == null || createBookingForm.IsDisposed)
            {
                createBookingForm = new CreateBookingForm(bookingController, customerController);
            }
            OpenChildForm(createBookingForm);
        }

        private void newBookingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bookingSearch == null || bookingSearch.IsDisposed)
            {
                bookingSearch = new BookingSearch();
            }
            OpenChildForm(bookingSearch);
        }
    }
}