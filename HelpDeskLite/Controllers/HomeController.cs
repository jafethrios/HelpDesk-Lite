using System.Diagnostics;
using HelpDeskLite.Data;
using HelpDeskLite.Models;
using HelpDeskLite.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HelpDeskLite.Controllers;

public class HomeController(ApplicationDbContext context) : Controller
{
    public async Task<IActionResult> Index()
    {
        var model = new DashboardViewModel
        {
            TotalTickets = await context.Tickets.CountAsync(),
            OpenTickets = await context.Tickets.CountAsync(ticket => ticket.Status == TicketStatus.Open),
            InProgressTickets = await context.Tickets.CountAsync(ticket => ticket.Status == TicketStatus.InProgress),
            ResolvedTickets = await context.Tickets.CountAsync(ticket => ticket.Status == TicketStatus.Resolved),
            CriticalTickets = await context.Tickets.CountAsync(ticket => ticket.Priority == TicketPriority.Critical),
            RecentTickets = await context.Tickets
                .AsNoTracking()
                .OrderByDescending(ticket => ticket.CreatedAt)
                .Take(5)
                .ToListAsync()
        };

        return View(model);
    }

    public IActionResult Privacy() => View();

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error() => View(new ErrorViewModel
    {
        RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
    });
}
