using Microsoft.AspNetCore.Mvc;
using Microsoft.AnalysisServices.AdomdClient;
using System.Data;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using api.Models;
using api.Data;
using api.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace api.Controllers
{
    [Authorize(AuthenticationSchemes =JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    [Route("api/[controller]")]
    public class WilayaDateController : ControllerBase
    {
    string connectionString = "Data Source=DESKTOP-5C3N6FQ\\SQLDEVANALYSIS;Catalog=ProjetMultidimensionnel2;Integrated Security=SSPI;";

        [HttpGet]
        public IActionResult GetMdxResults()
        {
            string mdxQuery = @"
            SELECT 
            {
                (EXCEPT([D Perimetre].[Wilaya].Members, {[D Perimetre].[Wilaya].[All]}, ALL),
                 EXCEPT([D Date].[Id Date].Members, {[D Date].[Id Date].[All]}, ALL))
            } ON COLUMNS,
            {
                [Measures].[Quantite Produite Mois]
            } ON ROWS
            FROM [ED1]";

            DataTable dataTable = new DataTable();

            using (AdomdConnection connection = new AdomdConnection(connectionString))
            {
                connection.Open();
                using (AdomdCommand command = new AdomdCommand(mdxQuery, connection))
                {
                    using (AdomdDataAdapter adapter = new AdomdDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }

            var results = DataTableToDictionary(dataTable);
            return Ok(results);
        }

        private List<Dictionary<string, object>> DataTableToDictionary(DataTable table)
        {
            var result = new List<Dictionary<string, object>>();

            foreach (DataRow row in table.Rows)
            {
                var rowDict = new Dictionary<string, object>();
                foreach (DataColumn column in table.Columns)
                {
                    rowDict[column.ColumnName] = row[column];
                }
                result.Add(rowDict);
            }

            return result;
        }
    }
}
