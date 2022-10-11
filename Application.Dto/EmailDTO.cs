using System.Collections.Generic;

namespace Application.Dto
{
    public class EmailDTO
    {
        public List<string> ListRecipients { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
