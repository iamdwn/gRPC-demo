namespace KoiCareSys.Data.DTO
{
    public class RegisterNewUserDTO
    {
        public String Email { get; set; } = String.Empty;
        public String Password { get; set; } = String.Empty;
        public String FullName { get; set; } = String.Empty;
        public String PhoneNumber { get; set; } = String.Empty;
        public Enums.UserRole Role { get; set; } = Enums.UserRole.User;
        public Enums.UserStatus Status { get; set; } = Enums.UserStatus.Active;
    }
}
