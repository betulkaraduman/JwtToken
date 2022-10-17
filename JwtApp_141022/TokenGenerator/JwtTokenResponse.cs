namespace JwtApp_141022.TokenGenerator
{
    public class JwtTokenResponse
    {
        public string Token { get; set; }
        public DateTime ExpireDate { get; set; }
        public JwtTokenResponse(string token, DateTime expireDate)
        {
            Token = token;
            ExpireDate = expireDate;
        }
    }
}
