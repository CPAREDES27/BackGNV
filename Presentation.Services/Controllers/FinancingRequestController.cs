using Application.Dto;
using Application.Dto.UploadDocuments.RequestFinancing;
using Application.Manager.Interfaces;
using Application.Services.Util;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading.Tasks;

namespace Presentation.Services.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FinancingRequestController : ControllerBase
    {
        private readonly IFinancingRequestManager financingRequestManager;
        private readonly IWorkshopManager workshopManager;
        private readonly ILogger<FinancingRequestController> logger;

        #region Property  
        private IHostingEnvironment _hostingEnvironment;
        #endregion

        public FinancingRequestController(
            IFinancingRequestManager financingRequestManager,
            IWorkshopManager workshopManager,
            ILogger<FinancingRequestController> logger,
            IHostingEnvironment hostingEnvironment)
        {
            this.financingRequestManager = financingRequestManager; 
            this.logger = logger;
            _hostingEnvironment = hostingEnvironment;
        }
         
        [HttpPost("CustomerFinancingRecord")]
        public async Task<IActionResult> CustomerFinancingRecord([FromBody] FinancingRequestDTO financingRequestDTO)
        {
            CustomerFinancingDTO customerFinancingDTO = await financingRequestManager.CustomerFinancingRecord(financingRequestDTO);
            if (customerFinancingDTO.IdSfCliente < 0)
            {
                return BadRequest(new { valid = false, message = FinancingRequestConst.InvalidFinancingRequest });
            }

           
            //financigRequest.IdSfCliente = customerFinancingDTO.IdSfCliente;
            //if(financigRequest.IdSfCliente != null)
            //{
            //    financigRequest.Mensaje = FinancingRequestConst.SuccessFinancingRequest;
            //    financigRequest.Valid = true;
            //}else
            //{
            //    financigRequest.Mensaje = FinancingRequestConst.InvalidFinancingRequest;
            //    financigRequest.Valid = false;
            //}
            return Ok(new { valid = true, message = FinancingRequestConst.SuccessUploadDocuments, IdSfCliente = customerFinancingDTO.IdSfCliente });
            //return Ok(financigRequest); 
        }

        [HttpPost("CustomerFinancingRecordTemp")]
        public async Task<IActionResult> CustomerFinancingRecordTemp([FromBody] FinancingRequestTempDTO financingRequestDTO)
        {
            var customerFinancingDTO = await financingRequestManager.CustomerFinancingRecordTemp(financingRequestDTO);
            if (customerFinancingDTO == false)
            {
                return BadRequest(new { valid = false, message = FinancingRequestConst.InvalidFinancingRequest });
            }

            return Ok(new { valid = true, message = FinancingRequestConst.Success40, IdSfCliente = 0 });
        }

        [HttpGet("ListTempSolicitud")]
        public async Task<IActionResult> ListTempSolicitud(int IdtipoDocumento, string NumDocumento, int NumPag, int NumReg)
        {
           
            var resultado = await financingRequestManager.ListPendienteTempSolicitud(IdtipoDocumento, NumDocumento, NumPag, NumReg);
            if (resultado == null)
            {
                return Ok(new { valid = false, message = Constants.InvalidListEvluationClient });
            }
            return Ok(resultado);
        }

        [HttpGet("GetTempSolicitudById")]
        public async Task<IActionResult> GetTempSolicitudById(Int64 IdSfCliente)
        {

            var resultado = await financingRequestManager.ListPendienteSolicitidById(IdSfCliente);
            if (resultado == null)
            {
                return Ok(new { valid = false, message = Constants.InvalidListEvluationClient });
            }
            return Ok(resultado);
        }



        [HttpGet("ListServiceCenter")]
        public async Task<IActionResult> ListServiceCenterAsync(string nombre, int idProveedor)
        {
            if(nombre == null)
            {
                nombre = "";
            }
            var resultado = await financingRequestManager.ListServiceCenterAsync(nombre,idProveedor);
            if (resultado == null)
            {
                return Ok(new { valid = false, message = Constants.InvalidListCenter });
            }
            return Ok(resultado);
        }

        [HttpPost("UploadDocument")]
        public async Task<IActionResult> UploadDocument([FromBody] UploadDocumentsDTO uploadDocumentsDto)
        {
            var resultUploadDocumentsDto = await financingRequestManager.UploadDocumentAsync(uploadDocumentsDto);

            if (resultUploadDocumentsDto == false)
            {
                return BadRequest(new { valid = false, message = FinancingRequestConst.InvalidUploadDocuments });
            }

            return Ok(new { valid = true, message = FinancingRequestConst.SuccessUploadDocuments });
        }

        [HttpPost("UploadDocument2")]
        public async Task<IActionResult> UploadDocument2(IFormFile file)
        {
            //var resultUploadDocumentsDto = await financingRequestManager.UploadDocumentAsync(uploadDocumentsDto); 
            //if (resultUploadDocumentsDto == false)
            //{
            //    return BadRequest(new { valid = false, messaje = FinancingRequestConst.InvalidUploadDocuments });
            //}
            //return Ok(new { valid = true, message = FinancingRequestConst.SuccessUploadDocuments });
            var target = Path.Combine(_hostingEnvironment.ContentRootPath, "product");

            Directory.CreateDirectory(target);
            Directory.CreateDirectory("Resources");
            try
            {
                //string uploads = @"D:\Xternal\02. Proyectos\Pierr\GNV\Fuentes\FrontEnd\src\assets\images\home\product";
                if (file.Length > 0)
                {
                    string filePath = Path.Combine(target, file.FileName);
                    //using (Stream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.ReadWrite))
                    //{
                    //    await file.CopyToAsync(fileStream);
                    //}

                    using (var stream = new FileStream(Path.Combine("Resources", file.FileName), FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                        //result.Add(f.FileName);
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }

            return Ok(new { valid = true, message = FinancingRequestConst.SuccessUploadDocuments });
        }


        [HttpGet("List40Preguntas")]
        public async Task<IActionResult> List40Preguntas(int IdtipoDocumento, string NumDocumento,int NumPag, int NumReg)
        {

            var resultado = await financingRequestManager.List40Preguntas(IdtipoDocumento, NumDocumento, NumPag, NumReg);
            if (resultado == null)
            {
                return Ok(new { valid = false, message = Constants.InvalidListEvluationClient });
            }
            return Ok(resultado);
        }

        [HttpGet("LineaTiempoPreevaluacion")]
        public async Task<IActionResult> LineaTiempoPreevaluacion(string Clave, int Id)
        {
            
            var resultado = await financingRequestManager.ListLineaTiempo(Clave, Id);
            if (resultado == null)
            {
                return Ok(new { valid = false, message = Constants.InvalidListLineaTiempo });
            }
            return Ok(resultado);
        }

        [HttpGet("LastRegPreevaluacion")]
        public async Task<IActionResult> LastRegPreevaluacion(int IdUsuario)
        {

            var resultado = await financingRequestManager.ListultimoRegistroPreevalucion(IdUsuario);
            if (resultado == null)
            {
                return Ok(new { valid = false, message = Constants.InvalidListLineaTiempo });
            }
            return Ok(resultado);
        }

        [HttpGet("LastReg40Preguntas")]
        public async Task<IActionResult> LastReg40Preguntas(int IdUsuario)
        {

            var resultado = await financingRequestManager.ListultimoRegistro40Preguntas(IdUsuario);
            if (resultado == null)
            {
                return Ok(new { valid = false, message = Constants.InvalidListLineaTiempo });
            }
            return Ok(resultado);
        }

        [HttpGet("LineaCredito")]
        public async Task<IActionResult> LineaCredito(int NumScore, string ValorCR)
        {

            var resultado = await financingRequestManager.LineaCredito(NumScore, ValorCR);
            if (resultado == null)
            {
                return Ok(new { valid = false, message = Constants.InvalidLineaCredito });
            }
            return Ok(resultado);
        }
    }
}
