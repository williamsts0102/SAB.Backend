using Microsoft.Data.SqlClient;
using System.Data;

namespace SAB.Backend.Models.SAB.DB.Alerta.Parameters
{
    public class SP_SAB_DTS_RegistrarAlerta_Parameters
    {
        public string? pstrDepartamento { get; set; }
        public string? pstrProvincia { get; set; }
        public string? pstrDistrito { get; set; }
        public string? pstrDireccion { get; set; }
        public string? pstrLatitud { get; set; }
        public string? pstrLongitud { get; set; }
        public string? pstrDescripcion { get; set; }
        public bool? pbitEstado { get; set; }
        public int? pintIdUsuarioRegistro { get; set; }

        public SqlParameter[] ToSqlParameters()
        {
            var sqlParameters = new List<SqlParameter>();

            // Add each parameter to the list
            sqlParameters.Add(new SqlParameter("@pstrDepartamento", SqlDbType.VarChar) { Value = (object?)pstrDepartamento ?? DBNull.Value });
            sqlParameters.Add(new SqlParameter("@pstrProvincia", SqlDbType.VarChar) { Value = (object?)pstrProvincia ?? DBNull.Value });
            sqlParameters.Add(new SqlParameter("@pstrDistrito", SqlDbType.VarChar) { Value = (object?)pstrDistrito ?? DBNull.Value });
            sqlParameters.Add(new SqlParameter("@pstrDireccion", SqlDbType.VarChar) { Value = (object?)pstrDireccion ?? DBNull.Value });
            sqlParameters.Add(new SqlParameter("@pstrLatitud", SqlDbType.VarChar) { Value = (object?)pstrLatitud ?? DBNull.Value });
            sqlParameters.Add(new SqlParameter("@pstrLongitud", SqlDbType.VarChar) { Value = (object?)pstrLongitud ?? DBNull.Value });
            sqlParameters.Add(new SqlParameter("@pstrDescripcion", SqlDbType.VarChar) { Value = (object?)pstrDescripcion ?? DBNull.Value });
            sqlParameters.Add(new SqlParameter("@pbitEstado", SqlDbType.Bit) { Value = (object?)pbitEstado ?? DBNull.Value });
            sqlParameters.Add(new SqlParameter("@pintIdUsuarioRegistro", SqlDbType.Int) { Value = (object?)pintIdUsuarioRegistro ?? DBNull.Value });

            return sqlParameters.ToArray();
        }
    }
}
