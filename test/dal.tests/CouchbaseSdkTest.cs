using Xunit;
using Couchbase;
using Couchbase.Configuration.Client;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Collections.Generic;
using System;
using Microsoft.Extensions.Logging;

namespace Dal.Tests
{
    public class CouchbaseSdkTest : IClassFixture<LoggerFixture<CouchbaseSdkTest>>
    {
        private readonly ILogger log;
        public CouchbaseSdkTest(LoggerFixture<CouchbaseSdkTest> fixture)
        {
            log = fixture.Logger;
        }

        //private static readonly Cluster cluster = new Cluster("127.0.0.1");
        [Fact]
        public void StoreTest()
        {
            log.LogInformation("Store test is running", "get ready");

            // var builder = new ConfigurationBuilder()
            //     .SetBasePath(Directory.GetCurrentDirectory())
            //     .AddJsonFile("appsettings.json");
            // var clientConfiguration = new ClientConfiguration();
            // clientConfiguration.Servers = new List<Uri>() { new Uri("http://localhost:8091/pools") };
            // clientConfiguration.UseSsl = false;
            // Cluster cluster = new Cluster(clientConfiguration);
            //db.Email="duongphuhiep@gmail.com";
        }
    }
}
