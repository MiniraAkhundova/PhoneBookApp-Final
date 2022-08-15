using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PhoneBookApp.Data;

namespace PhoneBookApp.Pages;

public class StatusCheckModel : PageModel
{
    private readonly PhoneBookContext context;
    public bool CanConnectToDb = false;

    public StatusCheckModel(PhoneBookContext context)
    {
        this.context = context;
    }

    public async Task OnGet()
    {
        CanConnectToDb = await context.Database.CanConnectAsync();
    }
}
