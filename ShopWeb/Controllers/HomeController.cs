﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopWeb.Models;

namespace ShopWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ShopBusinessLogic.MemberPurchase memberPurchase = new ShopBusinessLogic.MemberPurchase();
            var goods_list = memberPurchase.getGoodsList().Select(goods_info => new MemberPurchaseCarViewModel()
            {
                goods_id = goods_info.goods_id,
                goods_name = goods_info.goods_name,
                goods_img_path = goods_info.goods_img_path,
                unit_price = goods_info.goods_price,
                sell_stock=goods_info.goods_stock,
                sell_volume=goods_info.goods_volume,
                seller_phone=goods_info.seller_phone,
            }).ToList();
            var resView = new PurchaseHomeTotalInfo()
            {
                total_goods_list = goods_list,
            };
            return View(resView);
        }
    }
}