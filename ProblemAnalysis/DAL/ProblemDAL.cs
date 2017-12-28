using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class ProblemDAL
    {
        public DataSet GetTable(string title,int page) {
            SqlParameter[] sp ={
                                new SqlParameter("@pageindex",page),
                                new SqlParameter("@title",title)
                                };
                return SqlHelper.ExecuteDataset(CONNSTR.CONN,CommandType.StoredProcedure,"GetPage",sp);
            
        }
        public int SumitProblem(int id,string title, string edit1, string edit2)
        {
            if (id==0)
            {
                string sql = " INSERT [dbo].[ProblemCollection] ( [Title], [Problemdescription],[Solution], [Protime] ) VALUES  ( @title,@edit1,@edit2,GETDATE()) ";
                SqlParameter[] sp ={
                             new SqlParameter("@title",title),
                             new SqlParameter("@edit1",edit1),
                             new SqlParameter("@edit2",edit2)
                             };
            return SqlHelper.ExecuteNonQuery(CONNSTR.CONN,CommandType.Text,sql.ToString(),sp);
            }
            else
            {
                string sql = " UPDATE [dbo].[ProblemCollection] SET [Title]=@title,[Problemdescription]=@edit1, [Solution]=@edit2, [Protime]=GETDATE() WHERE [Id]=@id ";
                SqlParameter[] sp ={
                             new SqlParameter("@title",title),
                             new SqlParameter("@edit1",edit1),
                             new SqlParameter("@edit2",edit2),
                             new SqlParameter("@id",id)
                             };
                return SqlHelper.ExecuteNonQuery(CONNSTR.CONN, CommandType.Text, sql.ToString(), sp);
            }
            
        }
        public DataSet GetLine(int id)
        {
            string sql = " SELECT * FROM  [dbo].[ProblemCollection] WHERE [Id]='"+id+"' ";
            return SqlHelper.ExecuteDataset(CONNSTR.CONN,CommandType.Text,sql.ToString());
        }
        public int DeleteLine(int id)
        {
            string sql = "  DELETE [dbo].[ProblemCollection] WHERE [Id]= @id ";
            SqlParameter[] sp = { 
                                new SqlParameter("@id",id)};
            return SqlHelper.ExecuteNonQuery(CONNSTR.CONN, CommandType.Text, sql.ToString(), sp);

        }
        public int TopLine(int id)
        {
            string sql = " UPDATE [dbo].[ProblemCollection] SET [Sort]=1,[Protime]=GETDATE() WHERE [Id]= @id ";
            SqlParameter[] sp = { 
                                new SqlParameter("@id",id)};
            return SqlHelper.ExecuteNonQuery(CONNSTR.CONN, CommandType.Text, sql.ToString(), sp);

        }
    }
}
