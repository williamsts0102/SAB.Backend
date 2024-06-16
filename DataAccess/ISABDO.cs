using SAB.Backend.Models.SAB.DB.Alerta.Parameters;
using SAB.Backend.Models.SAB.DB.Alerta.Result;

namespace SAB.Backend.DataAccess
{
    public interface ISABDO
    {
        Task<SP_SAB_DTS_RegistrarAlerta_Result> RegistrarAlerta(SP_SAB_DTS_RegistrarAlerta_Parameters parameters);
    }
}
