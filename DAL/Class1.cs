using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class Class1
    {


        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        DataSet ds;
        
        public Class1()
        {
            con = new SqlConnection(@"Data Source=AFIFA\SQLEXPRESS;Initial Catalog=StitchOnDemand;Integrated Security=True");
            cmd = new SqlCommand();
            da = new SqlDataAdapter();
            dt = new DataTable();
             
        }

        public int InsertData(string txtCatagoryName, string description, string imgUrl, string price, string catagory ,int qty)
        {
           int result;
          
           SqlDataAdapter sda = new SqlDataAdapter(@"SELECT CatagoryID FROM Catagory where CatagoryName='" + catagory + "' ", con);
           DataSet ds = new DataSet();
           sda.Fill(ds);

           SqlCommand cmd = con.CreateCommand();
           string val = ds.Tables[0].Rows[0]["CatagoryID"].ToString();

            try
            {

                cmd = new SqlCommand("AddNewProduct", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Catagory",int.Parse( val));
                cmd.Parameters.AddWithValue("@Description", description);
                cmd.Parameters.AddWithValue("@price", price);
                cmd.Parameters.AddWithValue("@name", txtCatagoryName);
                cmd.Parameters.AddWithValue("@Image", imgUrl);
                cmd.Parameters.AddWithValue("@qty", qty);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                result = cmd.ExecuteNonQuery();
                cmd.Dispose();
                if (result > 0)
                {
                    return result;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (con.State != ConnectionState.Closed)
                {
                    con.Close();
                }
            }
        }

        public int InsertData(string p)
        {
            int result;
            try
            {

                cmd = new SqlCommand("AddNewCatagory", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CatagoryName", p);
               
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                result = cmd.ExecuteNonQuery();
                cmd.Dispose();
                if (result > 0)
                {
                    return result;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (con.State != ConnectionState.Closed)
                {
                    con.Close();
                }
            }
        }
        public DataTable GetCatagories()
        {
            DataTable d = new DataTable();
            cmd = new SqlCommand("Catagories", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            da.SelectCommand = cmd;
            da.Fill(d);
            con.Close();
            return d;
            
            
        }
        public DataTable GetAllProducts()
        {
            DataTable d = new DataTable();
            cmd = new SqlCommand("AllProducts", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            da.SelectCommand = cmd;
            da.Fill(d);
            con.Close();
            return d;


        }

        public object GetSelectedProducts(int CatagoryID)
        {
            DataTable d = new DataTable();
            cmd = new SqlCommand("SelectedProducts", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", CatagoryID);
            cmd.Connection = con;
            da.SelectCommand = cmd;
            da.Fill(d);
            con.Close();
            return d;
        }

        public DataTable SaveOrder(string Name, string phone, string email, string address, string total_dress, string total_price)
        {
            con.Open();
            int res;
            int Tdress = int.Parse(total_dress);
            int Tprice = int.Parse(total_price);
            DataTable result =new DataTable();
            try
            {

                cmd = new SqlCommand("CustomerDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Customername", Name);
                cmd.Parameters.AddWithValue("@CustomerEmailID",email);
                cmd.Parameters.AddWithValue("@CustomerPhoneNo",phone);
                cmd.Parameters.AddWithValue("@CustomerAddress",address);
                cmd.Parameters.AddWithValue("@TotalProducts",Tdress);
                cmd.Parameters.AddWithValue("@TotalPrice",Tprice);
                res = cmd.ExecuteNonQuery();
                cmd.Connection = con;
                //da.InsertCommand = cmd;
                da.SelectCommand = cmd;
                da.Fill(result);
                cmd.Dispose();
                return result;
                

                
                
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (con.State != ConnectionState.Closed)
                {
                    con.Close();
                }
            }
        }

        public void saveCustomerOrder(int CustomerID, int ProductID, int totalProducts)
        {
            int result;

            cmd = new SqlCommand("AddCustomerProduct", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@customerID", CustomerID);
            cmd.Parameters.AddWithValue("@ProductID", ProductID);
            cmd.Parameters.AddWithValue("@totalProducts", totalProducts);

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            result = cmd.ExecuteNonQuery();
            cmd.Dispose();
        }

        public DataTable GetOrdersList()
        {
            DataTable d = new DataTable();
            cmd = new SqlCommand("OrderList", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            da.SelectCommand = cmd;
            da.Fill(d);
            con.Close();
            return d;
        }

        public DataTable GetAvailAbleStock(int StockType, int CatagoryID)
        {
            DataTable d = new DataTable();
            cmd = new SqlCommand("AvailableStocks", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@StockType", StockType);
            cmd.Parameters.AddWithValue("@CatagoryID", CatagoryID);
          

            cmd.Connection = con;
            da.SelectCommand = cmd;
            da.Fill(d);
            cmd.Dispose();
            con.Close();
            return d;
        }

        public DataTable GetIncomeReport(int flag)
        {
            DataTable d = new DataTable();
            cmd = new SqlCommand("GetIncomeReport", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ReportType", flag);
           


            cmd.Connection = con;
            da.SelectCommand = cmd;
            da.Fill(d);
            cmd.Dispose();
            con.Close();
            return d;
        }

        public DataTable GetOrdersList(int flag)
        {
            DataTable d = new DataTable();
            cmd = new SqlCommand("GetOrderslist", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", flag);



            cmd.Connection = con;
            da.SelectCommand = cmd;
            da.Fill(d);
            cmd.Dispose();
            con.Close();
            return d;
        }

        public DataTable GetTransactionDetails(int flag)
        {
            DataTable d = new DataTable();
            cmd = new SqlCommand("GetTransactionDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TransactionNo", flag);



            cmd.Connection = con;
            da.SelectCommand = cmd;
            da.Fill(d);
            cmd.Dispose();
            con.Close();
            return d;
        }

        public DataTable GetSetOrderStatus(string OrderNo, string OrderStatus, int flag)
        {
            DataTable d = new DataTable();
            cmd = new SqlCommand("OrdersStatus", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TransactionNo", OrderNo);
            cmd.Parameters.AddWithValue("@OrderStatus", OrderStatus);
            cmd.Parameters.AddWithValue("@flag", flag);



            cmd.Connection = con;
            da.SelectCommand = cmd;
            da.Fill(d);
            cmd.Dispose();
            con.Close();
            return d;
        }
    }
}
