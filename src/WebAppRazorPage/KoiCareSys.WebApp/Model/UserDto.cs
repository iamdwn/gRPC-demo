namespace KoiCareSys.WebApp.Model
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public UserStatus Status { get; set; }
        public string PhoneNumber { get; set; }
        public UserRole Role { get; set; }
    }
}
