using Microsoft.Data.SqlClient;
using System.Data;

namespace SAB.Backend.Models.SAB.DB.Alerta.Parameters
{
    public class SP_SAB_ObtenerAlertaPorPersonal_Parameters
    {
        public int? pintIdPersonal { get; set; }

        public SqlParameter[] ToSqlParameters()
        {
            var sqlParameters = new List<SqlParameter>();

            // Add each parameter to the list
            sqlParameters.Add(new SqlParameter("@pintIdPersonal", SqlDbType.Int) { Value = (object?)pintIdPersonal ?? DBNull.Value });

            return sqlParameters.ToArray();
        }
    }
}
