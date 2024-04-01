using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Entities;

public class SubscriptionEntity
{
    [Key]
    public string Id {  get; set; } = Guid.NewGuid().ToString();

    [Required]
    public string Email { get; set; } = null!;

    public bool DailyNewsletter { get; set; } = true;

    public bool AdvertisingUpdates { get; set; }

    public bool WeekInReview { get; set; }

    public bool EventUpdates { get; set; }

    public bool StartupsWeekly { get; set; }

    public bool Podcasts { get; set; }

}