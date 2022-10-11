using Application.Dto;
using Application.Dto.MaintenanceUser;
using Infrastructure.MainModule.Interfaces;
using System;

namespace Infrastructure.MainModule.Services
{
    public class UriService : IUriService
    {
        private readonly string baseUri;

        public UriService(string baseUri)
        {
            this.baseUri = baseUri;
        }
        public Uri GetPostPaginationUri(PrevaluationQueryFilterDTO filter, string actionUrl)
        {
            string baseUrl = $"{baseUri}{actionUrl}";
            return new Uri(baseUrl);
        }

        public Uri GetPostPaginationUserUri(FilterUserDTO filter, string actionUrl)
        {
            string baseUrl = $"{baseUri}{actionUrl}";
            return new Uri(baseUrl);
        }

        public Uri GetPostPaginationProductUri(ProductQueryFilterDTO filter, string actionUrl)
        {
            string baseUrl = $"{baseUri}{actionUrl}";
            return new Uri(baseUrl);
        }
    }
}
