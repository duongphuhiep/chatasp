using Xunit;

namespace Dal.Tests
{
    public class NamesDbTests
    {
        [Fact]
        public void StoreTest() 
        {
            var db = new NamesDb();
            Assert.Equal(1, db.GetAll().Length);
        }
    }
}
