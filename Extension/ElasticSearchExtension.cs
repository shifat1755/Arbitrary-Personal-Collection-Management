using Elasticsearch.Net;
using Nest;

namespace APCM.Extension
{
    public static class ElasticSearchExtension
    {
        public static void AddElasticSearch(this IServiceCollection services, IConfiguration configuration)
        {
            var baseUrl = configuration["ElasticSettings:baseUrl"];
            var index = configuration["ElasticSettings:defaultIndex"];
            var settings = new ConnectionSettings(new Uri(baseUrl ?? ""))
                .PrettyJson()
                .CertificateFingerprint("31b95e4b3e20f77c1bdc1840e256fedd909cc32f9f8f4a745ac81608f07f9393")
                .BasicAuthentication("elastic", "1yb+aTZ+p4MBWcUoM11N")
                .DefaultIndex(index)
                .ServerCertificateValidationCallback(CertificateValidations.AllowAll);
            settings.EnableApiVersioningHeader();
            AddDefaultMappings(settings);
            var client = new ElasticClient(settings);
            services.AddSingleton<IElasticClient>(client);
            CreateIndex(client, index);
        }
        private static void AddDefaultMappings(ConnectionSettings settings)
        {
            settings.DefaultMappingFor<Models.Collection.DCollectionModel>(m => m.Ignore(p => p.Items));
        }
        private static void CreateIndex(IElasticClient client, string indexName)
        {
            var createIndexResponse = client.Indices.Create(indexName, index => index.Map<Models.Collection.DCollectionModel>(x => x.AutoMap()));
            if (!createIndexResponse.IsValid)
            {
                Console.WriteLine($"Index creation failed: {createIndexResponse.ServerError?.Error?.Reason}");
            }
        }
    }
}
