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
                string sql = "EXEC [dbo].[SP_SAB_ObtenerAlertaPorPersonal] @pintIdPersonal";

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

        public async Task<Usuario> GetUsuario(string usuario, string clave)
        {
            Usuario usuario_encontrado = await _context.tblUsuario
                .Where(x => x.Username == usuario && x.Password == clave && x.Activo == true && x.Eliminado == false)
                .FirstOrDefaultAsync();

            return usuario_encontrado;
        }

        public async Task<Personal> GetPersonal(int idPersonal)
        {
            try
            {
                var personal_encontrado = await _context.tblPersonal
                    .Where(x => x.IdPersonal == idPersonal && x.Activo == true && x.Eliminado == false)
                    .FirstOrDefaultAsync();

                return personal_encontrado;
            }
            catch (Exception ex)
            {
                // Handle the exception as needed, e.g., log the error
                return new Personal();
            }
        }

        public async Task<Ciudadano> GetCiudadano(int idCiudadano)
        {
            try
            {
                var ciudadano_encontrado = await _context.tblCiudadano
                    .Where(x => x.IdCiudadano == idCiudadano && x.Activo == true && x.Eliminado == false)
                    .FirstOrDefaultAsync();

                return ciudadano_encontrado;
            }
            catch (Exception ex)
            {
                // Handle the exception as needed, e.g., log the error
                return new Ciudadano();
            }
        }

        public async Task<Rol> GetRol(int idRol)
        {
            Rol rol_encontrado = await _context.tblRol
                .Where(x => x.IdRol == idRol)
                .FirstOrDefaultAsync();

            return rol_encontrado;
        }

        public async Task<SP_SAB_ActualizarAlerta_Result> ActualizarAlerta(SP_SAB_ActualizarAlerta_Parameters parameters)
        {
            SP_SAB_ActualizarAlerta_Result result = new SP_SAB_ActualizarAlerta_Result();
            try
            {
                string sql = "EXEC [dbo].[SP_SAB_ActualizarAlerta] @pintIdGrupoPersonal, @pstrCodAlerta";

                var queryResult = await _context.SP_SAB_ActualizarAlerta
                    .FromSqlRaw(sql, parameters.ToSqlParameters())
                    .ToListAsync();

                result = queryResult.FirstOrDefault() ?? new SP_SAB_ActualizarAlerta_Result();
            }
            catch (Exception ex)
            {
                result.codigo = (int)HttpStatusCode.InternalServerError;
                result.descripcion = ex.Message;
            }
            return result;
        }

        public async Task<SP_SAB_DescartarAlerta_Result> DescartarAlerta(SP_SAB_DescartarAlerta_Parameters parameters)
        {
            SP_SAB_DescartarAlerta_Result result = new SP_SAB_DescartarAlerta_Result();
            try
            {
                string sql = "EXEC [dbo].[SP_SAB_DescartarAlerta] @pstrCodAlerta";

                var queryResult = await _context.SP_SAB_DescartarAlerta
                    .FromSqlRaw(sql, parameters.ToSqlParameters())
                    .ToListAsync();

                result = queryResult.FirstOrDefault() ?? new SP_SAB_DescartarAlerta_Result();
            }
            catch (Exception ex)
            {
                result.codigo = (int)HttpStatusCode.InternalServerError;
                result.descripcion = ex.Message;
            }
            return result;
        }

        public async Task<List<SP_SAB_ObtenerGruposPersonalesActivos_Result>> ObtenerGruposPersonalesActivos()
        {
            List<SP_SAB_ObtenerGruposPersonalesActivos_Result> result = new List<SP_SAB_ObtenerGruposPersonalesActivos_Result>();
            try
            {
                string sql = "EXEC [dbo].[SP_SAB_ObtenerGruposPersonalesActivos]";

                result = await _context.SP_SAB_ObtenerGruposPersonalesActivos
                    .FromSqlRaw(sql)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                result = new List<SP_SAB_ObtenerGruposPersonalesActivos_Result>();
            }
            return result;
        }
    }
}
