using BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
namespace DataAccessLayerLibrary
{
    public class DeptDAL
    {
        public bool UpdateDept(DeptBAL deptdata)
        {
            bool status = false;
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["HRConString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("sp_Updatedept", cn);
            try
            {
                cmd.Parameters.AddWithValue("@p_deptno", deptdata.DeptNo);
                cmd.Parameters.AddWithValue("@p_dname", deptdata.Deptname);
                cmd.Parameters.AddWithValue("@p_loc", deptdata.Location);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i >= 1)
                {
                    status = true;
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            finally
            {
                cn.Close();
            }
            
            return status;

        }

        public bool deletedept(int deptno)
        {
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["HRConString"].ConnectionString);
            string str = "Delete from dept where deptno=@deptno";
            SqlCommand cmd = new SqlCommand(str, cn);
            cmd.Parameters.AddWithValue("@deptno", deptno);
            cn.Open();
            int i = cmd.ExecuteNonQuery();
            bool status = false;
            if(i>=1)
            {
                status = true;
            }
            cn.Close();
            return status;
        }

        public bool InsertDeptRecord(DeptBAL deptdata)
        {
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["HRConString"].ConnectionString);
            string str = "Insert into dept values(@deptno,@dname,@loc)";
            SqlCommand cmd = new SqlCommand(str,cn);
            cmd.Parameters.AddWithValue("@deptno", deptdata.DeptNo);
            cmd.Parameters.AddWithValue("@dname", deptdata.Deptname);
            cmd.Parameters.AddWithValue("@loc", deptdata.Location);
            cn.Open();
           int i= cmd.ExecuteNonQuery();
            bool status = false;
            if(i>=0)
            {
                status = true;
            }
            cn.Close();
            return status;

        }

        public List<DeptBAL> ShowDeptList()
        {
            List<DeptBAL> deptlist = new List<DeptBAL>();
           
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["HRConString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("select * from dept",cn);
            cn.Open();
           SqlDataReader dr= cmd.ExecuteReader();
            while(dr.Read())
            {
                DeptBAL d = new DeptBAL();
                d.DeptNo = Convert.ToInt32(dr[0]);
                d.Deptname = dr[1].ToString();
                d.Location = dr[2].ToString();
                deptlist.Add(d);

            }
            cn.Close();
            return deptlist;
        }
    }
}
