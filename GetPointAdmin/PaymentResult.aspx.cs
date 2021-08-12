using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GetPointAdmin
{
    public partial class PaymentResult : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Handle Order and set paid 
            try
            {
                GetPointEntities db = new GetPointEntities();

                string tapid = Request.QueryString["tap_id"].ToString();
                string strTapRes = new PaymentGateway.TAPGateway().GetChargeInfo(tapid);
                JObject json = JObject.Parse(strTapRes);
                string str = GetJArrayValue(json, "status");

                if (str == "CAPTURED")
                {
                    int OrderID = Convert.ToInt32(Request.QueryString["sid"]);
                    int CustomerID = Convert.ToInt32(Request.QueryString["CID"]);

                    //Update order set status if success, set status =1
                    var ord = db.tbl_Order.Where(c => c.OrderID == OrderID).FirstOrDefault();
                    ord.OrderStatusID = 1;

                    //Close Shooping Cart For Customer
                    List<tbl_ShoppingCartItem> lstShopping = new List<tbl_ShoppingCartItem>();
                    lstShopping = db.tbl_ShoppingCartItem.Where(c => c.CustomerID == CustomerID && c.Closed == false).ToList();
                    foreach (var item in lstShopping)
                    {
                        item.Closed = true;
                    }

                    db.SaveChanges();
                    lblResult.Text = "Payemnt Success";
                    lblResult.Visible = true;
                }
                else
                {
                    //To Do
                    //Delete Order Items and Order
                    int OrderID = Convert.ToInt32(Request.QueryString["sid"]);

                    var lstOrderItems = db.tbl_OrderItem.Where(c => c.OrderID == OrderID).ToList();
                    db.tbl_OrderItem.RemoveRange(lstOrderItems);

                    db.SaveChanges();


                    var TempOrder = db.tbl_Order.Where(c => c.OrderID == OrderID).FirstOrDefault();
                    db.tbl_Order.Remove(TempOrder);
                    db.SaveChanges();


                    lblResult.Text = "Payemnt Failed";
                    lblResult.Visible = true;

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string GetJArrayValue(JObject yourJArray, string key)
        {
            foreach (KeyValuePair<string, JToken> keyValuePair in yourJArray)
            {
                if (key == keyValuePair.Key)
                    return keyValuePair.Value.ToString();
            }
            return "";
        }
    }
}