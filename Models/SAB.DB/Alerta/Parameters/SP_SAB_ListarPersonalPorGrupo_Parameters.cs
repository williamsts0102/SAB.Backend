using Microsoft.Data.SqlClient;
using System.Data;

namespace SAB.Backend.Models.SAB.DB.Alerta.Parameters
{
    public class SP_SAB_ListarPersonalPorGrupo_Parameters
    {
        public string? pstrCodGrupoPersonal { get; set; }

        public SqlParameter[] ToSqlParameters()
        {
            var sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(new SqlParameter("@pstrCodGrupoPersonal", SqlDbType.VarChar) { Value = (object?)pstrCodGrupoPersonal ?? DBNull.Value });

            return sqlParameters.ToArray();
        }
    }
}
