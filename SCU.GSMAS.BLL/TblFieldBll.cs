using SCU.GSMAS.DAL;
using SCU.GSMAS.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCU.GSMAS.BLL
{
    public class TblFieldBll
    {
        private TblFieldDal dal = new TblFieldDal();

        public List<TblField> GetList()
        {
            return dal.GetList();
        }

        public DataTable GetDataTable()
        {
            return dal.GetDataTable();
        }


    }
}
