namespace PlanejaiFront.Models
{
    public class UserModel
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? PhoneNumber { get; set; }

        public bool IsValid()
        {
            if (Name == null || Email == null || Password == null || PhoneNumber == null) return false;

            return true;
        }
    }
}
