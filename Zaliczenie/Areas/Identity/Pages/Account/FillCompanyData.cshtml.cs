using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Zaliczenie.Data;
using Zaliczenie.Data.Entities;

namespace Zaliczenie.Areas.Identity.Pages.Account;

public class FillCompanyData : PageModel
{
    private readonly UserManager<User> _userManager;
    private readonly ApplicationDbContext _context;

    public FillCompanyData(UserManager<User> userManager, ApplicationDbContext context)
    {
        _userManager = userManager;
        _context = context;
    }

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        var existingCompany = await _context.Companies.FirstOrDefaultAsync(e => e.CompanyName == Input.CompanyName);
        if (existingCompany is not null)
        {
            ModelState.AddModelError(string.Empty, "Company already exists");
            return Page();
        }

        var user = await _userManager.GetUserAsync(User);
        if (user is null) return RedirectToPage("./Login");

        _context.Add(new Company()
        {
            CompanyName = Input.CompanyName,
            CreatorId = user.Id,
        });
        await _context.SaveChangesAsync();
        var company = await _context.Companies.FirstAsync(e => e.CompanyName == Input.CompanyName);
        user.CompanyId = company.CompanyId;
        await _context.SaveChangesAsync();

        return Redirect("/");
    }

    [BindProperty] public InputData Input { get; set; }

    public class InputData
    {
        [Required]
        [MinLength(3)]
        [Display(Name = "Company name")]
        public string CompanyName { get; set; }
    }
}