using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLogic;
using BusinessEntities;
using System.Web.Security;
namespace CARZAN.Controllers
{
    public class CarzanController : Controller
    {

        public ActionResult Login()
        {
            return View();
        }



        [HttpPost]
        public ActionResult Login(FormCollection frm)
        {
            var ob = BlogicManager.GetUserLogicInstance();


            string S_username = frm["username"];

            string P_password = frm["password"];

            if (frm["user"] == "user")
            {
                var res = ob.ViewUser().Find(c => c.EmailID == S_username && c.Passwd == P_password);
                Session["userid"] = res.UserID;
                Session["username"] = res.FirstName;
                if (res != null)
                {
                    FormsAuthentication.RedirectFromLoginPage(S_username, false);

                    return RedirectToAction("UserHome");


                }
                else
                {
                    ViewBag.result = "Access Denied";
                    return RedirectToAction("Login");
                }
            }
            


                if (frm["user"] == "admin")
                {
                    var oba = BlogicManager.GetAdminLogicInstance();
                    var res = oba.ViewAdmin().Where(c => (c.EmailID == S_username && c.Passwd == P_password)).ToList();

                    if (res.Count() > 0)
                    {
                        FormsAuthentication.RedirectFromLoginPage(S_username, false);

                        return RedirectToAction("Admin");


                    }
                    else
                    {
                        ViewBag.result = "Access Denied";
                        return RedirectToAction("Login");
                    }
                }
            else
            {
                ViewBag.result = "Denied";
                return RedirectToAction("Login");
            }
            
            
        }


