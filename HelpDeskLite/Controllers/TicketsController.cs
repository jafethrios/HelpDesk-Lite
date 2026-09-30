using HelpDeskLite.Data;
using HelpDeskLite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HelpDeskLite.Controllers;

public class TicketsController(ApplicationDbContext context) : Controller
{
    public async Task<IActionResult> Index(
        string? search,
        TicketStatus? status,
        TicketPriority? priority)
    {
        var query = context.Tickets.AsNoTracking().AsQueryable();

        if (!string.IsNullOrWhiteSpace(search))
        {
            var normalizedSearch = search.Trim();
            query = query.Where(ticket =>
                ticket.Title.Contains(normalizedSearch) ||
                ticket.RequesterName.Contains(normalizedSearch) ||
                ticket.Category.Contains(normalizedSearch));
        }

        if (status.HasValue)
        {
            query = query.Where(ticket => ticket.Status == status.Value);
        }

        if (priority.HasValue)
        {
            query = query.Where(ticket => ticket.Priority == priority.Value);
        }

        ViewBag.Search = search;
        ViewBag.Status = status;
        ViewBag.Priority = priority;

        var tickets = await query
            .OrderByDescending(ticket => ticket.CreatedAt)
            .ToListAsync();

        return View(tickets);
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id is null) return NotFound();

        var ticket = await context.Tickets
            .AsNoTracking()
            .FirstOrDefaultAsync(item => item.Id == id);

        return ticket is null ? NotFound() : View(ticket);
    }

    public IActionResult Create() => View(new Ticket());

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Ticket ticket)
    {
        if (!ModelState.IsValid) return View(ticket);

        ticket.CreatedAt = DateTime.UtcNow;
        ticket.UpdatedAt = null;
        ticket.ResolvedAt = ticket.Status == TicketStatus.Resolved ? DateTime.UtcNow : null;

        context.Add(ticket);
        await context.SaveChangesAsync();
        TempData["SuccessMessage"] = $"Ticket #{ticket.Id} was created successfully.";

        return RedirectToAction(nameof(Details), new { id = ticket.Id });
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id is null) return NotFound();

        var ticket = await context.Tickets.FindAsync(id);
        return ticket is null ? NotFound() : View(ticket);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Ticket input)
    {
        if (id != input.Id) return NotFound();

        var ticket = await context.Tickets.FirstOrDefaultAsync(item => item.Id == id);
        if (ticket is null) return NotFound();

        if (!ModelState.IsValid)
        {
            input.CreatedAt = ticket.CreatedAt;
            return View(input);
        }

        if (input.RowVersion is not null)
        {
            context.Entry(ticket)
                .Property(item => item.RowVersion)
                .OriginalValue = input.RowVersion;
        }

        ticket.Title = input.Title;
        ticket.Description = input.Description;
        ticket.RequesterName = input.RequesterName;
        ticket.RequesterEmail = input.RequesterEmail;
        ticket.Category = input.Category;
        ticket.Priority = input.Priority;

        var previousStatus = ticket.Status;
        ticket.Status = input.Status;
        ticket.UpdatedAt = DateTime.UtcNow;

        if (ticket.Status == TicketStatus.Resolved && previousStatus != TicketStatus.Resolved)
        {
            ticket.ResolvedAt = DateTime.UtcNow;
        }
        else if (ticket.Status != TicketStatus.Resolved)
        {
            ticket.ResolvedAt = null;
        }

        try
        {
            await context.SaveChangesAsync();
            TempData["SuccessMessage"] = $"Ticket #{ticket.Id} was updated successfully.";
        }
        catch (DbUpdateConcurrencyException)
        {
            ModelState.AddModelError(string.Empty,
                "This ticket was modified by another process. Reload the page and try again.");
            return View(input);
        }

        return RedirectToAction(nameof(Details), new { id = ticket.Id });
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id is null) return NotFound();

        var ticket = await context.Tickets
            .AsNoTracking()
            .FirstOrDefaultAsync(item => item.Id == id);

        return ticket is null ? NotFound() : View(ticket);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var ticket = await context.Tickets.FindAsync(id);
        if (ticket is null) return RedirectToAction(nameof(Index));

        context.Tickets.Remove(ticket);
        await context.SaveChangesAsync();
        TempData["SuccessMessage"] = $"Ticket #{id} was deleted.";

        return RedirectToAction(nameof(Index));
    }
}
