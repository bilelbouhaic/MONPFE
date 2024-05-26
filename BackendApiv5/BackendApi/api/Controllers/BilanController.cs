using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;
using api.Data;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BilanController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public BilanController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet("GenerateBilanPDF")]
        public IActionResult GenerateBilanPDF()
        {
            var document = new Document(PageSize.A4);
            document.SetMargins(25f, 25f, 30f, 30f);

            using (var memoryStream = new MemoryStream())
            {
                var writer = PdfWriter.GetInstance(document, memoryStream);
                document.Open();

                var titleFont = FontFactory.GetFont("Arial", 18, Font.BOLD);
                document.Add(new Paragraph("Declarations Redevance du mois de Janvier 2024 ", titleFont));
                document.Add(new Paragraph("Redevance ", titleFont));
                document.Add(new Paragraph("Perimetre Sonatrach seule ", titleFont));
                document.Add(new Paragraph($"Generated on: {DateTime.Now}", FontFactory.GetFont("Arial", 12, Font.NORMAL)));

                document.Add(new Paragraph("\n")); // Space after the title

                // Get all declarations and group them by Perimetre name
                var groupedDeclarations = _context.declarationRedevances
                    .Include(d => d.perimetre) // Ensure Perimetre data is included
                    .GroupBy(d => d.perimetre.nomPerimetre) // Group by Perimetre name
                    .ToList();

                // Create the table with the number of dynamic columns for declarations by date
                var uniqueDates = groupedDeclarations
                    .SelectMany(g => g.Select(d => d.dateRdv))
                    .Distinct()
                    .OrderBy(d => d) // Ensures the order by date
                    .ToList();

                // Create a table with a dynamic number of columns (Perimetre name + dates)
                var table = new PdfPTable(1 + uniqueDates.Count);
                table.AddCell("Perimetre"); // First column for Perimetre name

                // Add headers for each date in uniqueDates
                foreach (var date in uniqueDates)
                {
                    table.AddCell($"Declaration on {date}"); // Columns for each declaration date
                }

                // Add data to the table
                foreach (var group in groupedDeclarations)
                {
                    table.AddCell(group.Key); // The Perimetre name

                    // For each date, find the matching declaration and add its MontantRdv
                    foreach (var date in uniqueDates)
                    {
                        var declaration = group.FirstOrDefault(d => d.dateRdv == date);
                        if (declaration != null)
                        {
                            table.AddCell(declaration.montantRdv.ToString()); // MontantRdv for this declaration
                        }
                        else
                        {
                            table.AddCell("N/A"); // No declaration found for this date
                        }
                    }
                }

                document.Add(table); // Add the table to the document

                document.Close(); // Finalize the document

                // Convert the document to a byte array
                var pdfBytes = memoryStream.ToArray();

                // Return the PDF as a downloadable file
                return File(pdfBytes, "application/pdf", "bilan_declarations.pdf");
            }
        }
    }
}
