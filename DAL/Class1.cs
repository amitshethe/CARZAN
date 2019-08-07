using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities;
using System.Data.Entity;
namespace DAL
{
    
    public class UserDAL : IUserDALInter
    {
        CarzanEntities db = new CarzanEntities();
        public int AddUser(UserEntities e)
        {
            User u = new User()
            {
                UserID = e.UserID,
                FirstName = e.FirstName,
                LastName = e.LastName,
                EmailID = e.EmailID,
                Passwd = e.Passwd,
                MobileNo = e.MobileNo,
                UserAddress = e.UserAddress,
                AadharNo = e.AadharNo,
                ProfilePic = e.ProfilePic,
                DoB = e.DoB,
                Gender = e.Gender,
                LicenseNo = e.LicenseNo
                
            };
            db.Users.Add(u);
            db.SaveChanges();
            return 1;
        }

        

        public int DeleteUser(UserEntities e)
        {
            User d = new User { UserID = e.UserID };
            //int id = d.UserID;

            var res = db.Users.Find(d.UserID);
            db.Users.Remove(res);
            db.SaveChanges();
            return 1;
        }

        public int UpdateUser(UserEntities e)
        {
            User updateObject = new User { UserID = e.UserID };
            var res = db.Users.Find(updateObject.UserID);
            res.UserAddress = "agra";
            db.Entry<User>(res).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return 1;
        }

        public List<UserEntities> ViewUser()
        {
             var VU = db.Users.ToList();

            List<UserEntities> UE = new List<UserEntities>();
            
               foreach (var item in VU)
            {
                UE.Add(new UserEntities
                {
                    UserID = item.UserID,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    EmailID = item.EmailID,
                    Passwd = item.Passwd,
                    MobileNo = item.MobileNo,
                    UserAddress = item.UserAddress,
                    AadharNo = item.AadharNo,
                    ProfilePic = item.ProfilePic,
                    DoB = item.DoB,
                    Gender = item.Gender,
                    LicenseNo = item.LicenseNo
                });
            
            };

            return UE;
        }
    }

    public class CarDAL : ICarDALInter
    {
        CarzanEntities db = new CarzanEntities();

        public int AddCar(CarEntities e)
        {
            Car c = new Car()
            {

                CarNo = e.CarNo,
                CarName = e.CarName,
                FuelType = e.FuelType,
                AirConditioning = e.AirConditioning,
                TransmissionType = e.TransmissionType,
                SeatingCapacity = e.SeatingCapacity,
                Mileage = e.Mileage,
                CarType = e.CarType,
                YearofManufacture = e.YearofManufacture,
                FullDayPrice = e.FullDayPrice,
                HalfDayPrice = e.HalfDayPrice,
                CarImage = e.CarImage,

            };

            db.Cars.Add(c);
            db.SaveChanges();
            return 1;
        }

        public int RemoveCar(CarEntities e)
        {
            Car c = new Car()
            {
                CarNo = e.CarNo
            };
            var res = db.Cars.Find(c.CarNo);
            db.Cars.Remove(res);
            db.SaveChanges();
            return 1;
        }

        public List<CarEntities> ViewCars()
        {
            var res = db.Cars.ToList();
            int c = res.Count();

            List<CarEntities> li = new List<CarEntities>();
            foreach (var item in res)
            {
                li.Add(new CarEntities()
                {
                    CarNo = item.CarNo,
                    CarName = item.CarName,
                    FuelType = item.FuelType,
                    AirConditioning = item.AirConditioning,
                    TransmissionType = item.TransmissionType,
                    SeatingCapacity = item.SeatingCapacity,
                    Mileage = item.Mileage,
                    CarType = item.CarType,
                    YearofManufacture = item.YearofManufacture,
                    FullDayPrice = item.FullDayPrice,
                    HalfDayPrice = item.HalfDayPrice,
                    CarImage = item.CarImage,
                });
            }
            return li;
        }
    }

    public class BookingDAL: IBookingDALInter
    {
        CarzanEntities db = new CarzanEntities();

        public List<BookingDetailEntities> ViewRecords()
        {



            //BookingDetail bdetail = new BookingDetail()
            //{
            //    BookingID = bde.BookingID,
            //    UserID = bde.UserID,
            //    CarNo = bde.CarNo,
            //    BookingDate = bde.BookingDate,
            //    BookedFrom = bde.BookedFrom,
            //    BookedTo = bde.BookedTo,
            //    TotalPrice = bde.TotalPrice
            //};


            var res = db.BookingDetails.ToList();
            int c = res.Count();

            List<BookingDetailEntities> li = new List<BookingDetailEntities>();
            foreach (var item in res)
            {
                li.Add(new BookingDetailEntities() {
                    BookingID = item.BookingID,
                    UserID = item.UserID,
                    CarNo = item.CarNo,
                    BookingDate = item.BookingDate,
                    BookedFrom = item.BookedFrom,
                    BookedTo = item.BookedTo,
                    TotalPrice = item.TotalPrice
                });
            }


            // List<BookingDetail> ListBooking = new List<BookingDetailEntities>
            //var res = db.BookingDetails<>.ToList();
                return li;
        }

