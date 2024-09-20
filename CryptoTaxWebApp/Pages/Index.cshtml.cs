using CryptoTaxWebApp.Models;
using CryptoTaxWebApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace CryptoTaxWebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly UsaSalesTaxService _usaSalesTaxService;
        private readonly ILogger<IndexModel> _logger; // Ensure only one declaration of _logger

        // Constructor initializing UsaSalesTaxService and _logger
        public IndexModel(UsaSalesTaxService usaSalesTaxService, ILogger<IndexModel> logger)
        {
            _usaSalesTaxService = usaSalesTaxService;
            _logger = logger; // Initialize _logger
        }

        // Bind property to capture user input from the form
        [BindProperty]
        public string? ZipCode { get; set; } // ZipCode can be nullable to avoid warning

        // Property to store tax data received from the API
        public UsaSalesTaxData? TaxData { get; set; }

        // Method to handle form post requests
        public async Task<IActionResult> OnPostAsync()
        {
            if (!string.IsNullOrEmpty(ZipCode))
            {
                // Fetch tax information based on zip code
                TaxData = await _usaSalesTaxService.GetSalesTaxDataAsync(ZipCode);
            }
            else
            {
                _logger.LogWarning("ZipCode was not provided.");
            }

            return Page(); // Return the current page with the results
        }
    }
}
