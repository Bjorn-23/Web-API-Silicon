using System.Diagnostics;
using Infrastructure.Repositories;
using Infrastructure.Entities;
using Infrastructure.Factories;
using Infrastructure.Utilities;

namespace Infrastructure.Services;

public class SubscriptionService(SubscriptionRepository subscriptionRepository)
{
    private readonly SubscriptionRepository _repository = subscriptionRepository;

    public async Task<ResponseResult> CreateOrUpdateSubscriptionAsync(SubscriptionEntity subscription)
    {
        try
        {
            var existingSubscription = await _repository.GetOneAsync(x => x.Email == subscription.Email);
            if (existingSubscription == null)
            {
                var result = await _repository.CreateAsync(subscription);
                if (result != null)
                {
                    return ResponseFactory.Created(SubscriptionFactory.Create(result), "Subscription created");                    
                }
            }
            if (existingSubscription != null)
            {
                subscription.Id = existingSubscription.Id;
                var result = await _repository.UpdateAsync(existingSubscription, subscription);
                if (result != null)
                {
                    return ResponseFactory.Ok(result, "Subscription updated"); ;
                }
            }

            return ResponseFactory.BadRequest();

        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;     
    }

    public async Task<SubscriptionEntity> GetOneSubscriptionsAsync(string Id)
    {
        try
        {
            var subscription = await _repository.GetOneAsync(x => x.Id == Id);
            if (subscription != null)
            {
                return subscription;
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex); }
        return null!;
    }

    public async Task<IEnumerable<SubscriptionEntity>> GetAllSubscriptionsAsyncAsync()
    {
        try
        {
            var existingSubscriptions = await _repository.GetAllAsync();
            if (existingSubscriptions.Count() >= 1)
            {
                return existingSubscriptions;
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex); }
        return null!;
    }

    public async Task<ResponseResult> UpdateSubscriptionAsync(SubscriptionEntity subscription)
    {
        try
        {
            var existingSubscription = await _repository.GetOneAsync(x => x.Id == subscription.Id);
            if (existingSubscription != null)
            {
                var result = await _repository.UpdateAsync(existingSubscription, subscription);
                if (result != null)
                {
                    return ResponseFactory.Ok(result, "Subscription updated");
                }
            }
            if (subscription == null)
            {
                return ResponseFactory.NotFound();
            }

            return ResponseFactory.BadRequest();

        }
        catch (Exception ex) { Debug.WriteLine(ex); }
        return null!;
    }

    public async Task<ResponseResult> DeleteSubscriptionAsync(string Id)
    {
        try
        {
            var existingSubscription = await _repository.GetOneAsync(x => x.Id == Id);
            if (existingSubscription != null)
            {
                var result = await _repository.DeleteAsync(existingSubscription);
                if (result)
                {
                    return ResponseFactory.Ok(existingSubscription, "Subscription deleted");
                }
            }
            if (existingSubscription == null)
            {
                return ResponseFactory.NotFound();
            }

            return ResponseFactory.BadRequest();
        }
        catch (Exception ex) { Debug.WriteLine(ex); }
        return null!;
    }

}
