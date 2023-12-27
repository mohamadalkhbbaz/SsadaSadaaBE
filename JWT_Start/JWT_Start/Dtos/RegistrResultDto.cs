using System;

namespace JWT_Start.Dtos
{
    public class RegistrResultDto
    {
        public string Message { get; set; }
        public bool IsAuthentecated { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public List<String> Roles { get; set; }
        public string Token { get; set; }
        public DateTime ExpireOn { get; set; }
    }
}
