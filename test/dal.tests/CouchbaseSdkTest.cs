using Xunit;
using Couchbase;
using Couchbase.Configuration.Client;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Collections.Generic;
using System;
using Microsoft.Extensions.Logging;
using Dal.Models;

namespace Dal.Tests
{
    public class CouchbaseSdkTest : IClassFixture<LoggerFixture<CouchbaseSdkTest>>
    {
        private readonly ILogger log;
        public CouchbaseSdkTest(LoggerFixture<CouchbaseSdkTest> fixture)
        {
            log = fixture.Logger;
        }

        //[Fact]
        public void StoreTest()
        {
            using (Cluster cluster = new Cluster())
            {
                var msg = Message.New();
                msg.Content = "Hello World";

                try
                {
                    using (var bucket = cluster.OpenBucket("chatasp"))
                    {
                        var r = bucket.Insert<Message>(msg.Id.ToString(), msg);
                        if (r.Success)
                        {
                            log.LogInformation("Insert Success!!!");
                        }
                    }
                }
                catch (Exception ex) {
                    log.LogError(ex.ToString());
                }
            }
        }
    }
}
