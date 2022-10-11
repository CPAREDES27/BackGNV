using System.Collections.Generic;

namespace Application.Services.Util
{
    public static class Constants
    { 
        public static string ValueNull = null;

        public const string InvalidUser = "Usuario / clave no válidos";

        public const string ResponseCustomerRegister = "Hubo un error al registrar el usuario, intente nuevamente.";

        public const string ReponseInvalidPrevaluationRegister = "Se generó un error al registrar la prevaluación.";

        public const string ReponseUsuarioRegistradoEnBD = "Usuario ya se encuentra registrado";

        public const string ReponsePreevaluacionRegistro = "La preevaluación fue registrada correctamente.";

        public const string ReponseInvalidPreevaluacionAsesorUpdate = "Hubo un error al asignar el asesor, intente nuevamente.";

        public const string ReponsePreevaluacionAsesorUpdate = "Se asigno el asesor correctamente.";

        public const string ResponseInvalidCodPrevaluation = "El código de la preevaluación no existe.";

        public const string ResponseRegisterKnockoutRules = "Se generó un error al registrar las reglas de Knockout, intentalo nuevamente.";
       
        public const string ResponseRegisterKnockoutRulesTrue = "Las reglas de Knockout fueron registradas correctamente.";

        public const string ReponseRegisterFinancingRequest = "La solicitud de financiamiento fue registrado correctamente.";

        public const string ReponseInvalidRegisterFinancingRequest = "Hubo un error al registrar la solicitud de financiamiento.";

        public const string InvalidListRandomQuestions = "Hubo un error al listar las preguntas aleatorias.";

        public const string ResponseRegisterRandomQuestions = "Las preguntas aleatorias fueron registradas correctamente.";

        public const int AsesorVentas = 2;

        public const string InvalidListBusinessAdvisors = "Hubo un error al listar los asesores comerciales.";

        public const string InvalidListMaintenanceControl = "Hubo un error al listar las opciones del proceso.";

        public const string InvalidRootPath = "No se encontró la ruta del archivo";

        public const string InvalidListDepartment = "Hubo un error al listar los departamentos.";

        public const string InvalidResponseAddAsync = "Hubo un error al registrar al usuario.";

        public const string ReponseAddAsync = "El usuario ha sido registrado correctamente.";

        public const string ReponseInvalidUpdateUser = "Hubo un error al actualizar el usuario.";

        public const string ReponseUpdateUser = "Se ha actualizado el usuario de forma correcta.";

        public const string ReponseInvalidDeleteUser = "Hubo un error al eliminar el usuario.";

        public const string ReponseDeleteUser = "Se ha dado de baja al usuario satisfactoriamente.";

        public const string ReponseInvalidIdUser = "Hubo un error al listar los datos del usuario.";
        public const string InvalidEmailUsuario = "Ya existe un Usuario con el mismo Email.";

        public const string ReponseDatosAdicionalesUser = "Se ha registrado los datos satisfactoriamente.";
        public const string ReponseInvalidDatosAdicionalesUser = "Hubo un error al registrar los datos, intente nuevamente.";

        //Productos
        public const string InvalidListProduct = "Hubo un error al listar los productos.";

        public const string ResponseRegisterProduct = "Hubo un error al registrar el producto, intente nuevamente.";
        public const string ReponseAddProduct = "El producto ha sido registrado correctamente.";
        public const string ResponseUpdateProductError = "Hubo un error al actualizar el producto, intente nuevamente.";
        public const string ResponseUpdateProduct = "El producto ha sido actualizado correctamente.";
        public const string ResponseUpdateStatusProduct = "El producto se dio de baja correctamente.";
        public const string ResponseUpdateStatusProductError = "Hubo un error al dar de baja al producto.";

        //Financing
        public const string InvalidListEstadoNivelEstudiosCliente = "Hubo un error al listar.";
        public const string InvalidListEstadoCivilCliente = "Hubo un error al listar.";

        public const string InvalidListEstadoVehicular = "Hubo un error al listar.";
        public const string InvalidListEstadoTipoFinanciamiento = "Hubo un error al listar.";
        public const string InvalidListTipoCalle = "Hubo un error al listar.";
        public const string InvalidListTipoCreditoFinanciamiento = "Hubo un error al listar.";
        public const string InvalidGetDownload = "No existen documentos.";
        public const string InvalidUpdateReglasNockout = "Hubo un error al actualizar la información.";
        public const string ResponseUpdateReglasNockout = "Se actualizo correctamente la información";
        public const string InvalidListCenter = "Hubo un error al listar.";
        public const string InvalidListLineaTiempo = "No existen registros.";
        public const string InvalidLineaCredito = "No existen registros.";

