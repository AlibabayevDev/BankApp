namespace BankApp.WebAdminPanel.Models.Client
{
    public class ClientModel : BaseModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string FatherName { get; set; }
        public string FIN { get; set; }
        public string Seriya { get; set; }
        public string Phone { get; set; }
        public string Adress { get; set; }
        public int AccountNumber { get; set; }
        public string PlaceOfBirth { get; set; }
        public string Citizenship { get; set; }
        public string Studies { get; set; }
        public string Email { get; set; }
        public DateTime PassportEndTime { get; set; }
        public DateTime BirthDate { get; set; } = DateTime.Now;
        public DateTime AccountingTime { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public DateTime PassportSubmissionTime { get; set; } = DateTime.Now;
        public bool IsDeleted { get; set; }
    }
}
