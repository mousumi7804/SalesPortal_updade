using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
//using System.ServiceModel;
//using System.ServiceModel.Web;
using System.Text;
using System.Data.SqlClient;
using System.Data; 
using System.Configuration;


    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.
    public class Service : IService
    {
        public DataSet GetData(string sql)
        {
            string cn = ConfigurationManager.ConnectionStrings["ConnectionString_master"].ToString();

            SqlConnection con = new SqlConnection(cn);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = sql;
            cmd.CommandType = CommandType.Text;//.StoredProcedure;
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            con.Close();
            return ds;
            //return string.Format("You entered: {0}", value);

        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }


        public string GetInsertUpdateData(string storedprocedure, DataIUD[] IUD)
        {
            int result;
            DataIUD emp = new DataIUD();
            //string con = ConfigurationManager.ConnectionStrings["empConnectionString"].ToString();

            string cn = ConfigurationManager.ConnectionStrings["ConnectionString_master"].ToString();
            using (SqlConnection sqlCon = new SqlConnection(cn))//"Data Source=.;Initial Catalog=Employee;User ID=sa;Password=admin123"))
            {
                SqlCommand cmd = new SqlCommand();
                sqlCon.Open();
                cmd.Connection = sqlCon;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = storedprocedure;
                //cmd.Parameters.Add("@empno", SqlDbType.Int).Value =4;
                //cmd.Parameters.Add("@empname", SqlDbType.VarChar,200 ).Value = "bb";
                //cmd.Parameters.Add("@age", SqlDbType.Int).Value = 24;


                //using (SqlCommand sqlCom = new SqlCommand(storedprocedure, sqlCon))
                //{
                //    sqlCon.Open();
                for (int i = 0; i < IUD.Length; i++)
                {
                    cmd.Parameters.Add(IUD[i].Paraname, IUD[i].Paratype);
                    cmd.Parameters[i].Value = IUD[i].Paravalue;

                }
                result = cmd.ExecuteNonQuery();
                sqlCon.Close();
                //    sqlCom.ExecuteNonQuery();

                //}
            }
            //return IUD[0].Paraname;
            return result.ToString();
        }


        public DataSet GetSelectData(string storedprocedure, DataIUD[] IUD)
        {
            DataSet dt = new DataSet();
            DataIUD emp = new DataIUD();
            //string con = ConfigurationManager.ConnectionStrings["empConnectionString"].ToString();

            string cn = ConfigurationManager.ConnectionStrings["esspconnection"].ToString();
            using (SqlConnection sqlCon = new SqlConnection(cn))//"Data Source=.;Initial Catalog=Employee;User ID=sa;Password=admin123"))
            {
                SqlCommand cmd = new SqlCommand();
                sqlCon.Open();
                cmd.Connection = sqlCon;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = storedprocedure;
                //cmd.Parameters.Add("@empno", SqlDbType.Int).Value =4;
                //cmd.Parameters.Add("@empname", SqlDbType.VarChar,200 ).Value = "bb";
                //cmd.Parameters.Add("@age", SqlDbType.Int).Value = 24;


                //using (SqlCommand sqlCom = new SqlCommand(storedprocedure, sqlCon))
                //{
                //    sqlCon.Open();
                for (int i = 0; i < IUD.Length; i++)
                {
                    cmd.Parameters.Add(IUD[i].Paraname, IUD[i].Paratype);
                    cmd.Parameters[i].Value = IUD[i].Paravalue;

                }



                SqlDataAdapter sda = new SqlDataAdapter();


                sda.SelectCommand = cmd;

                sda.Fill(dt);




                //    sqlCom.ExecuteNonQuery();

                //}
            }
            //return IUD[0].Paraname;
            //return result.ToString();
            return dt;
        }

        public DataSet GetParameterlessSelectData(string storedprocedure)
        {
            DataSet dt = new DataSet();
            //DataIUD emp = new DataIUD();
            //string con = ConfigurationManager.ConnectionStrings["empConnectionString"].ToString();

            string cn = ConfigurationManager.ConnectionStrings["ConnectionString_master"].ToString();
            using (SqlConnection sqlCon = new SqlConnection(cn))//"Data Source=.;Initial Catalog=Employee;User ID=sa;Password=admin123"))
            {
                SqlCommand cmd = new SqlCommand();
                sqlCon.Open();
                cmd.Connection = sqlCon;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = storedprocedure;


                SqlDataAdapter sda = new SqlDataAdapter();


                sda.SelectCommand = cmd;

                sda.Fill(dt);
                sqlCon.Close();




            }

            return dt;
        }

    }
