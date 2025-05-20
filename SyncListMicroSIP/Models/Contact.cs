namespace SyncListMicroSIP.Models
{
    public class Contact
    {
        public string Number { get; set; }
        public string Name { get; set; }
        public string Firstname { get; set; } = "";
        public string Lastname { get; set; } = "";
        public string Phone { get; set; } = "";
        public string Mobile { get; set; } = "";
        public string Email { get; set; } = "";
        public string Address { get; set; } = "";
        public string City { get; set; } = "";
        public string State { get; set; } = "";
        public string Zip { get; set; } = "";
        public string Comment { get; set; } = "";
        public int Presence { get; set; } = 1;
        public int Starred { get; set; } = 0;
        public string Info { get; set; } = "";
    }
}
