using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
namespace BLL
{
    public class Class1
    {
        public string OrderStatus;
        public string OrderNo;

        public int totalProducts;
        public int totalPrice;
        public int totalStack;
        public int flag;

        public int CustomerID;
        public int ProductID;
        public int CatagoryID;
        public int StockType;

        public int InsertData(string txtCatagoryName,string description,string imgUrl,string price,string catagory,int qty)
        {
            DAL.Class1 obj = new DAL.Class1();
            return obj.InsertData(txtCatagoryName, description, imgUrl, price, catagory,qty);
        }

        public int InsertData(string p)
        {
            DAL.Class1 obj = new DAL.Class1();
            return obj.InsertData(p);
        }


        public DataTable SaveOrder(string Name, string phone, string email , string address, string total_dress, string total_price)
        {
            DAL.Class1 obj = new DAL.Class1();
            return obj.SaveOrder(Name,phone,email,address,total_dress,total_price);
        }



        public void saveCustomerOrder()
        {
            DAL.Class1 obj = new DAL.Class1();
           obj.saveCustomerOrder(CustomerID,ProductID,totalProducts);
        }

        public DataTable GetAvailableStock()
        {
            DataTable dt = new DataTable();
            DAL.Class1 obj = new DAL.Class1();
            dt = obj.GetAvailAbleStock(StockType,CatagoryID);
            return dt;
        }

        public DataTable GetIncomeReport()
        {
            DataTable dt = new DataTable();
            DAL.Class1 obj = new DAL.Class1();
            dt = obj.GetIncomeReport(flag);
            return dt;
        }

        public DataTable GetOrdersList()
        {
            DataTable dt = new DataTable();
            DAL.Class1 obj = new DAL.Class1();
            dt = obj.GetOrdersList(flag);
            return dt;
        }

        public object GetTransactionDetails()
        {
            DataTable dt = new DataTable();
            DAL.Class1 obj = new DAL.Class1();
            dt = obj.GetTransactionDetails(flag);
            return dt;
        }

        public DataTable GetSetOrderStatus()
        {
            DataTable dt = new DataTable();
            DAL.Class1 obj = new DAL.Class1();
            dt = obj.GetSetOrderStatus(OrderNo,OrderStatus,flag);
            return dt;
        }
    }
}
