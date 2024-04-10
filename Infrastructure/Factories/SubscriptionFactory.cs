using Infrastructure.Entities;
using Infrastructure.Models;
using System.Diagnostics;


namespace Infrastructure.Factories;

public static class SubscriptionFactory
{
    public static SubscriptionEntity Create(SubscriptionCreateModel model)
    {
        try
        {
            return new SubscriptionEntity()
            {
                Email = model.Email,
                DailyNewsletter = model.DailyNewsletter,
                AdvertisingUpdates = model.AdvertisingUpdates,
                WeekInReview = model.WeekInReview,
                EventUpdates = model.EventUpdates,
                StartupsWeekly = model.StartupsWeekly,
                Podcasts = model.Podcasts,
            };
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;

    }

    public static SubscriptionEntity Create(SubscriptionReturnModel model)
    {
        try
        {
            return new SubscriptionEntity()
            {
                Id = model.Id,
                Email = model.Email,
                DailyNewsletter = model.DailyNewsletter,
                AdvertisingUpdates = model.AdvertisingUpdates,
                WeekInReview = model.WeekInReview,
                EventUpdates = model.EventUpdates,
                StartupsWeekly = model.StartupsWeekly,
                Podcasts = model.Podcasts,
            };
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!; 
    }

    public static SubscriptionReturnModel Create(SubscriptionEntity entity)
    {
        try
        {
            return new SubscriptionReturnModel()
            {
                Id = entity.Id,
                Email = entity.Email,
                DailyNewsletter = entity.DailyNewsletter,
                AdvertisingUpdates = entity.AdvertisingUpdates,
                WeekInReview = entity.WeekInReview,
                EventUpdates = entity.EventUpdates,
                StartupsWeekly = entity.StartupsWeekly,
                Podcasts = entity.Podcasts,
            };
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }

    public static IEnumerable<SubscriptionReturnModel> Create(IEnumerable<SubscriptionEntity> entitites)
    {
        try
        {
            var models = new List<SubscriptionReturnModel>();

            foreach (var entity in entitites)
            {
                models.Add(Create(entity));
            }

            return models;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }
}