        // GET: Carzan
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(UserEntities e)
        {

            var ob = BlogicManager.GetUserLogicInstance();
            int i = ob.AddUser(e);
            if (i>0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
            
        }

        public ActionResult Admin()
        {


            return View();
        }
        public ActionResult AddDetails()
        {


            return View();
        }
        [HttpPost]
        public ActionResult AddDetails(CarEntities e)
        {

            var ob = BlogicManager.GetCarLogicInstance();
            int i = ob.AddCar(e);
            if (i > 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }

            
        }

        public ActionResult RemoveCar()
        {

            return View();

        }
        [HttpPost]
        public ActionResult RemoveCar(CarEntities e)
        {
            var ob = BlogicManager.GetCarLogicInstance();
            int i = ob.RemoveCar(e);
            if (i>0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        public ActionResult ViewRecords()
        {
            var res = BlogicManager.GetBookingInstance();
            var i = res.ViewRecords();
            int c = i.Count();
             return View(i);
            
        }
        //[HttpPost]
        //public ActionResult ViewRecords(BookingDetailEntities bd)
        //{
        //    return View();
        //}

        public ActionResult UserHome()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UserHome(FormCollection f)
        {

            DateTime datefrom = DateTime.Parse(f["datefrom"]);
            DateTime dateupto = DateTime.Parse(f["dateupto"]);
            var diffdayss = (dateupto.Date - datefrom.Date).Days;
            TempData["datefrom"] = datefrom;
            TempData["dateupto"] = dateupto;
            
            TempData.Keep();
            if (datefrom != null && dateupto !=null)
            {
                var bk = BlogicManager.GetBookingInstance();
                // var bkr = bk.ViewRecords().Where(c=> (c.BookedTo < datefrom) ||(c.BookedFrom > datefrom && c.BookedFrom > dateupto));


                   var bkr = bk.ViewRecords().Where(c => (c.BookedFrom >= datefrom && c.BookedFrom <= dateupto) && (c.BookedTo >= datefrom && c.BookedTo <= dateupto));

                int ct = bkr.Count();
                //select * from BookingDetails where ( BookedFrom between '07/22/2019' and '08/27/2019') and (BookedTo between '07/22/2019' and '08/27/2019')

                var ob = BlogicManager.GetCarLogicInstance();
                //var res = ob.ViewCars().Where(c=>c.CarNo != bkr.Where();

                var CarList = ob.ViewCars();


                var res = CarList.Where(c => !bkr.Any(y => y.CarNo == c.CarNo));

                List<CarEntities> li = new List<CarEntities>();

                foreach (var item in res)
                {
                   li.Add(new CarEntities() {CarName = item.CarName, CarNo = item.CarNo , CarType =item.CarType , CarImage = item.CarImage ,FullDayPrice = item.FullDayPrice });
                    
                }

                ViewBag.diffdayss = diffdayss;
                
                //ViewBag.EstimatedPrice = diffdayss * Convert.ToInt32(ViewBag.FPUH);





                #region
                //List<CarEntities> CarList = new List<CarEntities>();

                //foreach (var item in res)
                //{
                //    CarList.Add(new CarEntities() { CarNo = item.CarNo });
                //}



                //List<BookingDetailEntities> booked = new List<BookingDetailEntities>();

                //foreach (var item in bkr)
                //{
                //    booked.Add(new BookingDetailEntities() { CarNo = item.CarNo });
                //}





                //var res = (from t in ob.ViewCars()
                //           from o in bkr
                //          // where t.CarNo != o.CarNo
                //           select new { t.CarName, t.CarNo, t.CarType, t.CarImage }).Distinct();


                //var res = (from t in ob.ViewCars()
                //           join o in bkr on t.CarNo equals o.CarNo
                //           where t.CarNo == o.CarNo
                //           select new
                //           {
                //               t.CarName,
                //               t.CarNo,
                //               t.CarType,
                //               t.CarImage
                //           });

                //var res = (from o in bkr
                //           join t in ob.ViewCars() on o.CarNo equals t.CarNo
                //           where o.CarNo != t.CarNo
                //           select new
                //           {
                //               t.CarName,
                //               t.CarNo,
                //               t.CarType,
                //               t.CarImage
                //           });


                //var res = (from t in ob.ViewCars() 
                //           join o in bkr on t.CarNo equals o.CarNo  into temp
                //           from p in temp.DefaultIfEmpty()

                //          where t.CarNo == p.CarNo
                //           select new
                //           {
                //               t.CarName,
                //               t.CarNo,
                //               t.CarType,
                //               t.CarImage
                //           });


                //var res = from p in ob.ViewCars()
                //             group p by p.CarNo into pg
                //             // join *after* group
                //             join bp in bkr on pg.FirstOrDefault().CarNo equals bp.CarNo
                //             select new 
                //             {
                //                 pg.FirstOrDefault().CarNo,
                //                 pg.FirstOrDefault().CarName,
                //                 //MinPrice = pg.Min(m => m.Price),
                //                 //MaxPrice = pg.Max(m => m.Price),
                //                 //BaseProductName = bp.Name  // now there is a 'bp' in scope
                //             };


                // var rst = ob.ViewCars().Except(bkr);


                //var res = from t in ob.ViewCars()
                //          join o in bkr on t.CarNo equals o.CarNo into g
                //          from temp in gj.DefaultIfEmpty()
                //          where t.CarNo ==  
                //            select new { t.CarNo};



                //List<CarEntities> li = new List<CarEntities>();

                //foreach (var item in res)
                //{
                //    foreach (var item1 in bkr)
                //    {



                //                li.Add(new CarEntities() { CarNo = item.CarNo });


                //    }


                //}


                //List<CarEntities> ll1 = new List<CarEntities>();

                //foreach (var item in bkr)
                //{
                //    foreach (var item1 in li)
                //    {
                //        if (item.CarNo == item1.CarNo)
                //        {
                //            ll1.Add(item1);
                //        }
                //    }
                //}

                //for (int i = 0; i < li.Count; i++)
                //{
                //    for (int j = 0; j < ll1.Count ; j++)
                //    {
                //        if(li[i].CarNo == ll1[j].CarNo)
                //        {
                //            li.Remove(ll1[j]);
                //        }
                //    }
                //}
                #endregion
                return View(li);

                
            }
            else
            {
                return View();
              
            }
            
        }



        public ActionResult AddBooking(string id)
        {
            
            ViewBag.datefrom = TempData["datefrom"];
            ViewBag.dateupto = TempData["dateupto"];
            var diffdays = (ViewBag.dateupto.Date - ViewBag.datefrom.Date).Days;
            
            TempData["SelectedCarNO."] = id;
            

            var ob = BlogicManager.GetCarLogicInstance();

            //var i = ob.ViewCars().Find(id);
           var i = ob.ViewCars().Find(d=>d.CarNo == id );
            
            Session["Fullprice"] = i.FullDayPrice;
            
            ViewBag.TotalPriceFullDay = diffdays * Convert.ToInt32(Session["Fullprice"]);
            TempData["totalprice"] = ViewBag.TotalPriceFullDay;
            TempData.Keep();
            return View(i);
        }
        [HttpPost]
        public ActionResult AddBooking(FormCollection FormData)
        {
            
            

            

            string id = TempData["SelectedCarNO."].ToString();
            //int k = int.Parse(id);
            var obc = BlogicManager.GetCarLogicInstance();
            var res = obc.ViewCars().Find(d => d.CarNo == id);

            var obb = BlogicManager.GetBookingInstance();

            // var resultBooking = obb.ViewRecords().Where(c => c.UserID == Convert.ToInt32(Session["userid"]));
            //var resBCount = resultBooking.Count();
            //if (resBCount > 3)
            //{
            //    TempData["totalprice"] = Convert.ToInt32(TempData["totalprice"]) - (Convert.ToInt32(TempData["totalprice"]) * 30 / 100);
            //}
            var resultBooking = obb.ViewRecords().Where(c => c.UserID == Convert.ToInt32(Session["userid"]));
            var count = 0;
            foreach (var item in resultBooking)
            {
                if (Convert.ToDateTime(item.BookingDate).Month == Convert.ToDateTime(TempData["datefrom"]).Month)
                {
                    count = count + 1;
                }
                if(count==4)
                {
                    TempData["totalprice"] = Convert.ToInt32(TempData["totalprice"]) - (Convert.ToInt32(TempData["totalprice"]) * 30 / 100);
                }
            }



            var ob = BlogicManager.GetBookingInstance();

            BookingDetailEntities bd = new BookingDetailEntities()
            {

                UserID = Convert.ToInt32(Session["userid"]),
                CarNo = res.CarNo,
                BookingDate = DateTime.Now,
                BookedFrom = DateTime.Parse(TempData["datefrom"].ToString()),
                BookedTo = DateTime.Parse(TempData["dateupto"].ToString()),
                TotalPrice =Convert.ToInt32(TempData["totalprice"])
            };



            var i = ob.AddBooking(bd);
            if (i > 0)
            {
                return RedirectToAction("Payment");
            }
            else
            {
                return View();
            }

            
        }

        [HttpGet]
        public ActionResult Payment()
        {
           

            return View();
        }
        [HttpPost]
        public ActionResult Payment(FormCollection f)
        {
            var ob = BlogicManager.GetBankLogicInstance();
            var res = ob.ViewBank().Find(c => c.CardNo == f["CardNo"]);
            return View(res);
        }

        public ActionResult Feedback()
        {
            return View();
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }

}