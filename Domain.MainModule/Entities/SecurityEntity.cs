using Domain.MainModule.Core;
using Domain.MainModule.Enum;

namespace Domain.MainModule.Entities
{
    public class SecurityEntity : BaseEntity
    {
        public string UserName { get; set; }

        public string Credential { get; set; }

        public string Password { get; set; }

        public RolTypeEnum Role { get; set; }
    }
}
