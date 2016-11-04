using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Configuration;
using System.IO;
namespace WebApplication3.Customer
{
    public partial class Designs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt=new DataTable();
         
            
            pnlMyCart.Visible = false;
            pnlProducts.Visible = true;
           
            

            lblCatagoryName.Text = "Popular Designs At Shop";
            if (!IsPostBack)
            {
               
                GetProducts(0);
            }
        }
       
        public void GetProducts(int CatagoryID=0)
        {
            
            DAL.Class1 k = new DAL.Class1();

            
           
            
            dlProducts.DataSource = null;
            if (CatagoryID == 0)
            {
                DataTable dt = new DataTable();
                dt = k.GetAllProducts();
                dlProducts.DataSource = dt;
              
            }
           
            dlProducts.DataBind();


        } 


        protected void dlCartProducts_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnAddToCart_Click(object sender, EventArgs e)
        {
            
            string ProductID = Convert.ToInt16((((Button)sender).CommandArgument)).ToString();
            string productQuantity = "1";
            DataListItem currentItem = (sender as Button).NamingContainer as DataListItem;
            Label lblAvailStock = currentItem.FindControl("lblAvailableStock") as Label;

            if (Session["MyCart"] != null)
            {
                DataTable dt = (DataTable)Session["MyCart"];
                var checkProduct = dt.AsEnumerable().Where(r =>r.Field<string>("ProductID") == ProductID);
                if (checkProduct.Count() == 0)
                {

                    string query = "select * from Products where ProductID= " + ProductID + "";
                    DataTable dtProducts = GetData(query);
                    DataRow dr = dt.NewRow();
                    dr["ProductID"] = dt.NewRow();
                    dr["ProductID"] = ProductID;
                    dr["Name"] = Convert.ToString(dtProducts.Rows[0]["Name"]);
                    dr["Description"] = Convert.ToString(dtProducts.Rows[0]["Description"]);
                    dr["Price"] = Convert.ToString(dtProducts.Rows[0]["Price"]);
                    dr["ImageUrl"] = Convert.ToString(dtProducts.Rows[0]["ImageUrl"]);
                    dr["Quantity"] = productQuantity;
                   dr["AvailableStock"] = lblAvailableStockProducts.Text;
                    dt.Rows.Add(dr);




                    Session["MyCart"] = dt;
                    btnShopingHeart.Text = dt.Rows.Count.ToString();

                }

            }
            else
            {
                string query = "select * from Products where ProductID= " + ProductID + "";
                DataTable dtProducts = GetData(query);

                DataTable dt = new DataTable();
                dt.Columns.Add("ProductID",typeof(string));
                dt.Columns.Add("Name", typeof(string));
                dt.Columns.Add("Description", typeof(string));
                dt.Columns.Add("Price", typeof(string));
                dt.Columns.Add("ImageUrl", typeof(string));
                dt.Columns.Add("Quantity", typeof(string)); 
               dt.Columns.Add("AvailableStock", typeof(string));

                DataRow dr = dt.NewRow();

               
                dr["ProductID"] = dt.NewRow();
                dr["ProductID"] = ProductID;
                dr["Name"] = Convert.ToString(dtProducts.Rows[0]["Name"]);
                dr["Description"] = Convert.ToString(dtProducts.Rows[0]["Description"]);
                dr["Price"] = Convert.ToString(dtProducts.Rows[0]["Price"]);
                dr["ImageUrl"] = Convert.ToString(dtProducts.Rows[0]["ImageUrl"]);
                dr["Quantity"] = productQuantity;
                dr["AvailableStock"] = lblAvailableStockProducts.Text;
                dt.Rows.Add(dr);
                Session["MyCart"] = dt;
                btnShopingHeart.Text = dt.Rows.Count.ToString();
            }
            HighLightCartProducts();
        }
        private void HighLightCartProducts()
        {
            if (Session["MyCart"] != null)
            {
                DataTable dtProductsAddToCart = (DataTable)Session["MyCart"];
                if(dtProductsAddToCart.Rows.Count>0)
                {
                    foreach (DataListItem item in dlProducts.Items)
                    {
                        HiddenField hfProductID = item.FindControl("hfProductID") as HiddenField;
                        if(dtProductsAddToCart.AsEnumerable().Any( row => hfProductID.Value == row.Field<String>("ProductID")))
                        {
                            //item.BackColor = System.Drawing.Color.Red;

                            Button btnAddToCart = item.FindControl("btnAddToCart") as Button;
                            btnAddToCart.BackColor = System.Drawing.Color.Green;
                            btnAddToCart.Text = "AddedToCart";
                            Image imgGreenStar = item.FindControl("ImageStar") as Image;
                            imgGreenStar.Visible = true;
                        }
                    }
                }
            }
        }


        
        protected void lbtnCatagory_Click(object sender, EventArgs e)
        {
           pnlMyCart.Visible = false;
           pnlProducts.Visible = true;
           int CatagoryID = Convert.ToInt16((((LinkButton)sender).CommandArgument));
          

           GetProducts(CatagoryID);
           HighLightCartProducts();
        }
       
        private void GetMyCart()
        {
            
            DataTable dtProducts;
           
            if(Session["MyCart"]!=null)
            {

                
             dtProducts = (DataTable)Session["MyCart"];
           
            }
            else
            {
                dtProducts =new DataTable();
              
            }

            if (dtProducts.Rows.Count > 0)
            {
                
                btnShopingHeart.Text = dtProducts.Rows.Count.ToString();
                delCartProducts.DataSource = dtProducts;
                delCartProducts.DataBind();
                UpdateTotalBill();
                delCartProducts.Visible = true;
                pnlMyCart.Visible = true;
                
                pnlEmptyCart.Visible = false;
                
                pnlProducts.Visible = false;
                pnlOrderPlacedSuccessfully.Visible = false;
            }
            else
            {
                pnlEmptyCart.Visible = true;
                pnlMyCart.Visible = false;
               
                pnlOrderPlacedSuccessfully.Visible = false;
                pnlProducts.Visible = false;
                delCartProducts.DataSource = null;
                delCartProducts.DataBind();
               
                btnShopingHeart.Text = "0";
            }

           
               
             
             
        }
        public DataTable GetData(string query)
        {
            DataTable dt = new DataTable();
            
            SqlConnection con = new SqlConnection(@"Data Source=AFIFA\SQLEXPRESS;Initial Catalog=StitchOnDemand;Integrated Security=True");
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(query,con);
            da.Fill(dt);
            con.Close();
            

            return dt;
        }

        protected void btnRemoveFromCart_Click(object sender, EventArgs e)
        {
            string ProductID = Convert.ToInt16((((Button)sender).CommandArgument)).ToString();
            if (Session["MyCart"] != null)
            {
                DataTable dt = (DataTable)Session["MyCart"];
                DataRow drr = dt.Select("ProductID=" + ProductID + "").FirstOrDefault();
                if (drr != null)
                    dt.Rows.Remove(drr);
                Session["MyCart"] = dt;
            }
            GetMyCart();
        }

        

        protected void txtChanged(object sender, EventArgs e)
        {
            TextBox txtQuantity = (sender as TextBox);
            DataListItem currentItem = (sender as TextBox).NamingContainer as DataListItem;
            HiddenField ProductID = currentItem.FindControl("hfProductID") as HiddenField;
            Label lblAvilableStock = currentItem.FindControl("lblAvailableStockProducts") as Label;
            if (txtQuantity.Text == string.Empty || txtQuantity.Text == "0" || txtQuantity.Text == "1")
            {
                txtQuantity.Text = "1";
            }
            else
            {
                if (Session["MyCart"] != null)
                {
                    if (Convert.ToInt32(txtQuantity.Text) <= Convert.ToInt32(lblAvailableStockProducts.Text))
                    {
                        DataTable dt = (DataTable)Session["MyCart"];
                        DataRow[] rows = dt.Select("ProductID='" + ProductID.Value + "'");
                        int index = dt.Rows.IndexOf(rows[0]);
                        dt.Rows[index]["Quantity"] = txtQuantity.Text;
                        Session["MyCart"] = dt;
                    }
                    else
                    {
                        lblAvilableStock.Text = "Alert:Product BayOut Should not be more than availlable products";
                        txtQuantity.Text = "1";
                    }
                }
            }
            UpdateTotalBill(); 
        }
        private void UpdateTotalBill()
        {
            long TotalPrice = 0;
            long TotalProducts = 0;
            foreach(DataListItem item in delCartProducts.Items)
            {
                Label PriceLabel = item.FindControl("lblPrice") as Label;
                TextBox ProductQuantity = item.FindControl("txtProductQuantity") as TextBox;
                long ProductPrice = Convert.ToInt64(PriceLabel.Text) * Convert.ToInt64(ProductQuantity.Text);
                TotalPrice = TotalPrice + TotalPrice;
                TotalProducts = TotalProducts + Convert.ToInt32(ProductQuantity.Text);


            }
           
        }

        protected void lblLogo_Click(object sender, EventArgs e)
        {
            lblCatagoryName.Text = "Popular Designs at Shop";
           
            
            pnlProducts.Visible = true;
            pnlMyCart.Visible = false;
            
            pnlEmptyCart.Visible = false;
            pnlOrderPlacedSuccessfully.Visible = false;
            GetProducts(0);
            HighLightCartProducts();
        }

        protected void btnShopingHeart_Click1(object sender, EventArgs e)
        {
            GetMyCart();
            lblProducts.Text = "Customer Details ";
            lblCatagoryName.Text = "Products in Your Shopping Cart";
        }

        protected void btnPlaceOrder_Click(object sender, EventArgs e)
        {
            string productids = string.Empty;
            DataTable dt;
            if (Session["MyCart"] != null)
            {
                dt = (DataTable)Session["MyCart"];
            }



            BLL.Class1 obj = new BLL.Class1();


            
           
              
           GetMyCart();
           //lblTransactionNO.Text = "Your Transaction No:-" + dt.Rows[0][0];
           pnlOrderPlacedSuccessfully.Visible = true;
           
           pnlProducts.Visible = false;
           delCartProducts.Visible = false;

           pnlMyCart.Visible = false;
          
           pnlEmptyCart.Visible = false;

         

          
        }
      
       

        
    }
}