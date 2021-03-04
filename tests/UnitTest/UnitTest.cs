using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Net;
using System.Threading.Tasks;
using TesteCleverti;
using Xunit;


namespace UnitTest
{
    public class UnitTest : IDisposable
    {
        protected TestServer _testServer;

        public UnitTest()
        {
            var webBuilder = new WebHostBuilder();
            webBuilder.UseStartup<Startup>();

            _testServer = new TestServer(webBuilder);
        }

        public void Dispose()
        {
            _testServer.Dispose();
        }

        [Fact]
        public async Task TestListAllTodo()
        {
            var response = await _testServer.CreateRequest("​/api/v1/todo/list-all-todo").SendAsync("GET");
            
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);

        }

        [Fact]
        public async Task TestGetTodoId()
        {
            var response = await _testServer.CreateRequest("​/api/v1/todo/get-todo-id/603fef5cd362edb4a42f5020").SendAsync("GET");

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);

        }

        [Fact]
        public async Task TestDeleteTodo()
        {
            var response = await _testServer.CreateRequest("​/api/v1/todo/get-todo/603fef5cd362edb4a42f5020").SendAsync("GET");

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);

        }

    }

}
