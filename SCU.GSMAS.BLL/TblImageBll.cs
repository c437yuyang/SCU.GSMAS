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
    public class TblImageBll
    {
        private TblImageDal dal = new TblImageDal();
        private TblSpecimenDal spDal = new TblSpecimenDal();

        public List<TblImage> GetList()
        {
            return dal.GetList();
        }

        public List<TblImage> GetListBySpId(int sid)
        {
            return dal.GetListBySpId(sid);
        }

        public List<TblImage> GetListByFieldId(int fid)
        {
            List<TblImage> list = new List<TblImage>();
            //1.先根据指定fid查找有哪些specimen
            List<TblSpecimen> sps = spDal.GetListByFieldId(fid);
            //2.加载对应sp的image
            foreach(TblSpecimen item in sps)
            {
                list.AddRange(dal.GetListBySpId(item.sp_id));
            }
            return list;
        }


        public DataTable GetDataTable()
        {
            return dal.GetDataTable();
        }


        public DataTable GetDataTableBySpId(int sid)
        {
            return dal.GetDataTableBySpId(sid);
        }

        public DataTable GetDataTableByFieldId(int fid)
        {
            DataTable dt = new DataTable();
            //1.先根据指定fid查找有哪些specimen
            List<TblSpecimen> sps = spDal.GetListByFieldId(fid);
            foreach (TblSpecimen item in sps)
            {
                dt.Merge(dal.GetDataTableBySpId(item.sp_id));
            }
            return dt;
        }

    }
}
