namespace KoiCareSys.Common
{
    public class AppConfig
    {
        public static ConnectionStrings ConnectionStrings { get; set; } = null;

    }
    public class ConnectionStrings
    {
        public string DefaultConnection { get; set; } = string.Empty;
    }
}
