using NUnit.Framework;

namespace Unknown_World_of_Magic_server
{
    class TestManagingResponses
    {
        [Test]
        public void TestSetServerResponse()
        {
            ManagingResponses managingResponses = new ManagingResponses();

            managingResponses.SetServerResponse("StartCommand");

            Assert.AreEqual(ManagingResponses.serverResponse, "StartCommand");
        }
    }
}
