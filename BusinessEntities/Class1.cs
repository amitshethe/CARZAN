using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public  class AdminTableEntities
    {
        public int AdminID { get; set; }
        public Nullable<int> BookingID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailID { get; set; }
        public string Passwd { get; set; }
        public string MobileNo { get; set; }
        public string AdminAddress { get; set; }
        public string AadharNo { get; set; }
        public string ProfilePic { get; set; }
        public Nullable<System.DateTime> DoB { get; set; }
        public string Gender { get; set; }

        public virtual BookingDetailEntities BookingDetail { get; set; }
    }

    public  class BookingDetailEntities
    {
        

        public int BookingID { get; set; }
        public Nullable<System.DateTime> BookingDate { get; set; }
        public string CarNo { get; set; }
        public Nullable<int> UserID { get; set; }
        public Nullable<System.DateTime> BookedFrom { get; set; }
        public Nullable<System.DateTime> BookedTo { get; set; }
        public Nullable<int> TotalPrice { get; set; }

        public virtual CarEntities Car { get; set; }
        public virtual UserEntities User { get; set; }
       
    }

    public  class CarEntities
    {
     
       

        public string CarNo { get; set; }
        public string CarName { get; set; }
        public string FuelType { get; set; }
        public string AirConditioning { get; set; }
        public string TransmissionType { get; set; }
        public Nullable<int> SeatingCapacity { get; set; }
        public Nullable<int> Mileage { get; set; }
        public string CarType { get; set; }
        public Nullable<System.DateTime> YearofManufacture { get; set; }
        public Nullable<int> FullDayPrice { get; set; }
        public Nullable<int> HalfDayPrice { get; set; }
        public string CarImage { get; set; }
        public virtual ICollection<BookingDetailEntities> BookingDetails { get; set; }


    }

    public class UserEntities
    {
        

        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailID { get; set; }
        public string Passwd { get; set; }
        public string MobileNo { get; set; }
        public string UserAddress { get; set; }
        public string LicenseNo { get; set; }
        public string AadharNo { get; set; }
        public string ProfilePic { get; set; }
        public Nullable<System.DateTime> DoB { get; set; }
        public string Gender { get; set; }

        
    }

    public  class BankEntities
    {
        public int AccountNo { get; set; }
        public Nullable<int> UserID { get; set; }
        public string CardNo { get; set; }
        public string Expiry { get; set; }
        public string CVV { get; set; }
        public Nullable<int> Balance { get; set; }

        public virtual UserEntities User { get; set; }
    }
}
