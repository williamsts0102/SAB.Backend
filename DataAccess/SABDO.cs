using Microsoft.EntityFrameworkCore;
using SAB.Backend.Models.SAB.DB;
using SAB.Backend.Models.SAB.DB.Alerta.Parameters;
using SAB.Backend.Models.SAB.DB.Alerta.Result;
using System.Net;

namespace SAB.Backend.DataAccess
{
    public class SABDO  : ISABDO
    {
        private readonly SABContext _context;

        public SABDO(SABContext context)
        {
            _context = context;
        }

        public async Task<SP_SAB_DTS_RegistrarAlerta_Result> RegistrarAlerta(SP_SAB_DTS_RegistrarAlerta_Parameters parameters)
        {
            SP_SAB_DTS_RegistrarAlerta_Result result = new SP_SAB_DTS_RegistrarAlerta_Result();
            try
            {
                string sql = "EXEC [dbo].[SP_SAB_DTS_RegistrarAlerta] @pstrDepartamento, @pstrProvincia, @pstrDistrito, @pstrDireccion, @pstrLatitud, @pstrLongitud, @pstrDescripcion, @pbitEstado, @pintIdUsuarioRegistro";

                var queryResult = await _context.SP_SAB_DTS_RegistrarAlerta
                    .FromSqlRaw(sql, parameters.ToSqlParameters())
                    .ToListAsync();

                result = queryResult.FirstOrDefault() ?? new SP_SAB_DTS_RegistrarAlerta_Result();
            }
            catch (Exception ex)
            {
                result.codigo = (int)HttpStatusCode.InternalServerError;
                result.descripcion = ex.Message;
            }
            return result;
        }

        public async Task<List<SP_SAB_ListarAlerta_Result>> ListarAlerta()
        {
            List<SP_SAB_ListarAlerta_Result> result = new List<SP_SAB_ListarAlerta_Result>();
            try
            {
                string sql = "EXEC [dbo].[SP_SAB_ListarAlerta]";

                result = await _context.SP_SAB_ListarAlerta
                    .FromSqlRaw(sql)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                result = new List<SP_SAB_ListarAlerta_Result>();
            }
            return result;
        }

        public async Task<SP_SAB_DetalleAlerta_Result> DetalleAlerta(SP_SAB_DetalleAlerta_Parameters parameters)
        {
            SP_SAB_DetalleAlerta_Result result = new SP_SAB_DetalleAlerta_Result();
            try
            {
                string sql = "EXEC [dbo].[SP_SAB_DetalleAlerta] @pstrCodAlerta";

                var queryResult = await _context.SP_SAB_DetalleAlerta
                    .FromSqlRaw(sql, parameters.ToSqlParameters())
                    .ToListAsync();

                result = queryResult.FirstOrDefault() ?? new SP_SAB_DetalleAlerta_Result();
            }
            catch (Exception ex)
            {
                result = new SP_SAB_DetalleAlerta_Result();
            }
            return result;
        }

        public async Task<SP_SAB_ObtenerAlertaPorPersonal_Result> ObtenerAlertaPorPersonal(SP_SAB_ObtenerAlertaPorPersonal_Parameters parameters)
        { 
            SP_SAB_ObtenerAlertaPorPersonal_Result result = new SP_SAB_ObtenerAlertaPorPersonal_Result();
            try
            {
                string sql = "EXEC [dbo].[SP_SAB_ObtenerAlertaPorPersonal] @pintIdUsuario";

                var queryResult = await _context.SP_SAB_ObtenerAlertaPorPersonal
                    .FromSqlRaw(sql, parameters.ToSqlParameters())
                    .ToListAsync();

                result = queryResult.FirstOrDefault() ?? new SP_SAB_ObtenerAlertaPorPersonal_Result();
            }
            catch (Exception ex)
            {
                result = new SP_SAB_ObtenerAlertaPorPersonal_Result();
            }
            return result;
        }
    }
}
