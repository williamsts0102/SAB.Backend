using SAB.Backend.Models.SAB.DB.Alerta.Parameters;
using SAB.Backend.Models.SAB.DB.Alerta.Result;

namespace SAB.Backend.DataAccess
{
    public interface ISABDO
    {
        Task<SP_SAB_DTS_RegistrarAlerta_Result> RegistrarAlerta(SP_SAB_DTS_RegistrarAlerta_Parameters parameters);
        Task<List<SP_SAB_ListarAlerta_Result>> ListarAlerta();
        Task<SP_SAB_DetalleAlerta_Result> DetalleAlerta(SP_SAB_DetalleAlerta_Parameters parameters);
        Task<SP_SAB_ObtenerAlertaPorPersonal_Result> ObtenerAlertaPorPersonal(SP_SAB_ObtenerAlertaPorPersonal_Parameters parameters);
    }
}
