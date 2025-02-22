using BusinessEntities;
using Common;
using Raven.Client.Documents;
using Raven.Client.Documents.Conventions;
using Raven.Client.Documents.Indexes;
using Raven.Client.Json.Serialization.NewtonsoftJson;
using SimpleInjector;
using Sparrow;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using static Raven.Client.Constants.Platform;

namespace Data
{
    public class DataConfiguration
    {
        public static void Initialize(Container container, Lifestyle lifestyle, bool createIndexes = true)
        {
            var assembly = typeof(DataConfiguration).Assembly;

            container.RegisterSingleton<IListTypeLookup<Assembly>, ListTypeLookup<Assembly>>();

            InitializeAssemblyInstancesService.RegisterAssemblyWithSerializableTypes(container, typeof(User).Assembly);
            InitializeAssemblyInstancesService.RegisterAssemblyWithSerializableTypes(container, assembly);

            InitializeAssemblyInstancesService.Initialize(container, lifestyle, assembly);
            container.RegisterSingleton(() => InitializeDocumentStore(assembly, createIndexes));

            container.Register(() =>
                               {
                                   var session = container.GetInstance<IDocumentStore>().OpenSession();
                                   session.Advanced.MaxNumberOfRequestsPerSession = 5000;
                                   return session;
                               }, lifestyle);
        }

        //private static IDocumentStore InitializeDocumentStore(Assembly assembly, bool createIndexes)
        //{
        //    var documentStore = new DocumentStore
        //                        {
        //                            Url = "https://a.devmanju.ravendb.community/",
        //                            DefaultDatabase = "SampleProject",
        //                            Conventions =
        //                            {
        //                                DefaultUseOptimisticConcurrency = true,
        //                                DocumentKeyGenerator = (dbname, commands, entity) => "",
        //                                SaveEnumsAsIntegers = true,
        //                                CustomizeJsonSerializer = serializer =>
        //                                                          {
        //                                                              serializer.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
        //                                                              serializer.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
        //                                                              serializer.DefaultValueHandling = DefaultValueHandling.Ignore;
        //                                                              serializer.DateFormatHandling = DateFormatHandling.IsoDateFormat;
        //                                                              serializer.NullValueHandling = NullValueHandling.Include;
        //                                                          },
        //                            }
        //                        };

        //    documentStore.Initialize();

        //    if (createIndexes)
        //    {
        //        IndexCreation.CreateIndexes(assembly, documentStore);
        //    }

        //    return documentStore;
        //}

        private static IDocumentStore InitializeDocumentStore(Assembly assembly, bool createIndexes)
        {
           // var certPath = "D:/Certificates/admin.client.certificate.ClientCertificatewith_Pass01/ClientCertificatewith_Pass01.pfx";
        //D:\\RavenDB - 7.0.0 - windows - x64\\Server\\cluster.server.certificate.devmanju.pfx

                var certPath = "D:/RavenDB-7.0.0-windows-x64/Server/cluster.server.certificate.devmanju.pfx";

            //var certificate = new X509Certificate2(certPath,"123456789");

            //var certPath = "D:/Certificates/admin.client.certificate.ClientCertificatewith_Pass01/ClientCertificatewith_Pass01.pfx";
            //var password = "123456789";
            //var certificate = new X509Certificate2(certPath, password,
            //    X509KeyStorageFlags.MachineKeySet | X509KeyStorageFlags.PersistKeySet | X509KeyStorageFlags.Exportable);

            var certificate = new X509Certificate2(certPath);


            var documentStore = new DocumentStore
            {
                Urls = new[] { " https://a.devmanju.ravendb.community/" },
                Database = "Sample",
                Certificate = certificate,
                Conventions = new DocumentConventions
                {
                    UseOptimisticConcurrency = true,
                    IdentityPartsSeparator = '-',
                    SaveEnumsAsIntegers = true,
                    //SerializeEntityIdsAsStrings = true,
                    FindCollectionName = type => type.Name // Adjust collection name strategy
                   // JsonContractResolver = new DefaultRavenContractResolver(),
                
                }
            };

            documentStore.Initialize();

            if (createIndexes)
            {
                // Auto-register indexes
                IndexCreation.CreateIndexes(assembly, documentStore);
            }

            return documentStore;
        }
    }
}