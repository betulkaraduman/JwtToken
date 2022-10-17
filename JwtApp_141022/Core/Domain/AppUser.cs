namespace JwtApp_141022.Core.Domain
{
    public class AppUser:BaseClass
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
        public int AppRoleId { get; set; }
        public AppRole AppRole { get; set; }
        public AppUser()
        {
            AppRole=new AppRole();  
        }
    }
}
