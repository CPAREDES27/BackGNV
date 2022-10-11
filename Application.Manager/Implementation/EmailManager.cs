using Application.Dto;
using Application.Manager.Interfaces;
using Application.Services.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Manager.Implementation
{
    public class EmailManager : IEmailManager
    {
        private readonly IEmailService _emailService;
        private readonly IMapper _mapper;
        
        public EmailManager(
             IEmailService emailService,
             IMapper mapper
            )
        {
            this._emailService = emailService;
            this._mapper = mapper;
        }

        public Task<bool> SendEmailAsync(EmailDTO emailDto)
        {
            return _emailService.SendEmailAsync(emailDto);
        }
    }
}
