using SAB.Backend.DataAccess;

namespace SAB.Backend.Business
{
    public class SABBO  : ISABBO
    {
        private readonly ISABDO _sabDO;

        public SABBO(ISABDO sabDO)
        {
            _sabDO = sabDO;
        }

    }
}
