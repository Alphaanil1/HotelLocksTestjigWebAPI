using HotelLockVave.BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using System.Net.Sockets;
using System.Globalization;
using HotelLockVave.BusinessObjects.Models.Utility;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using System.Data.SqlClient;

namespace HotelLockVave.DAL.Repositories
{
    public class TestResultRepository
    {
        public int InsertTestResult(TestsResultRequestViewModel objTestsResult)
        {
            DBConnection objDBConnection = new DBConnection();

            try
            {
                int objReturnvalue = 0;
                DynamicParameters parameters;
                foreach(TestResultViewModel obj in objTestsResult.tests)
                {
                    parameters = new DynamicParameters();
                    parameters.Add("@ProductTypeCode", objTestsResult.ProductTypeCode);
                    parameters.Add("@PCBTypeCode", objTestsResult.PCBTypeCode);
                    parameters.Add("@SerialNo", objTestsResult.SerialNo);
                    parameters.Add("@UserID", objTestsResult.UserID);
                    parameters.Add("@TestCaseCode", obj.TestCaseCode);
                    parameters.Add("@Result", obj.Result);
                    parameters.Add("@TimeStamp", obj.TimeStamp);
                    parameters.Add("@MesuredValues", obj.MesuredValues);
                    objReturnvalue = Convert.ToInt32(objDBConnection.connection.ExecuteScalar("[dbo].[Usp_Ins_TestResult]", parameters,
               commandType: CommandType.StoredProcedure));
                }

                objDBConnection.CloseConnection();
                return objReturnvalue;
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public ProductTypeViewModel GetProductType(string ProductTypeCode)
        {
            DBConnection objDBConnection = new DBConnection();
            try
            {
                var res = objDBConnection.connection.Query<ProductTypeViewModel>("[dbo].[Usp_Sel_GetProductType]", new { @ProductTypeCode = ProductTypeCode },
                commandType: CommandType.StoredProcedure).Single();

                objDBConnection.CloseConnection();
                return res;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                objDBConnection.CloseConnection();
            }
        }


        public PCBTypeViewModel GetPCBType(string PCBTypeCode)
        {
            DBConnection objDBConnection = new DBConnection();
            try
            {
                var objManagers = objDBConnection.connection.Query<PCBTypeViewModel>("[dbo].[Usp_Sel_GetPCBType]", new { @PCBTypeCode = PCBTypeCode },
                commandType: CommandType.StoredProcedure).Single();

                objDBConnection.CloseConnection();
                return objManagers;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                objDBConnection.CloseConnection();
            }
        }

        public TestsProductPCBViewModel GetTest(string TestCode)
        {
            DBConnection objDBConnection = new DBConnection();
            try
            {
                var res = objDBConnection.connection.Query<TestsProductPCBViewModel>("[dbo].[Usp_Sel_GetTest]", new { @TestCode = TestCode },
                commandType: CommandType.StoredProcedure).Single();

                objDBConnection.CloseConnection();
                return res;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                objDBConnection.CloseConnection();
            }
        }

        //filter repository starts from here
        public IEnumerable<TestResultFilterViewModel> GetPCBTestsStatus(TestsResultFilterRequestViewModel filter)
        {
            DBConnection objDBConnection = new DBConnection();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@UserID", filter.UserID);
                parameters.Add("@ProductTypeCode", filter.ProductTypeCode);
                parameters.Add("@PCBTypeCode", filter.PCBTypeCode);
                parameters.Add("@Status", filter.Status);
                parameters.Add("@RepeatTest", filter.RepeatTest);
                parameters.Add("@FromDate", filter.FromDate);
                parameters.Add("@ToDate", filter.ToDate);

                var results = objDBConnection.connection.Query<TestResultFilterViewModel>("[dbo].[Usp_Rpt_GetPCBTestsStatus]", parameters,
                commandType: CommandType.StoredProcedure
                );

                objDBConnection.CloseConnection();
                return results;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objDBConnection.CloseConnection();
            }
        }


        public List<PCBType> GetPCB()
        {
            DBConnection objDBConnection = new DBConnection();
            try
            {
                var objPCB = objDBConnection.connection.Query<PCBType>("[dbo].[Usp_Sel_GetPCB]",
                commandType: CommandType.StoredProcedure).ToList();

                objDBConnection.CloseConnection();
                return objPCB;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                objDBConnection.CloseConnection();
            }
        }

        public List<ProductType> GetProduct()
        {
            DBConnection objDBConnection = new DBConnection();
            try
            {
                var objProduct = objDBConnection.connection.Query<ProductType>("[dbo].[Usp_Sel_GetProduct]",
                commandType: CommandType.StoredProcedure).ToList();

                objDBConnection.CloseConnection();
                return objProduct;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                objDBConnection.CloseConnection();
            }
        }


        public IEnumerable<TestCasePCBTypeRequestResult> GetTestCase(TestCasePCBTypeRequest filter)
        {
            DBConnection objDBConnection = new DBConnection();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@UserID", filter.UserID);
                parameters.Add("@ProductTypeCode", filter.ProductTypeCode);
                parameters.Add("@PCBTypeCode", filter.PCBTypeCode);
                parameters.Add("@FromDate", filter.FromDate);
                parameters.Add("@ToDate", filter.ToDate);
                parameters.Add("@SerialNo", filter.SerialNo);
                //parameters.Add("@FinalStatus", filter.FinalStatus);
                // parameters.Add("@RepeatTest", filter.RepeatTest);



                var resultsPCB = objDBConnection.connection.Query<TestCasePCBTypeRequestResult>("[dbo].[Usp_Rpt_TestDetails]", parameters,
                commandType: CommandType.StoredProcedure
                );

                objDBConnection.CloseConnection();
                return resultsPCB;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objDBConnection.CloseConnection();
            }
        }
    }
}
