using HotelLockVave.BusinessObjects.Models;
using HotelLockVave.BusinessObjects.Models.Utility;
using HotelLockVave.DAL.Repositories;
using HotelLockVave.DAL.Repositories.InterfaceRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace HotelLockVave.BLL
{
    public class TestResultService
    {
        private TestResultRepository objTestResultRepository;
        private UserService objUserService;
        private readonly IJWTManagerRepository _jWTManager;
        private readonly Encrypt _encrypt = new Encrypt("alphaict2019");

        public TestResultService(IEmailService email, IJWTManagerRepository jWTManager)
        {
            objTestResultRepository = new TestResultRepository();
            objUserService = new UserService(email, jWTManager);
            this._jWTManager = jWTManager;
        }

        public ResultViewModel<bool> InsertTestResult(TestsResultRequestViewModel objTestResult)
        {
            try
            {

                if (objTestResult == null)
                {
                    return new ResultViewModel<bool> { Result = false, ResponseCode = System.Net.HttpStatusCode.OK, Message = Message.Failure.ToString(), UserMessage = UserMessage.InvalidData };
                }

                else
                {
                    bool isValid = true;
                    string ValidationMessage = "";
                    var res1 = GetProductType(objTestResult.ProductTypeCode);

                    if (!(res1.Result != null && res1.Result.ProductTypeID > 0))
                    {
                        ValidationMessage = "Product Type Code not found";
                        isValid = false;
                    }

                    var res2 = GetPCBType(objTestResult.PCBTypeCode);

                    if (!(res2.Result != null && res2.Result.PCBTypeID > 0))
                    {
                        ValidationMessage += ",PCB Type Code not found.";
                        isValid = false;
                    }

                    var resUser = objUserService.IsUserExists(objTestResult.UserID);
                    if (!resUser.Result)
                    {
                        ValidationMessage += ",Invalid UserID.";
                        isValid = false;
                    }


                    if (!(objTestResult.SerialNo.Trim().Length == 11))
                    {
                        ValidationMessage += ",Invalid SerialNo, It should be 11 alphanumeric characters.";
                        isValid = false;
                    }

                    //-------------------

                    foreach (TestResultViewModel t in objTestResult.tests)
                    {
                        var res3 = GetTest(t.TestCaseCode);
                        if (res3.Result != null && res3.Result.TestID > 0)
                        {
                            if (res3.Result.ProductTypeCode != objTestResult.ProductTypeCode)
                            {
                                ValidationMessage += ", Test- " + t.TestCaseCode + " not found in ProductType -" + objTestResult.ProductTypeCode;
                                isValid = false;
                            }

                            if (res3.Result.PCBTypeCode != objTestResult.PCBTypeCode)
                            {
                                ValidationMessage += ", Test- " + t.TestCaseCode + " not found in PCBType -" + objTestResult.PCBTypeCode;
                                isValid = false;
                            }

                        }
                        else
                        {
                            ValidationMessage += ", Test- " + t.TestCaseCode + " not found.";
                            isValid = false;

                        }

                        if (string.IsNullOrWhiteSpace(t.Result))
                        {
                            ValidationMessage += ", Result is required.";
                            isValid = false;
                        }
                        else
                        {
                            if (!(t.Result.ToUpper() == "PASS" || t.Result.ToUpper() == "FAIL" || t.Result.ToUpper() == "TIMEOUT"))
                            {
                                ValidationMessage += ", Result must be Pass/Fail/Timeout";
                                isValid = false;
                            }
                        }

                        if (t.TimeStamp == DateTime.MinValue)
                        {
                            ValidationMessage += ", Timestamp is required.";
                            isValid = false;
                        }

                        if (t.MesuredValues.Length > 500)
                        {
                            ValidationMessage += ", MeasuredValues maximum lenght allowed is 500 characters";
                            isValid = false;
                        }
                    }
                    //-------------------


                    if (isValid)
                    {
                        int res = objTestResultRepository.InsertTestResult(objTestResult);
                        if (res > 0)
                        {
                            return new ResultViewModel<bool> { Result = true, ResponseCode = System.Net.HttpStatusCode.OK, Message = Message.Success.ToString(), UserMessage = "Test Result Inserted Successfully" };
                        }
                        else
                        {
                            return new ResultViewModel<bool> { Result = false, ResponseCode = System.Net.HttpStatusCode.BadRequest, Message = Message.Failure.ToString(), UserMessage = "Test Result Not Inserted" };
                        }
                    }
                    else
                    {
                        return new ResultViewModel<bool> { Result = false, ResponseCode = System.Net.HttpStatusCode.OK, Message = Message.Failure.ToString(), UserMessage = ValidationMessage };
                    }
                }
            }
            catch (Exception ex)
            {
                return new ResultViewModel<bool> { Result = false, ResponseCode = System.Net.HttpStatusCode.InternalServerError, Message = Message.Exception.ToString(), UserMessage = UserMessage.CompanyAddFailureMessage + " " + ex.ToString() };
            }
        }

        //public ResultViewModel<bool> InsertTestResult(TestsResultRequestViewModel objTestResult)
        //{
        //    try
        //    {

        //        if (objTestResult == null)
        //        {
        //            return new ResultViewModel<bool> { Result = false, ResponseCode = System.Net.HttpStatusCode.OK, Message = Message.Failure.ToString(), UserMessage = UserMessage.InvalidData };
        //        }

        //        else
        //        {
        //            bool isValid = true;
        //            string ValidationMessage = "";
        //            var res1 = GetProductType(objTestResult.ProductTypeCode);

        //            if (!(res1.Result!=null && res1.Result.ProductTypeID>0)) {
        //                ValidationMessage = "Product Type Code not found";
        //                isValid = false;
        //            }

        //            var res2 = GetPCBType(objTestResult.PCBTypeCode);

        //            if (!(res2.Result != null && res2.Result.PCBTypeID > 0))
        //            {
        //                ValidationMessage += ",PCB Type Code not found.";
        //                isValid = false;
        //            }


        //            //-------------------

        //            foreach (TestResultViewModel t in objTestResult.tests)
        //            {
        //                var res3 = GetTest(t.TestCaseCode);
        //                if (res3.Result != null && res3.Result.TestID > 0)
        //                {
        //                    if (res3.Result.ProductTypeCode != objTestResult.ProductTypeCode)
        //                    {
        //                        ValidationMessage += ", Test- " + t.TestCaseCode + " not found in ProductType -"+ objTestResult.ProductTypeCode;
        //                        isValid = false;
        //                    }

        //                    if (res3.Result.PCBTypeCode != objTestResult.PCBTypeCode)
        //                    {
        //                        ValidationMessage += ", Test- " + t.TestCaseCode + " not found in PCBType -" + objTestResult.PCBTypeCode;
        //                        isValid = false;
        //                    }

        //                }
        //                else
        //                {
        //                    ValidationMessage += ", Test- " + t.TestCaseCode + " not found.";
        //                    isValid = false;

        //                }
        //            }
        //            //-------------------


        //            if (isValid)
        //            {
        //                int res = objTestResultRepository.InsertTestResult(objTestResult);
        //                if (res>0)
        //                {
        //                    return new ResultViewModel<bool> { Result = true, ResponseCode = System.Net.HttpStatusCode.OK, Message = Message.Success.ToString(), UserMessage = "Test Result Inserted Successfully" };
        //                }
        //                else
        //                {
        //                    return new ResultViewModel<bool> { Result = false, ResponseCode = System.Net.HttpStatusCode.BadRequest, Message = Message.Failure.ToString(), UserMessage = "Test Result Not Inserted" };
        //                }
        //            }
        //            else
        //            {
        //                return new ResultViewModel<bool> { Result = false, ResponseCode = System.Net.HttpStatusCode.OK, Message = Message.Failure.ToString(), UserMessage = ValidationMessage };
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return new ResultViewModel<bool> { Result = false, ResponseCode = System.Net.HttpStatusCode.InternalServerError, Message = Message.Exception.ToString(), UserMessage = UserMessage.CompanyAddFailureMessage + " " + ex.ToString() };
        //    }
        //}


        public ResultViewModel<ProductTypeViewModel> GetProductType(string ProductTypeCode)
        {
            try
            {

                if (string.IsNullOrWhiteSpace(ProductTypeCode))
                {
                    return new ResultViewModel<ProductTypeViewModel> { Result = null, ResponseCode = System.Net.HttpStatusCode.OK, Message = Message.Failure.ToString(), UserMessage = "Product Type Code is mandatory" };
                }
                else
                {                   
                    ProductTypeViewModel res = objTestResultRepository.GetProductType(ProductTypeCode);
                    if (res !=null)
                    {
                        return new ResultViewModel<ProductTypeViewModel> { Result = res, ResponseCode = System.Net.HttpStatusCode.OK, Message = Message.Success.ToString(), UserMessage = "Query Successfully Executed" };
                    }
                    else
                    {
                        return new ResultViewModel<ProductTypeViewModel> { Result = null, ResponseCode = System.Net.HttpStatusCode.BadRequest, Message = Message.Failure.ToString(), UserMessage = "Record Not Found" };
                    }                   
                }
            }
            catch (Exception ex)
            {
                return new ResultViewModel<ProductTypeViewModel> { Result = null, ResponseCode = System.Net.HttpStatusCode.InternalServerError, Message = Message.Exception.ToString(), UserMessage ="Exception : " + ex.ToString() };
            }
        }

        public ResultViewModel<PCBTypeViewModel> GetPCBType(string PCBTypeCode)
        {
            try
            {

                if (string.IsNullOrWhiteSpace(PCBTypeCode))
                {
                    return new ResultViewModel<PCBTypeViewModel> { Result = null, ResponseCode = System.Net.HttpStatusCode.OK, Message = Message.Failure.ToString(), UserMessage = "PCB Type Code is mandatory" };
                }
                else
                {
                    PCBTypeViewModel res = objTestResultRepository.GetPCBType(PCBTypeCode);
                    if (res != null)
                    {
                        return new ResultViewModel<PCBTypeViewModel> { Result = res, ResponseCode = System.Net.HttpStatusCode.OK, Message = Message.Success.ToString(), UserMessage = "Query Successfully Executed" };
                    }
                    else
                    {
                        return new ResultViewModel<PCBTypeViewModel> { Result = null, ResponseCode = System.Net.HttpStatusCode.BadRequest, Message = Message.Failure.ToString(), UserMessage = "Record Not Found" };
                    }
                }
            }
            catch (Exception ex)
            {
                return new ResultViewModel<PCBTypeViewModel> { Result = null, ResponseCode = System.Net.HttpStatusCode.InternalServerError, Message = Message.Exception.ToString(), UserMessage = "Exception : " + ex.ToString() };
            }
        }

        public ResultViewModel<TestsProductPCBViewModel> GetTest(string TestCode)
        {
            try
            {

                if (string.IsNullOrWhiteSpace(TestCode))
                {
                    return new ResultViewModel<TestsProductPCBViewModel> { Result = null, ResponseCode = System.Net.HttpStatusCode.OK, Message = Message.Failure.ToString(), UserMessage = "Test Code is mandatory" };
                }
                else
                {
                    TestsProductPCBViewModel res = objTestResultRepository.GetTest(TestCode);
                    if (res != null)
                    {
                        return new ResultViewModel<TestsProductPCBViewModel> { Result = res, ResponseCode = System.Net.HttpStatusCode.OK, Message = Message.Success.ToString(), UserMessage = "Query Successfully Executed" };
                    }
                    else
                    {
                        return new ResultViewModel<TestsProductPCBViewModel> { Result = null, ResponseCode = System.Net.HttpStatusCode.BadRequest, Message = Message.Failure.ToString(), UserMessage = "Record Not Found" };
                    }
                }
            }
            catch (Exception ex)
            {
                return new ResultViewModel<TestsProductPCBViewModel> { Result = null, ResponseCode = System.Net.HttpStatusCode.InternalServerError, Message = Message.Exception.ToString(), UserMessage = "Exception : " + ex.ToString() };
            }
        }


        //filter service starts from here

        private TestResultRepository _testResultRepository;

        public TestResultService()
        {
            _testResultRepository = new TestResultRepository();
        }

        public ResultViewModel<IEnumerable<TestResultFilterViewModel>> GetPCBTestsStatus(TestsResultFilterRequestViewModel filter)
        {
            try
            {
                var results = objTestResultRepository.GetPCBTestsStatus(filter);
                return new ResultViewModel<IEnumerable<TestResultFilterViewModel>>
                {
                    Result = results,
                    ResponseCode = System.Net.HttpStatusCode.OK,
                    Message = Message.Success.ToString(),
                    UserMessage = "Query successfully executed"
                };
            }
            catch (Exception ex)
            {
                return new ResultViewModel<IEnumerable<TestResultFilterViewModel>>
                {
                    Result = null,
                    ResponseCode = System.Net.HttpStatusCode.InternalServerError,
                    Message = Message.Exception.ToString(),
                    UserMessage = "Exception: " + ex.ToString()
                };
            }
        }



        public ResultViewModel<List<PCBType>> GetPCB()
        {
            try
            {


  
                    List<PCBType> res = objTestResultRepository.GetPCB();
                    if (res != null)
                    {
                        return new ResultViewModel<List<PCBType>> { Result = res, ResponseCode = System.Net.HttpStatusCode.OK, Message = Message.Success.ToString(), UserMessage = "Query Successfully Executed" };
                    }
                    else
                    {
                        return new ResultViewModel<List<PCBType>> { Result = null, ResponseCode = System.Net.HttpStatusCode.BadRequest, Message = Message.Failure.ToString(), UserMessage = "Record Not Found" };
                    }
                
            }
            catch (Exception ex)
            {
                return new ResultViewModel<List<PCBType>> { Result = null, ResponseCode = System.Net.HttpStatusCode.InternalServerError, Message = Message.Exception.ToString(), UserMessage = "Exception : " + ex.ToString() };
            }
        }



        public ResultViewModel<List<ProductType>> GetProduct()
        {
            try
            {
                    List<ProductType> res = objTestResultRepository.GetProduct();
                    if (res != null)
                    {
                        return new ResultViewModel<List<ProductType>> { Result = res, ResponseCode = System.Net.HttpStatusCode.OK, Message = Message.Success.ToString(), UserMessage = "Query Successfully Executed" };
                    }
                    else
                    {
                        return new ResultViewModel<List<ProductType>> { Result = null, ResponseCode = System.Net.HttpStatusCode.BadRequest, Message = Message.Failure.ToString(), UserMessage = "Record Not Found" };
                    }   
            }
            catch (Exception ex)
            {
                return new ResultViewModel<List<ProductType>> { Result = null, ResponseCode = System.Net.HttpStatusCode.InternalServerError, Message = Message.Exception.ToString(), UserMessage = "Exception : " + ex.ToString() };
            }
        }



        public ResultViewModel<IEnumerable<TestCasePCBTypeRequestResult>> GetTestCase(TestCasePCBTypeRequest filter)
        {
            try
            {
                var results = objTestResultRepository.GetTestCase(filter);
                return new ResultViewModel<IEnumerable<TestCasePCBTypeRequestResult>>
                {
                    Result = results,
                    ResponseCode = System.Net.HttpStatusCode.OK,
                    Message = Message.Success.ToString(),
                    UserMessage = "Query successfully executed"
                };
            }
            catch (Exception ex)
            {
                return new ResultViewModel<IEnumerable<TestCasePCBTypeRequestResult>>
                {
                    Result = null,
                    ResponseCode = System.Net.HttpStatusCode.InternalServerError,
                    Message = Message.Exception.ToString(),
                    UserMessage = "Exception: " + ex.ToString()
                };
            }
        }
    }
}
