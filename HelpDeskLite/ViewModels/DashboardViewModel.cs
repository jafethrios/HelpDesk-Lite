using HelpDeskLite.Models;

namespace HelpDeskLite.ViewModels;

public class DashboardViewModel
{
    public int TotalTickets { get; init; }
    public int OpenTickets { get; init; }
    public int InProgressTickets { get; init; }
    public int ResolvedTickets { get; init; }
    public int CriticalTickets { get; init; }
    public IReadOnlyList<Ticket> RecentTickets { get; init; } = [];
}
