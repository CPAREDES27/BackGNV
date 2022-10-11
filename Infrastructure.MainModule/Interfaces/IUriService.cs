using Application.Dto;
using Application.Dto.MaintenanceUser;
using System;

namespace Infrastructure.MainModule.Interfaces
{
    public interface IUriService
    {
        Uri GetPostPaginationUri(PrevaluationQueryFilterDTO filter, string actionUrl);
        Uri GetPostPaginationUserUri(FilterUserDTO filter, string actionUrl);
        Uri GetPostPaginationProductUri(ProductQueryFilterDTO filter, string actionUrl);
    }
}
