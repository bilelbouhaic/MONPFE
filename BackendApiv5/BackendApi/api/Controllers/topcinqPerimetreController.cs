using Microsoft.AspNetCore.Mvc;
using Microsoft.AnalysisServices.AdomdClient;
using System.Collections.Generic;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class topcinqPerimetreController : ControllerBase
    {
        // Define a class to represent the data structure
        public class CubeDataRow
        {
            
            public double Krechba { get; set; }
            public double Teguentour { get; set; }
            public double Gourmahmoud { get; set; }
            public double Insalah { get; set; }
             public double Tiguentourine{ get; set; }
        }

        // Endpoint GET pour récupérer des données à partir d'une requête MDX sans mesures
       // Endpoint GET pour récupérer des données à partir d'une requête MDX sans mesures
// Endpoint GET pour récupérer des données à partir d'une requête MDX sans mesures
[HttpGet("{date}")]
public IActionResult GetCubeData(string date)
{
    // Chaîne de connexion au cube SSAS
    string connectionString = "Data Source=DESKTOP-5C3N6FQ\\SQLDEVANALYSIS;Catalog=ProjetMultidimensionnel2;Integrated Security=SSPI;";

    // Requête MDX pour récupérer les membres des dimensions sans inclure de mesures
    string mdxQuery = @"
     SELECT 
  TOPCOUNT(
    [D Perimetre].[Perimetre].Members, 
    5, 
    [Measures].[Quantite Produite Mois]
  ) ON COLUMNS
FROM 
  [ED1]
WHERE 
  (
    [D Date].[Id Date].[2024-04-16]  -- Votre date spécifiée
  )


    ";

    CubeDataRow cubeData = null;

    using (AdomdConnection conn = new AdomdConnection(connectionString))
    {
        conn.Open();
        using (AdomdCommand cmd = new AdomdCommand(mdxQuery, conn))
        {
            using (AdomdDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    // Création d'un nouvel objet CubeDataRow
                    cubeData = new CubeDataRow
                    {
                            
                                    Krechba = reader.GetDouble(1),
                                     Teguentour = reader.GetDouble(2),
                                      Gourmahmoud = reader.GetDouble(3),
                                       Insalah = reader.GetDouble(4), // Le deuxième champ est la moyenne de Quantite Produite Mois
                               Tiguentourine = reader.GetDouble(4),
                    };
                }
            }
        }
        conn.Close();
    }

    // Si aucune donnée n'a été trouvée pour la date donnée, retourner NotFound
    if (cubeData == null)
    {
        return NotFound();
    }

    // Retourne les données sous forme de réponse HTTP OK avec les résultats pour la date spécifiée
    return Ok(cubeData);
}

    }
}
