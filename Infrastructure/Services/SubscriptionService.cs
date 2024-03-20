using Infrastructure.Entity;
using Infrastructure.Repositories;
using System.Diagnostics;

namespace Infrastructure.Services;

public class SubscriptionService(SubscriptionRepository subscriptionRepository)
{
    private readonly SubscriptionRepository _repository = subscriptionRepository;

    public async Task<SubscriptionEntity> CreateOrUpdateSubscription(SubscriptionEntity subscription)
    {
        try
        {
            var existingSubscription = await _repository.GetOneAsync(x => x.Email == subscription.Email);
            if (existingSubscription == null)
            {
                var result = await _repository.CreateAsync(subscription);
                if (result != null)
                {
                    return result;

                }
            }
            else
            {
                var result = await _repository.UpdateAsync(existingSubscription, subscription);
                if (result != null)
                {
                    return result;
                }
            }

            return null!;
        }
        catch (Exception ex) { Debug.WriteLine(ex); }
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

            return null!;
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

            return null!;
        }
        catch (Exception ex) { Debug.WriteLine(ex); }
        return null!;
    }

    public async Task<SubscriptionEntity> UpdateSubscriptionAsync(SubscriptionEntity subscription)
    {
        try
        {
            var existingSubscription = await _repository.GetOneAsync(x => x.Id == subscription.Id);
            if (existingSubscription != null)
            {
                var result = await _repository.UpdateAsync(existingSubscription, subscription);
                if (result != null)
                {
                    return result;
                }
            }

            return null!;
        }
        catch (Exception ex) { Debug.WriteLine(ex); }
        return null!;
    }

    public async Task<SubscriptionEntity> DeleteSubscriptionAsync(string Id)
    {
        try
        {
            var existingSubscription = await _repository.GetOneAsync(x => x.Id == Id);
            if (existingSubscription != null)
            {
                var result = await _repository.DeleteAsync(existingSubscription);
                if (result)
                {
                    return existingSubscription;
                }
            }

            return null!;
        }
        catch (Exception ex) { Debug.WriteLine(ex); }
        return null!;
    }



}
