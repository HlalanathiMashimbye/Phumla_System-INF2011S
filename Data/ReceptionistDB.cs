using System;
using System.Collections.ObjectModel;
using System.Data;
using Phumla_System.Business;

namespace Phumla_System.Data
{
    public class ReceptionistDB : DB
    {
        #region Data Members
        private string receptionistTable = "Receptionist";
        private string sqlLocalReceptionist = "SELECT * FROM Receptionist";
        private Collection<Receptionist> receptionists;
        #endregion

        #region Property Methods: Collection
        public Collection<Receptionist> AllReceptionists
        {
            get
            {
                return receptionists;
            }
        }
        #endregion

        #region Constructor
        public ReceptionistDB() : base()
        {
            receptionists = new Collection<Receptionist>();
            FillDataSet(sqlLocalReceptionist, receptionistTable);
            AddReceptionistsToCollection();
        }
        #endregion

        #region Utility Methods
        public DataSet GetDataSet()
        {
            return DataSet;
        }

        private void AddReceptionistsToCollection()
        {
            DataRow myRow;
            foreach (DataRow myRow_loopVariable in DataSet.Tables[receptionistTable].Rows)
            {
                myRow = myRow_loopVariable;
                if (myRow.RowState != DataRowState.Deleted)
                {
                    var aReceptionist = new Receptionist(
                        Convert.ToInt32(myRow["ReceptionistID"]),
                        Convert.ToString(myRow["Name"]).TrimEnd(),
                        Convert.ToString(myRow["Surname"]).TrimEnd(),
                        Convert.ToString(myRow["Phone"]).TrimEnd(),
                        Convert.ToString(myRow["Shift"]).TrimEnd(),
                        Convert.ToString(myRow["Email"]).TrimEnd(),
                        Convert.ToString(myRow["Password"]).TrimEnd()  // Ensure password is handled securely
                    );

                    receptionists.Add(aReceptionist);
                }
            }
        }

        private void FillRow(DataRow aRow, Receptionist aReceptionist, DBOperation operation)
        {
            if (operation == DBOperation.Add)
            {
                // Assuming ReceptionistID is auto-incremented by the database
            }

            aRow["Name"] = aReceptionist.Name;
            aRow["Surname"] = aReceptionist.Surname;
            aRow["Phone"] = aReceptionist.Phone;
            aRow["Shift"] = aReceptionist.Shift;
            aRow["Email"] = aReceptionist.Email;
            aRow["Password"] = aReceptionist.Password; // Note: Consider hashing passwords in production
        }
        #endregion

        #region Database Operations CRUD
        public void DataSetChange(Receptionist receptionist, DBOperation operation)
        {
            DataRow receptionistRow = null;
            switch (operation)
            {
                case DBOperation.Add:
                    receptionistRow = DataSet.Tables[receptionistTable].NewRow();
                    FillRow(receptionistRow, receptionist, operation);
                    DataSet.Tables[receptionistTable].Rows.Add(receptionistRow);
                    break;
                case DBOperation.Change:
                    receptionistRow = DataSet.Tables[receptionistTable].Rows.Find(receptionist.ReceptionistID);
                    if (receptionistRow != null)
                    {
                        FillRow(receptionistRow, receptionist, operation);
                    }
                    break;
                case DBOperation.Delete:
                    receptionistRow = DataSet.Tables[receptionistTable].Rows.Find(receptionist.ReceptionistID);
                    if (receptionistRow != null)
                    {
                        receptionistRow.Delete();
                    }
                    break;
            }
        }

        public bool UpdateDataSource()
        {
            return UpdateDataSource(sqlLocalReceptionist, receptionistTable);
        }
        #endregion
    }
}
