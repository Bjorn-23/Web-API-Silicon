using System.ComponentModel.DataAnnotations;

namespace Web_API_Silicon.Models;

public class SubscriptionReturnModel
{
    [Key]
    public string Id { get; set; } = null!;

    [Required]
    public string Email { get; set; } = null!;

    public bool DailyNewsletter { get; set; } = true;

    public bool AdvertisingUpdates { get; set; }
    public bool WeekInReview { get; set; }

    public bool EventUpdates { get; set; }

    public bool StartupsWeekly { get; set; }

    public bool Podcasts { get; set; }

}
