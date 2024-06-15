using SAB.Backend.Models.SAB.DB;

namespace SAB.Backend.DataAccess
{
    public class SABDO  : ISABDO
    {
        private readonly SABContext _context;

        public SABDO(SABContext context)
        {
            _context = context;
        }
    }
}
