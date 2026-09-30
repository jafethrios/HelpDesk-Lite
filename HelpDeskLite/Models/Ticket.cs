using System.ComponentModel.DataAnnotations;

namespace HelpDeskLite.Models;

public class Ticket
{
    public int Id { get; set; }

    [Required]
    [StringLength(120, MinimumLength = 5)]
    public string Title { get; set; } = string.Empty;

    [Required]
    [StringLength(2000, MinimumLength = 10)]
    public string Description { get; set; } = string.Empty;

    [Required]
    [Display(Name = "Requester name")]
    [StringLength(100)]
    public string RequesterName { get; set; } = string.Empty;

    [EmailAddress]
    [Display(Name = "Requester email")]
    [StringLength(150)]
    public string? RequesterEmail { get; set; }

    [Required]
    [StringLength(80)]
    public string Category { get; set; } = "General";

    public TicketPriority Priority { get; set; } = TicketPriority.Medium;

    public TicketStatus Status { get; set; } = TicketStatus.Open;

    [Display(Name = "Created at")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [Display(Name = "Updated at")]
    public DateTime? UpdatedAt { get; set; }

    [Display(Name = "Resolved at")]
    public DateTime? ResolvedAt { get; set; }

    [Timestamp]
    public byte[]? RowVersion { get; set; }
}
