namespace Phumla_System.Business
{
    public class Receptionist
    {
        public int ReceptionistID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public string Shift { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public Receptionist(int id, string name, string surname, string phone, string shift, string email, string password)
        {
            ReceptionistID = id;
            Name = name;
            Surname = surname;
            Phone = phone;
            Shift = shift;
            Email = email;
            Password = password;
        }
    }
}
