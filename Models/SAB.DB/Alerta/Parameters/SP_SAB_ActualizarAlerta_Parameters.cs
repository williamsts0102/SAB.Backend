using Microsoft.Data.SqlClient;
using System.Data;

namespace SAB.Backend.Models.SAB.DB.Alerta.Parameters
{
    public class SP_SAB_ActualizarAlerta_Parameters
    {
        public int? pintIdGrupoPersonal { get; set; }
        public string? pstrCodAlerta { get; set; }

        public SqlParameter[] ToSqlParameters()
        {
            var sqlParameters = new List<SqlParameter>();

            // Add each parameter to the list
            sqlParameters.Add(new SqlParameter("@pintIdGrupoPersonal", SqlDbType.Int) { Value = (object?)pintIdGrupoPersonal ?? DBNull.Value });
            sqlParameters.Add(new SqlParameter("@pstrCodAlerta", SqlDbType.VarChar) { Value = (object?)pstrCodAlerta ?? DBNull.Value });
            return sqlParameters.ToArray();
        }
    }
}
