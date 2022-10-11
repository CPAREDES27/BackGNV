using Newtonsoft.Json;

namespace Domain.MainModule.Settings
{
    public class ErrorDetailsEntity
    {
        public int StatusCode { get; set; }
        public string InternalCode { get; set; }
        public string Message { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
