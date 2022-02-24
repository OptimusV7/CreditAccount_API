using KCBVooma.Models;
using KCBVooma.Services.Account;
using KCBVooma.Utility;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace KCBVooma.Controllers
{
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        [Route("GetAllAccounts")]
        public IActionResult GetAll()
        {
            CommonResponse<List<AccountModel>> commonResponse = new CommonResponse<List<AccountModel>>();
            try
            {
                commonResponse.dataenum = _accountService.GetAccountList();
                if (commonResponse.status > 0)
                {
                    commonResponse.message = Helper.getAccountList;
                    commonResponse.status = Helper.success_code;
                }
            }
            catch (Exception e)
            {
                commonResponse.message = e.Message;
                commonResponse.status = Helper.failure_code;
            }

            return Ok(commonResponse);
        }

        [HttpPost]
        [Route("GetAccountByID")]
        public IActionResult GetAccountByID(int id)
        {
            CommonResponse<AccountModel> commonResponse = new CommonResponse<AccountModel>();
            try
            {
                commonResponse.dataenum = _accountService.GetAccount(id);
                if (commonResponse.status > 0)
                {
                    commonResponse.message = Helper.getAccountById;
                    commonResponse.status = Helper.success_code;
                }
            }
            catch (Exception e)
            {
                commonResponse.message = e.Message;
                commonResponse.status = Helper.failure_code;
            }

            return Ok(commonResponse);
        }

        [HttpPost]
        [Route("AddAccount")]
        public IActionResult Post(AccountModel data)
        {
            CommonResponse<int> commonRespose = new CommonResponse<int>();
            try
            {
                commonRespose.status = _accountService.AddAccount(data).Result;
                if (commonRespose.status == 200)
                {
                    commonRespose.message = Helper.accountAdded;
                    commonRespose.status = Helper.success_code;
                }
            }
            catch (Exception e)
            {
                commonRespose.message = e.Message;
                commonRespose.status = Helper.failure_code;

            }

            return Ok(commonRespose);
        }

        [HttpPut]
        [Route("UpdateAccount")]
        public IActionResult Update(AccountModel data)
        {
            CommonResponse<int> commonResponse = new CommonResponse<int>();
            try
            {
                commonResponse.status = _accountService.UpdateAccount(data).Result;
                if (commonResponse.status > 0)
                {
                    commonResponse.message = Helper.accountUpdated;
                    commonResponse.status = Helper.success_code;
                }
            }
            catch (Exception e)
            {
                commonResponse.message = e.Message;
                commonResponse.status = Helper.failure_code;
            }

            return Ok(commonResponse);
        }

        [HttpDelete]
        [Route("DeleteAccount")]
        public IActionResult Delete(int id)
        {
            CommonResponse<int> commonResponse = new CommonResponse<int>();
            try
            {
                commonResponse.status = _accountService.DeleteAccount(id).Result;
                if (commonResponse.status > 0)
                {
                    commonResponse.message = Helper.accountDeleted;
                    commonResponse.status = Helper.success_code;
                }
            }
            catch (Exception e)
            {
                commonResponse.message = e.Message;
                commonResponse.status = Helper.failure_code;
            }

            return Ok(commonResponse);
        }
    }
}
