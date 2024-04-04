using Infrastructure.Entities;
using Infrastructure.Models;


namespace Infrastructure.Factories;

public static class SubscriptionFactory
{
    public static SubscriptionEntity Create(SubscriptionCreateModel model)
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

    public static SubscriptionEntity Create(SubscriptionReturnModel model)
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

    public static SubscriptionReturnModel Create(SubscriptionEntity entity)
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

    public static IEnumerable<SubscriptionReturnModel> Create(IEnumerable<SubscriptionEntity> entitites)
    {
        var models = new List<SubscriptionReturnModel>();
        
        foreach (var entity in entitites)
        {
            models.Add(Create(entity));
        }

        return models;
        
    }
}
