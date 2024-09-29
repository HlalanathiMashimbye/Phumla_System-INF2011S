using System.Collections.ObjectModel;
using Phumla_System.Data;
using static Phumla_System.Data.DB;

namespace Phumla_System.Business
{
    public class ReceptionistController
    {
        #region Data Members
        private ReceptionistDB receptionistDB;  // Assuming you have a similar DB class for Receptionists
        private Collection<Receptionist> receptionists;
        #endregion

        #region Properties
        public Collection<Receptionist> AllReceptionists
        {
            get { return receptionists; }
        }
        #endregion

        #region Constructor
        public ReceptionistController()
        {
            receptionistDB = new ReceptionistDB();
            receptionists = receptionistDB.AllReceptionists;  // Load receptionists from DB
        }
        #endregion

        #region Database Communication
        public void DataMaintenance(Receptionist receptionist, DBOperation operation)
        {
            int index = 0;
            receptionistDB.DataSetChange(receptionist, operation);
            switch (operation)
            {
                case DBOperation.Add:
                    receptionists.Add(receptionist);
                    break;
                case DBOperation.Change:
                    index = FindIndex(receptionist);
                    if (index >= 0)
                    {
                        receptionists[index] = receptionist;
                    }
                    break;
                case DBOperation.Delete:
                    index = FindIndex(receptionist);
                    if (index >= 0)
                    {
                        receptionists.RemoveAt(index);
                    }
                    break;
            }
        }

        public bool FinalizeChanges()
        {
            return receptionistDB.UpdateDataSource();
        }

        private int FindIndex(Receptionist receptionist)
        {
            for (int i = 0; i < receptionists.Count; i++)
            {
                if (receptionists[i].ReceptionistID == receptionist.ReceptionistID)
                {
                    return i;
                }
            }
            return -1;
        }

        public bool ValidateCredentials(string email, string password)
        {
            foreach (var receptionist in receptionists)
            {
                if (receptionist.Email == email && receptionist.Password == password)
                {
                    return true; // Credentials are correct
                }
            }
            return false; // Credentials are incorrect
        }
        #endregion
    }
}
