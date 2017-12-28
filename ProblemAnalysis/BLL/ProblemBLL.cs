using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL;

namespace BLL
{
    public class ProblemBLL
    {
        ProblemDAL dal = new ProblemDAL();
        public DataSet GetTable(string title,int page) {
            
            return dal.GetTable(title,page);
        }
        public int SumitProblem(int id,string title, string edit1, string edit2)
        {
            int i = dal.SumitProblem(id,title,edit1,edit2);
            return i;
        }
        public DataSet GetLine(int id)
        {
            return dal.GetLine(id);
        }
        public int DeleteLine(int id)
        {
            return dal.DeleteLine(id);
        }
        public int TopLine(int id)
        {
            return dal.TopLine(id);
        }
    }
}