        public int AddBooking(BookingDetailEntities bde)
        {

            CarzanEntities db = new CarzanEntities();

            BookingDetail ABO = new BookingDetail()
            {
                BookingID = bde.BookingID,
                UserID = bde.UserID,
                CarNo = bde.CarNo,
                BookingDate = bde.BookingDate,
                BookedFrom = bde.BookedFrom,
                BookedTo = bde.BookedTo,
                TotalPrice = bde.TotalPrice
            };

            db.BookingDetails.Add(ABO);
            db.SaveChanges();
            return 1;
        }

    }

    public class AdminDAL: IAdminDALInter
    {


        public List<AdminTableEntities> ViewAdmin()
        {
            CarzanEntities db = new CarzanEntities();
             var AV = db.AdminTables.ToList();
            List<AdminTableEntities> AE = new List<AdminTableEntities>();

            foreach (var item in AV)
            {
                AE.Add(new AdminTableEntities {

                    AdminID = item.AdminID,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    EmailID = item.EmailID,
                    Passwd = item.Passwd,
                    MobileNo = item.MobileNo,
                    AdminAddress = item.AdminAddress,
                    AadharNo = item.AadharNo,
                    ProfilePic = item.ProfilePic,
                    DoB = item.DoB,
                    Gender = item.Gender,
                    BookingID = item.BookingID


                });
            }




            return AE;
        }
    }

    public class BankDAL : IBankDALInter
    {
        CarzanEntities db = new CarzanEntities();
        public List<BankEntities> ViewBank()
        {
            var btl = db.Banks.ToList();

            List<BankEntities> bankDE = new List<BankEntities>();

            foreach (var item in btl)
            {
                bankDE.Add(new BankEntities {

                    AccountNo = item.AccountNo,
                    UserID = item.UserID,
                    CardNo = item.CardNo,
                    Expiry = item.Expiry,
                    CVV = item.CVV,
                    Balance = item.Balance
                });
            }

            return bankDE;
            
        }
    }

    public interface IUserDALInter
    {
        int AddUser(UserEntities e);
        int UpdateUser(UserEntities e);
        int DeleteUser(UserEntities e);
        List<UserEntities> ViewUser();

    }

    public interface ICarDALInter
    {

        int AddCar(CarEntities e);
        int RemoveCar(CarEntities e);
        List<CarEntities> ViewCars();


    }

    public interface IBookingDALInter
    {
        List<BookingDetailEntities> ViewRecords();
        int AddBooking(BookingDetailEntities bde);
    }

    public interface IAdminDALInter
    {
        List<AdminTableEntities> ViewAdmin();
    }

    public interface IBankDALInter
    {
        List<BankEntities> ViewBank();
    }

    public static class IUserDALManager
    {
        public static IUserDALInter GetUserInstance()
        {
            IUserDALInter ob = new UserDAL();
            return ob;
        }
        
        
    }
    public static class ICarDALManager
    {
        public static ICarDALInter GetCarInstance()
        {
            ICarDALInter ob = new CarDAL();
            return ob;
        }
    }

    public static class IBookingDALManager
    {
        public static IBookingDALInter GetBookingInstance()
        {
            IBookingDALInter bdl = new BookingDAL();
            return bdl;
        }
    }

    public static class IAdminDALManager
    {
        public static IAdminDALInter GetAdminInstance()
        {
            IAdminDALInter ado = new AdminDAL();
            return ado;
        }
    }

    public static class IBankDALManager
    {
        public static IBankDALInter GetBankInstance()
        {
            IBankDALInter obBank = new BankDAL();
            return obBank;
        }
    }
}











//public int AddUser(AdminTableEntities e)
//{
//    AdminTable u = new AdminTable()
//    {
//        AdminID = e.AdminID,
//        FirstName = e.FirstName,
//        LastName = e.LastName,
//        EmailID = e.EmailID,
//        Passwd = e.Passwd,
//        MobileNo = e.MobileNo,
//        AdminAddress = e.AdminAddress,
//        AadharNo = e.AadharNo,
//        ProfilePic = e.ProfilePic,
//        DoB = e.DoB,
//        Gender = e.Gender,
//    };
//    db.AdminTables.Add(u);
//    return 1;
//}