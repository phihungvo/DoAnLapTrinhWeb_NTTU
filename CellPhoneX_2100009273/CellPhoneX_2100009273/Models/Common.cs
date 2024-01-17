using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;

namespace CellPhoneX_2100009273.Models
{
    public class Common
    {
        public static List<Product> getProducts()
        {

            //Hàm lấy ra danh sách tất cả sản phẩm của một loại nào đó
            List<Product> l = new List<Product>();
            //Khai báo 1 đối tượng đại diện cho DB
            DBContext cn = new DBContext("name=DBContext");
            //Lấy dữ liệu
            l = cn.Set<Product>().ToList<Product>();
            return l;
        }


        //Lấy ra danh sách các loại hàng hoasanr phẩm
        public static List<Category> GetCategories()
        {
            return new DBContext("name=DBContext").Set<Category>().ToList<Category>();
        }

        [HttpGet]
        public static List<Product> getProductByCateId(int cateId)
        {
            List<Product> l = new List<Product>();
            //Khai bao 1 doi tuong dai dien cho db
            DBContext cn = new DBContext("name=DBContext");
            //Lay du lieu 
            l = cn.Set<Product>().Where(x => x.CatId == cateId).ToList<Product>();
            return l;
        }


        public static List<Product> get8Products()
        {
            List<Product> l = new List<Product>();
            //Khai bao 1 doi tuong dai dien cho db
            DBContext cn = new DBContext("name=DBContext");
            //Lay du lieu 
            l = cn.Set<Product>().Take(8).ToList<Product>();
            return l;
        }


        //public static double getTotalMoneyOneDay()
        //{
        //    double totalMoney = 0; // Sử dụng kiểu dữ liệu phù hợp với số tiền, ví dụ double hoặc decimal
        //    using (var cn = new DBContext("name=DBContext"))
        //    {
        //        totalMoney =(double) cn.OrderDetails.Sum(p => p.Price * p.Quantity); // Sử dụng Sum để tính tổng
        //    }
        //    return totalMoney;
        //}
    }
}