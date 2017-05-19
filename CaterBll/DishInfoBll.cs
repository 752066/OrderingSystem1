using CaterDal;
using CaterModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaterBll
{
    public partial class DishInfoBll
    {
        private DishInfoDal did = new DishInfoDal();
        public List<DishInfo> GetList(Dictionary<string,string> dict)
        {
            return did.GetList(dict);
        }
    }
}
