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
    public class TblSpecimenBll
    {
        private TblSpecimenDal dal = new TblSpecimenDal();
        public List<TblSpecimen> GetList()
        {
            return dal.GetList();
        }

        public List<TblSpecimen> GetListByFieldId(int fid)
        {
            if (fid > 0)
                return dal.GetListByFieldId(fid);
            else return new List<TblSpecimen>();
        }
        public DataTable GetDataTable()
        {
            return dal.GetDataTable();
        }

        public DataTable GetDataTableByFieldId(int fid)
        {
            if (fid > 0)
                return dal.GetDataTableByFieldId(fid);
            else return new DataTable();
        }

    }
}
