using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BusinessEntities;
using System.Text.RegularExpressions;
namespace BLogic
{
    public class UserBLogic : IUserBLogic
    {
        IUserDALInter UserDALField;
        public UserBLogic(IUserDALInter UserDALParameter)
        {
            UserDALField = UserDALParameter;
        }



        public int AddUser(UserEntities e)
        {


            return UserDALField.AddUser(e);


        }

        public List<UserEntities> ViewUser()
        {
            return UserDALField.ViewUser();
        }


    }


    public interface IUserBLogic
    {

        int AddUser(UserEntities e);
        List<UserEntities> ViewUser();

    }

    public class CarBLogic : ICarBLogic
    {

        ICarDALInter CarDALField;
        public CarBLogic(ICarDALInter CarDALParameter)
        {
            CarDALField = CarDALParameter;
        }





        public int AddCar(CarEntities e)
        {

            return CarDALField.AddCar(e);

        }

        public int RemoveCar(CarEntities e)
        {
            return CarDALField.RemoveCar(e);
        }

        public List<CarEntities> ViewCars()
        {
            return CarDALField.ViewCars();
        }
    }

    public interface ICarBLogic
    {
        int AddCar(CarEntities e);
        int RemoveCar(CarEntities e);

        List<CarEntities> ViewCars();

    }

    public class BookingBLogic : IBookingBLogic
    {
        IBookingDALInter BookingField;
        public BookingBLogic(IBookingDALInter BookingParameter)
        {
            BookingField = BookingParameter; 
        }

        public int AddBooking(BookingDetailEntities bde)
        {
            return BookingField.AddBooking(bde);
        }

        public List<BookingDetailEntities> ViewRecords()
        {
            return BookingField.ViewRecords();
        }

    }

    public interface IBookingBLogic
    {

        List<BookingDetailEntities> ViewRecords();
        int AddBooking(BookingDetailEntities bde);
        
        

    }


    public class AdminBLogic : IAdminBLogic
    {
        IAdminDALInter AdminField;
        public AdminBLogic(IAdminDALInter AdminParameter)
        {
            AdminField = AdminParameter;
        }
        public List<AdminTableEntities> ViewAdmin()
        {
            return AdminField.ViewAdmin();
        }
    }

    public interface IAdminBLogic
    {
        List<AdminTableEntities> ViewAdmin();
    }

    public class BankBLogic:IBankBLogic
    {
        IBankDALInter BankDALField;
        public BankBLogic(IBankDALInter BankDALparameter)
        {
            BankDALField = BankDALparameter;
        }

        public List<BankEntities> ViewBank()
        {
            return BankDALField.ViewBank();
        }
    }

    public interface IBankBLogic
    {
        List<BankEntities> ViewBank();
    }

    public static class BlogicManager
    {
        public static IUserBLogic GetUserLogicInstance()
        {
            IUserBLogic ob = new UserBLogic(IUserDALManager.GetUserInstance());
            return ob;
        }

        public static ICarBLogic GetCarLogicInstance()
        {
            ICarBLogic ob = new CarBLogic(ICarDALManager.GetCarInstance());
            return ob;
        }

        public static IBookingBLogic GetBookingInstance()
        {
            IBookingBLogic blo = new BookingBLogic(IBookingDALManager.GetBookingInstance());
            return blo;
        }

        public static IAdminBLogic GetAdminLogicInstance()
        {
            IAdminBLogic ob = new AdminBLogic(IAdminDALManager.GetAdminInstance());
            return ob;
        }

        public static IBankBLogic GetBankLogicInstance()
        {
            IBankBLogic obBankBLogic = new BankBLogic(IBankDALManager.GetBankInstance());
            return obBankBLogic;
        }
        //IUserBLogic ob = new UserBLogic(IUserDALManager.GetUserInstance);
    }

    
}