        //User
        public const string InvalidValidarEstadoUsuario = "Hubo un error al validar al Usuario.";
        public const string InvalidConsultaDatosUsuario = "Hubo un error al consultar Datos del Usuario.";
        public const string InvalidConsultaDatosAdicionalesUsuario = "No existe Datos adicionales del Usuario.";
        public const string validConsultaDatosAdicionalesUsuario = "Resultado Datos adicionales";

        //Evaluation Client
        public const string InvalidIdEvluationClient = "No existe información del ID enviado, verificar.";
        public const string InvalidListEvluationClient = "No existe información a mostrar, verificar.";
        public const string InvalidListFileEvluationClient = "No existe información de archivos a mostrar, verificar.";
        public const string InvalidFileEvluationClient = "El estado ha sido actualizado correctamente.";
        public const string ResponseUpdateFileEvluationClientError = "Hubo un error al cambiar el estado.";
        public const string InvalidRegisterEvaluacionCliente = "No se pudo registrar la evaluacion al cliente.";
        public const string ResponseRegisterEvaluacionCliente = "Se registro la evaluacion del cliente satisfactoriamente.";
        //
        public const string InvalidListStateMaintenanceControl = "No existe información a mostrar, verificar.";
        //EvaluacionFinanciamiento
        public const string InvalidGetEvaluacionCrediticia= "No se pudo listar la informacion.";
        public const string InvalidGetDetalleArchivos = "No se encontro informacion.";
        public const string ReponseExitPrevaluation = "Id Preevaluación existe.";
        public const string ReponseNoExitPrevaluation = "Id Preevaluación no existe.";
        //
        public const string ReponseNoExitPrevaluation40 = "El cliente aún no ha completado las Preguntas para la Evaluación Crediticia.";
        public const string InvalidRegisterEvaluacionCrediticia = "No se pudo registrar la Evaluacion Crediticia.";
        public const string InvalidCargaPostAtencion = "No se pudo listar la Carga Post Atencion";
        public const string ReponseRegisterEvaluacionCrediticia = "Se inserto correctamente la Evaluacion Crediticia.";
        public const string InvalidDetallePostAtencion = "No se pudo listar la el Detalle de PostAtencion";
        public const string InvalidPA_CargaDocumentos= "No se pudo listar la carga de documentos PA.";
        public const string InvalidUpdateCargaDocumentosPA = "No se pudo actualizar la Carga Documentos PA.";
        public const string ReponseUpdateCargaDocumentosPA = "Se Actualizo correctamente la CargaDocumentos PA.";
        public const string InvalidIdPostAttention = "No se puedo listar la Post Atencion.";
        public const string ReponseNoExistpostAttention = "No se puedo listar la Post Atencion.";

        public const string InvalidRegisterCargaOnBase = "No se pudo registrar la Carga On Base.";
        public const string InvalidPathCargaOnBase = "No existe el directorio para crear los expedientes, por favor regístrelo.";
        public const string ReponseRegisterCargaOnBase = "Se insertó correctamente la Carga On Base.";


        public const string InvalidConsultaFormatoConformidad = "Falta Adjuntar el Formato de Conformidad.";
        public const string ReponseConsultaFormatoConformidad = "Ya tiene el formato de Conformidad Adjuntado.";

        public const string InvalidUpdateEstadoPreevaluacion = "Ocurrio un error, vuelva a intentarlo.";
        public const string ReponseUpdateEstadoPreevaluacion = "Se actualizo la preevaluacion correctamente.";


        //Homologacion
        public const string InvalidDeleteRandonQuestions = "No se pudo dar de baja la pregunta .";
        public const string ReponseDeleteRandonQuestions = "La pregunta ha sido dado de baja correctamente.";
        public const string InvalidGetPreevaluacionTipDoc = "No se pudo obtener la Preevaluacion.";
        public const string InvalidGetListProduct = "No se pudo listar los Productos.";
        public const string InvalidRolMenuPadre_Hijo = "No se pudo listar los Roles.";
        public const string InvalidListUserMaintence = "Hubo un error al listar.";
        public const string InvalidListGetPreevaluacion = "No se pudo listar la Preevaluacion.";


        //Report Dashboard
        public const string InvalidReportDashBoard = "No existe información a mostrar";
        public const string ResponseReportDashBoard = "Resultados Reporte Dashboard";



    }
}
