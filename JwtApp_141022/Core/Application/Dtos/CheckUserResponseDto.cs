namespace JwtApp_141022.Core.Application.Dtos
{
    public class CheckUserResponseDto
    {
        public string? Username { get; set; }
        public string? Role { get; set; }
        public int Id { get; set; }
        public bool IsExist { get; set; }
    }
}
