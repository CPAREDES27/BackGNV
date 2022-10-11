using Domain.MainModule.Enum;

namespace Application.Dto
{
    public class SecurityDTO
    {
        public string UserName { get; set; }

        public string Credential { get; set; }

        public string Password { get; set; }

        public RolTypeEnum? Role { get; set; }
    }
}
