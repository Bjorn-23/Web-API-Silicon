using Microsoft.AspNetCore.Mvc;
using Infrastructure.Services;
using Infrastructure.Factories;
using Infrastructure.Models;
using Web_API_Silicon.Filters;
using Web_API_Silicon.Helpers;



namespace Web_API_Silicon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [UseApiKey]
    public class SubscriptionsController(SubscriptionService subscriptionService, StatusCodeSelector statusCode) : ControllerBase
    {
        private readonly SubscriptionService _subscriptionService = subscriptionService;
        private readonly StatusCodeSelector _statusCode = statusCode;

        #region Create
        [HttpPost]
        public async Task<IActionResult> CreateOrUpdate(SubscriptionCreateModel subscriber)
        {
            if (ModelState.IsValid)
            {
                if (subscriber != null)
                {
                    var result = await _subscriptionService.CreateOrUpdateSubscriptionAsync(SubscriptionFactory.Create(subscriber));
                    if (result.StatusCode != null)
                    {
                        return _statusCode.StatusSelector(result);                        
                    }
                }
            }

            return BadRequest();
        }

        #endregion

        #region Read
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetOne(string Id)
        {
            if (ModelState.IsValid)
            {
                var result = await _subscriptionService.GetOneSubscriptionsAsync(Id);
                if (result != null)
                {
                    return Ok(SubscriptionFactory.Create(result));
                }
            }

            return BadRequest();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (ModelState.IsValid)
            {
                var result = await _subscriptionService.GetAllSubscriptionsAsyncAsync();
                if (result != null)
                {

                    return Ok(SubscriptionFactory.Create(result));
                }
            }

            return BadRequest();
        }

        #endregion

        #region Update
        [HttpPut]
        public async Task<IActionResult> Update(SubscriptionReturnModel model)
        {
            if (ModelState.IsValid)
            {
                var subscriber = SubscriptionFactory.Create(model);
                var result = await _subscriptionService.UpdateSubscriptionAsync(subscriber);
                if (result.StatusCode != null)
                {
                    return _statusCode.StatusSelector(result);
                }
            }

            return BadRequest();
        }
        #endregion

        #region Delete
        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(string Id)
        {
            if (ModelState.IsValid)
            {
                var result = await _subscriptionService.DeleteSubscriptionAsync(Id);
                if (result.StatusCode != null)
                {
                    return _statusCode.StatusSelector(result);
                }
            }

            return BadRequest();
        }
        #endregion
    }
}
