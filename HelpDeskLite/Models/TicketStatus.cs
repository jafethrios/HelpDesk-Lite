using System.ComponentModel.DataAnnotations;

namespace HelpDeskLite.Models;

public enum TicketStatus
{
    [Display(Name = "Open")]
    Open = 1,

    [Display(Name = "In Progress")]
    InProgress = 2,

    [Display(Name = "Resolved")]
    Resolved = 3,

    [Display(Name = "Closed")]
    Closed = 4
}
