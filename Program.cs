using DemoElasticSearchApp.Models;
using Nest;

class Program
{
    static void Main(string[] args)
    {
        var settings = new ConnectionSettings(new Uri("http://localhost:9200"))
                            .DefaultIndex("first_index");
        var client = new ElasticClient(settings);

        var pingResponse = client.Ping();

        if (pingResponse.IsValid)
        {
            Console.WriteLine("ElasticSearch is up and running.");

            // search
            var searchResponse = client.Search<Product>(s => s
                     .Index("first_index")
                     .Query(q => q
                         .Match(m => m
                             .Field("title")
                             .Query("Монитор ASUS")
                         )
                     )
                 );

            if (searchResponse.IsValid)
            {
                foreach (var hit in searchResponse.Hits)
                {
                    var product = hit.Source;
                    Console.WriteLine($"Found product: {product.Title}, Price: {product.Price}, Available: {product.Available}");
                }
            }
            else
            {
                Console.WriteLine("Search failed.");
            }
        }
        else
        {
            Console.WriteLine("Failed to connect to ElasticSearch.");
        }
    }
}
