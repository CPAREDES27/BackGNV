namespace Application.Dto.MaintenanceUser
{
    public class FilterUserDTO
    {
        public int RolId { get; set; }
        public string NumDocumento { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
    }
}
