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
    }
}
