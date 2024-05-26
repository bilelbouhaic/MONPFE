using Microsoft.AspNetCore.Mvc;
using Microsoft.AnalysisServices.AdomdClient;
using System;
using System.Collections.Generic;

namespace YourApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WilayaDataController : ControllerBase
    {
        [HttpGet("{wilayaId}")]
        public IActionResult GetWilayaData(int wilayaId)
        {
            // Connexion à la base de données OLAP
            string connectionString = "Data Source=DESKTOP-5C3N6FQ\\SQLDEVANALYSIS;Catalog=ProjetMultidimensionnel2;Integrated Security=SSPI;";
            using (AdomdConnection conn = new AdomdConnection(connectionString))
            {
                conn.Open();

                // Exécution de la requête MDX
                string mdxQuery = $@"
                    WITH 
                    MEMBER [Measures].[AverageQuantiteProduiteMoisParWilaya] AS 
                        AVG(
                            [D Perimetre].[Wilaya].&[{wilayaId}], 
                            [Measures].[Quantite Produite Mois]
                        )
                    SELECT 
                    NON EMPTY {{
                        [D Date].[Id Date].[Id Date].Members
                    }} ON COLUMNS
                    FROM 
                        [ED1]";

                using (AdomdCommand cmd = new AdomdCommand(mdxQuery, conn))
                {
                    using (AdomdDataReader reader = cmd.ExecuteReader())
                    {
                        // Récupération des résultats et formatage en tableau de double
                        var wilayaData = new List<double>();
                        while (reader.Read())
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                double quantity = Convert.ToDouble(reader[i]);
                                wilayaData.Add(quantity);
                            }
                        }

                        // Retour des données formatées sous forme de réponse HTTP GET
                        return Ok(wilayaData);
                    }
                }
            }
        }
    }
}
