using KCBVooma.Models;
using KCBVooma.Services.CreditCard;
using KCBVooma.Utility;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace KCBVooma.Controllers
{
    public class CreditCardController : ControllerBase
    {
        private readonly ICreditCardService _creditCardService;

        public CreditCardController(ICreditCardService creditCardService)
        {
            _creditCardService = creditCardService;
        }

        [HttpGet]
        [Route("GetAllCards")]
        public IActionResult GetAll()
        {
            CommonResponse<List<CreditCardModel>> commonResponse = new CommonResponse<List<CreditCardModel>>();
            try
            {
                commonResponse.dataenum = _creditCardService.GetCreditCardList();
                if (commonResponse.status > 0)
                {
                    commonResponse.message = Helper.getCreditCardList;
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

        [HttpGet]
        [Route("GetCardByID")]
        public IActionResult GetCreditCardByID(int id)
        {
            CommonResponse<CreditCardModel> commonResponse = new CommonResponse<CreditCardModel>();
            try
            {
                commonResponse.dataenum = _creditCardService.GetCardById(id);
                if (commonResponse.status > 0)
                {
                    commonResponse.message = Helper.getCreditCardListById;
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
        [Route("AddCard")]
        public IActionResult Post(CreditCardModel data)
        {
            CommonResponse<int> commonRespose = new CommonResponse<int>();
            try
            {
                commonRespose.status = _creditCardService.AddCard(data).Result;
                if (commonRespose.status == 200)
                {
                    commonRespose.message = Helper.cardAdded;
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
        [Route("UpdateCard")]
        public IActionResult Update(CreditCardModel data)
        {
            CommonResponse<int> commonResponse = new CommonResponse<int>();
            try
            {
                commonResponse.status = _creditCardService.UpdateCard(data).Result;
                if (commonResponse.status > 0)
                {
                    commonResponse.message = Helper.cardUpdated;
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

        [HttpGet]
        [Route("DeleteCard")]
        public IActionResult Delete(int id)
        {
            CommonResponse<int> commonResponse = new CommonResponse<int>();
            try
            {
                commonResponse.status = _creditCardService.DeleteCard(id).Result;
                if (commonResponse.status > 0)
                {
                    commonResponse.message = Helper.cardDeleted;
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

        [HttpGet]
        [Route("GetAccountByCardID")]
        public IActionResult GetAccountByCardID(int id)
        {
            CommonResponse<CreditCardModel> commonResponse = new CommonResponse<CreditCardModel>();
            try
            {
                commonResponse.dataenum = _creditCardService.GetAccByCardId(id);
                if (commonResponse.status > 0)
                {
                    commonResponse.message = Helper.getCreditCardListById;
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
