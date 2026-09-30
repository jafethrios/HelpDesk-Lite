using System.ComponentModel.DataAnnotations;

namespace HelpDeskLite.Models;

public enum TicketPriority
{
    [Display(Name = "Low")]
    Low = 1,

    [Display(Name = "Medium")]
    Medium = 2,

    [Display(Name = "High")]
    High = 3,

    [Display(Name = "Critical")]
    Critical = 4
}
