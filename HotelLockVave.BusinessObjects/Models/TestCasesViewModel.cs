using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelLockVave.BusinessObjects.Models
{
  
    public class TestsResultRequestViewModel
    {
        
        public string ProductTypeCode { get; set; }
        public string PCBTypeCode { get; set; }
        public string SerialNo { get; set; }
        public int UserID { get; set; }
        public DateTime TimeStamp { get; set; }
        public List<TestResultViewModel> tests { get; set; }
    }
    public class TestsProductPCBViewModel
    {
        public int ProductTypeID { get; set; }
        public string ProductTypeCode { get; set; }
        public string ProductTypeName { get; set; }
        public int PCBTypeID { get; set; }
        public string PCBTypeCode { get; set; }
        public string PCBTypeName { get; set; } 
        public int TestID { get; set; }
        public string TestCaseCode { get; set; }
        public string TestName { get; set; }      
    }
    public class TestResultViewModel
    {
        public string TestCaseCode { get; set; }
        public string Result  { get; set; }
        public string MesuredValues { get; set; }
        public DateTime TimeStamp { get; set; }       
    }

    public class ProductTypeViewModel
    {
        public int ProductTypeID { get; set; }
        public string ProductTypeCode { get; set; }
        public string ProductTypeName { get; set; }
    }

    public class PCBTypeViewModel 
    {
        public int PCBTypeID { get; set; }
        public string PCBTypeCode { get; set; }
        public string PCBTypeName { get; set; }
    }

    //filter model
    public class TestsResultFilterRequestViewModel
    {
        public int? UserID { get; set; }
        public string ProductTypeCode { get; set; }
        public string PCBTypeCode { get; set; }
        public string Status { get; set; }
        public string RepeatTest { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
    }
    //public class TestResultFilterViewModel
    //{
    //    public int ID { get; set; }
    //    public int UserID { get; set; }
    //    public string ProductTypeCode { get; set; }
    //    public string PCBTypeCode { get; set; }
    //    public string TestCode { get; set; }
    //    public string PCBTypeName { get; set; }
    //    public string SerialNo { get; set; }
    //    public DateTime TimeStamp { get; set; }
    //    public string Status { get; set; }
    //    public string MesuredValues { get; set; }
    //    public string RepeateTest { get; set; }
    //    public string Status { get; set; }
    //}

    public class TestResultFilterViewModel
    {
        //public int ID { get; set; }
        public int UserID { get; set; }
        public string ProductTypeCode { get; set; }
        public string PCBTypeCode { get; set; }
        public string TestCode { get; set; }
        public string PCBTypeName { get; set; }
        public string SerialNo { get; set; }
        public DateTime TimeStamp { get; set; }
        public string Status { get; set; }
        public string MesuredValues { get; set; }
        public string RepeatTest { get; set; }
        //public string Status { get; set; }
    }


    // Models/PCBType.cs
    public class PCBType
    {
        public string PCBTypeName { get; set; }
        public string PCBTypeCode { get; set; }
        public int PCBTypeID { get; set; }
    }

    public class ProductType
    {
        public string ProductTypeName { get; set; }
        public string ProductTypeCode { get; set; }
        public int ProductTypeID { get; set; }
    }


    public class TestCasePCBTypeRequest
    {
        public int UserID { get; set; }
        public string ProductTypeCode { get; set; }
        public string PCBTypeCode { get; set; }
        //public string Status { get; set; }
        //public string RepeatTest { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string SerialNo { get; set; }
    }

    //public class TestCasePCBTypeRequestResult
    //{
    //    public string UserName { get; set; }
    //    public string SerialNo { get; set; }
    //    public string TestCaseName { get; set; }
    //    public DateTime? FromDate { get; set; }
    //    public DateTime? ToDate { get; set; }
    //    public string TestCaseStatus { get; set; }
    //    public DateTime Date { get; set; }
    //    public string PCBTypeName { get; set; }
    //    public string ProductTypeName { get; set; }
    //    public string MesuredValues { get; set; }
    //}


    public class TestCasePCBTypeRequestResult
    {
        public string UserName { get; set; }
        public string PCBTypeName { get; set; }
        public string ProductTypeName { get; set; }
        public string SerialNo { get; set; }
        public string FinalStatus { get; set; }
        public string TestCaseName { get; set; }
        public DateTime TestDate { get; set; }
        public string TestDateToDisplay { get; set; }
        public string TestTimeToDisplay { get; set; }
        public string TestCaseStatus { get; set; }
        public string MesuredValues { get; set; }
    }
}