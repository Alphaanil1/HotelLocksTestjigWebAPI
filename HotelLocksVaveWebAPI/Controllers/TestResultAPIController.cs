using HotelLockVave.BLL;
using HotelLockVave.BusinessObjects.Models;
using HotelLockVave.DAL.Repositories.InterfaceRepositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace  HotelLocksWebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TestResultController : ControllerBase
    {
        public TestResultService objTestResultService;
        public IEmailService iemailService;
        private readonly IJWTManagerRepository _jWTManager;
        private IConfiguration configuration;

        public TestResultController(IEmailService emailService, IJWTManagerRepository jWTManager, IConfiguration _configuration)
        {
            objTestResultService = new TestResultService(emailService, jWTManager);
            this._jWTManager = jWTManager;
            this.configuration = _configuration;
        }
       
        [HttpPost("InsertTestResult")]
        public ResultViewModel<bool> InsertTestResult(TestsResultRequestViewModel objTestResult)
        {
            ResultViewModel<bool> objResult = objTestResultService.InsertTestResult(objTestResult);
            return objResult;
        }

        //filter controller starts from here
        private readonly TestResultService _testResultService;

        [AllowAnonymous]
        [HttpPost("GetPCBTestsStatus")]
        public ResultViewModel<IEnumerable<TestResultFilterViewModel>> GetPCBTestsStatus(TestsResultFilterRequestViewModel filter)
        {
            return objTestResultService.GetPCBTestsStatus(filter);
        }


        [AllowAnonymous]
        [HttpGet("GetPCB")]
        public ResultViewModel<List<PCBType>> GetPCB()
        {
            ResultViewModel<List<PCBType>> objResult = objTestResultService.GetPCB();
            return objResult;
        }

        [AllowAnonymous]
        [HttpGet("GetProduct")]
        public ResultViewModel<List<ProductType>> GetProduct()
        {
            ResultViewModel<List<ProductType>> objResult = objTestResultService.GetProduct();
            return objResult;
        }



        [AllowAnonymous]
        [HttpPost("GetTestCase")]
        public ResultViewModel<IEnumerable<TestCasePCBTypeRequestResult>> GetTestCase(TestCasePCBTypeRequest filter)
        {
            return objTestResultService.GetTestCase(filter);
        }
    }
}
