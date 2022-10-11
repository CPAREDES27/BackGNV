using Application.Dto.EvaluacionCrediticia;
using Application.Manager.Interfaces;
using Application.Services.Interfaces;
using AutoMapper;
using Domain.MainModule.Entities.EvaluacionCrediticia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Manager.Implementation
{
    public class EvaluacionCrediticiaManager : IEvaluacionCrediticiaManager
    {
        private readonly IEvaluacionCrediticiaService evaluationclientService;
        private readonly IMapper mapper;

        public EvaluacionCrediticiaManager(IEvaluacionCrediticiaService evaluacionCrediticiaService, IMapper mapper)
        {
            this.evaluationclientService = evaluacionCrediticiaService;
            this.mapper = mapper;
        }
        public async Task<TotalEvaluacionCrediticialEntity> GetEvaluacionCrediticia(EvaluacionCrediticiaDTO request)
        {
            var  evaluationclient = await evaluationclientService.GetEvaluacionCrediticia(request);          
            return evaluationclient;
        }
        public async Task<DetalleEvaluacionCrediticiaEntity> GetDetalleEvaluacionCrediticia(int idEvalCliente, string tipoDocumento, string documento)
        {
            var responseDetalleEC = await evaluationclientService.GetDetalleEvaluacionCrediticia(idEvalCliente, tipoDocumento, documento);
            return responseDetalleEC;
        }
        public async Task<List<GetDetallesArchivosEntity>> GetDetalleArchivos(int idPreevaluacion) 
        {
            var responseDetalleArchivos = await evaluationclientService.GetDetalleArchivos(idPreevaluacion);
            return responseDetalleArchivos;
        }
        public async Task<TotalEvaluacionCrediticialEntity> ListarEvaluacionCrediticia(ListaEvaluacionCrediticiaDTO request)
        {
            var responseListaEvaluacionCrediticia = await evaluationclientService.ListarEvaluacionCrediticia(request);
            return responseListaEvaluacionCrediticia;
        }
        public async Task<int> RegisterEvaluacionCrediticia(RegisterEvaluacionCrediticiaDTO request)
        {
            var responseRegisterEvaluacionCrediticia = await evaluationclientService.RegisterEvaluacionCrediticia(request);
            return responseRegisterEvaluacionCrediticia;
        }
        public async Task<TotalCargaPostAtencionEntity> ListarPostAtencion(ListaEvaluacionCrediticiaDTO request)
        {
            var responseCargaPostAtencion = await evaluationclientService.ListarPostAtencion(request);
            return responseCargaPostAtencion;
        }
        public async Task<DetallePostAtencionEntity> DetallePostAtencion(int idPostAtencion)
        {
            var responseDetallePostAtencion = await evaluationclientService.DetallePostAtencion(idPostAtencion);
            return responseDetallePostAtencion;
        }
        public async Task<PA_CargaDocumentosEntity> CargaDocumentos_PA(int idPostAtencion, string nombreDocumento)
        {
            var responsePA_CargaDocumentos = await evaluationclientService.CargaDocumentos_PA(idPostAtencion, nombreDocumento);
            return responsePA_CargaDocumentos;
        }
        public async Task<int> UpdatePA_CargaDocumentos(UpdateCargaDocumentosPADTO request)
        {
            var responsePA_CargaDocumentos = await evaluationclientService.UpdatePA_CargaDocumentos(request);
            return responsePA_CargaDocumentos;
        }

        public async Task<int> InsertarIndividual(CargaOnBaseIndividualDTO request)
        {
            int resultado = 0;

            var listaRegistroIndividual = await evaluationclientService.ObtenerCargaOnBaseIndividual(request);

            resultado = await evaluationclientService.InsertarIndividual(listaRegistroIndividual);
            
            return resultado;
        }

        public async Task<int> InsertarMasivo()
        {
            int resultado = 0;

            var listaRegistroMasivo = await evaluationclientService.ObtenerCargaOnBaseMasivo();

            resultado = await evaluationclientService.InsertarMasivo(listaRegistroMasivo);

            return resultado;
        }
        public async Task<ConsultaSolicitudEntity> ConsultaFormatoSolicitud(int idPrevaluacion)
        {
            var resultado= await evaluationclientService.ConsultaFormatoSolicitud(idPrevaluacion);
            return resultado;
        }
        public async Task<int> UpdateEstadoPreevaluacion(int idPreevaluacion, int idEstado)
        {
            var resultado = await evaluationclientService.UpdateEstadoPreevaluacion(idPreevaluacion, idEstado);
            return resultado;
        }
    }
}
