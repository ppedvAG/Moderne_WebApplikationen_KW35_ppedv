using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace gRPC.OData.Client
{
    internal class ODataBookstoreClient
    {
        private readonly string _baseUri;

        public ODataBookstoreClient(string baseUri)
        {
            _baseUri = baseUri;
        }

        public async Task ListShelves()
        {
            Console.WriteLine($"\nOData: List Shelves:");

            string requestUri = $"{_baseUri}/odata/shelves";
            using var client = new HttpClient();
            var response = await client.GetAsync(requestUri);

            Console.WriteLine("--Status code: " + response.StatusCode.ToString());
            string body = await response.Content.ReadAsStringAsync();
            Console.WriteLine("--Response body:");
            Console.WriteLine(BeautifyJson(body)); // find BeautifyJson from sample repository
            Console.WriteLine();
        }

        public async Task ListBooks(long shelfId)
        {
            Console.WriteLine($"\nOData: List books at shelf '{shelfId}':");

            string requestUri = $"{_baseUri}/odata/shelves/{shelfId}/books";
            using var client = new HttpClient();
            var response = await client.GetAsync(requestUri);

            Console.WriteLine("--Status code: " + response.StatusCode.ToString());
            string body = await response.Content.ReadAsStringAsync();
            Console.WriteLine("--Response body:");
            Console.WriteLine(BeautifyJson(body));
            Console.WriteLine();
        }

        static string BeautifyJson(string json)
        {
            using var jDoc = JsonDocument.Parse(json);
            return JsonSerializer.Serialize(jDoc, new JsonSerializerOptions { WriteIndented = true });
        }
    }
}
