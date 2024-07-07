using SAB.Backend.Models.SAB.DB;
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
        Task<Usuario> GetUsuario(string usuario, string clave);
        Task<Personal> GetPersonal(int idPersonal);
        Task<Ciudadano> GetCiudadano(int idCiudadano);
        Task<Rol> GetRol(int idRol);
        Task<SP_SAB_ActualizarAlerta_Result> ActualizarAlerta(SP_SAB_ActualizarAlerta_Parameters parameters);
        Task<SP_SAB_DescartarAlerta_Result> DescartarAlerta(SP_SAB_DescartarAlerta_Parameters parameters);
        Task<List<SP_SAB_ObtenerGruposPersonalesActivos_Result>> ObtenerGruposPersonalesActivos();
        Task<List<SP_SAB_ListarAlertasFull_Result>> ListarAlertasFull();
        Task<List<SP_SAB_ListarGruposPersonales_Response>> ListarGruposPersonales();
        Task<List<SP_SAB_ListarPersonalPorGrupo_Result>> ListarPersonalPorGrupo(SP_SAB_ListarPersonalPorGrupo_Parameters parameters);

    }
}
