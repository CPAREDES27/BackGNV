using Application.Manager.Interfaces;
using Application.Services.Util;
using AutoMapper;
using Domain.MainModule.Entities.ReportDashboard;
using Infrastructure.MainModule.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.Services.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportDashboardController : Controller
    {
        private readonly IReportDashboardManager reportDashboardManager;
        private readonly IMapper mapper;
        private readonly IUriService uriService;

        public ReportDashboardController(
            IReportDashboardManager reportDashboardManager,
            IMapper mapper,
            IUriService uriService)
        {
            this.reportDashboardManager = reportDashboardManager;
            this.mapper = mapper;
            this.uriService = uriService;
        }

        [HttpGet("GetDashboarAsesorById")]
        public async Task<IActionResult> GetDashboarAsesorById(int IdAsesor,DateTime FechaInicio, DateTime FechaFin)
        {
            ListAsesorCabeceraDashboard resultDashboard = await reportDashboardManager.GetTotalesAsesorById(IdAsesor, FechaInicio, FechaFin);

            if (resultDashboard == null)
            {
                return Ok(new { valid = false, message = Constants.InvalidReportDashBoard });
            }

            return Ok(new { valid = true, message = Constants.ResponseReportDashBoard, resultDashboard });
        }

        [HttpPost("DashboarDetalleAsesorById")]
        public async Task<IActionResult> DashboarDetalleAsesorById(int IdAsesor, DateTime FechaInicio, DateTime FechaFin)
        {
            var resultDetalle = await reportDashboardManager.GetListDetalleAsesorById(IdAsesor, FechaInicio, FechaFin);
            if (resultDetalle == null)
            {
                return Ok(new { valid = false, message = Constants.InvalidReportDashBoard });
            }
            return Ok(new { valid = true, message = Constants.ResponseReportDashBoard, resultDetalle });
        }

        [HttpGet("GetDashboarGeneral")]
        public async Task<IActionResult> GetDashboarGeneral(int IdAsesor, DateTime FechaInicio, DateTime FechaFin)
        {
            ListCabeceraDashboard resultDashboard = await reportDashboardManager.GetDashboarGeneral(FechaInicio, FechaFin);

            if (resultDashboard == null)
            {
                return Ok(new { valid = false, message = Constants.InvalidReportDashBoard });
            }

            return Ok(new { valid = true, message = Constants.ResponseReportDashBoard, resultDashboard });

        }

        [HttpPost("DashboarGeneralDetalle")]
        public async Task<IActionResult> DashboarGeneralDetalle(int IdAsesor, DateTime FechaInicio, DateTime FechaFin)
        {
            var resultDetalle = await reportDashboardManager.DashboarGeneralDetalle(IdAsesor, FechaInicio, FechaFin);
            if (resultDetalle == null)
            {
                return Ok(new { valid = false, message = Constants.InvalidReportDashBoard });
            }
            return Ok(new { valid = true, message = Constants.ResponseReportDashBoard, resultDetalle });
        }

        [HttpPost("GetListaReporteSAP")]
        public async Task<IActionResult> GetListaReporteSAP(int IdUsuario, DateTime FechaInicio, DateTime FechaFin)
        {
            var resultDetalle = await reportDashboardManager.GetListaReporteSAP(IdUsuario, FechaInicio, FechaFin);
            if (resultDetalle == null)
            {
                return Ok(new { valid = false, message = Constants.InvalidReportDashBoard });
            }
            return Ok(new { valid = true, message = Constants.ResponseReportDashBoard, resultDetalle });
        }

        [HttpPost("GetListaReporteGrafico")]
        public async Task<IActionResult> GetListaReporteGrafico(int IdUsuario, DateTime FechaInicio, DateTime FechaFin)
        {
            var resultDetalle = await reportDashboardManager.GetListaReporteGrafico(IdUsuario, FechaInicio, FechaFin);
            if (resultDetalle == null)
            {
                return Ok(new { valid = false, message = Constants.InvalidReportDashBoard });
            }
            return Ok(resultDetalle);
        }

    }
}
