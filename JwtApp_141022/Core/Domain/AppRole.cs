namespace JwtApp_141022.Core.Domain
{
    public class AppRole:BaseClass
    {

        public string? Definition { get; set; }
        public List<AppUser> AppUsers { get; set; }
        public AppRole()
        {
            AppUsers=new List<AppUser>();   
        }
    }
}
