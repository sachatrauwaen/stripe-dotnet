namespace StripeTests
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Stripe;
    using Xunit;

    public class StripeScheduledQueryServiceTest : BaseStripeTest
    {
        private const string ScheduledQueryId = "sqr_123";

        private StripeScheduledQueryService service;
        private StripeScheduledQueryListOptions listOptions;

        public StripeScheduledQueryServiceTest()
        {
            this.service = new StripeScheduledQueryService();

            this.listOptions = new StripeScheduledQueryListOptions()
            {
                Limit = 1,
            };
        }

        [Fact]
        public void Get()
        {
            var run = this.service.Get(ScheduledQueryId);
            Assert.NotNull(run);
            Assert.Equal("scheduled_query_run", run.Object);
        }

        [Fact]
        public async Task GetAsync()
        {
            var run = await this.service.GetAsync(ScheduledQueryId);
            Assert.NotNull(run);
            Assert.Equal("scheduled_query_run", run.Object);
        }

        [Fact]
        public void List()
        {
            var runs = this.service.List(this.listOptions);
            Assert.NotNull(runs);
            Assert.Equal("list", runs.Object);
            Assert.Single(runs.Data);
            Assert.Equal("scheduled_query_run", runs.Data[0].Object);
        }

        [Fact]
        public async Task ListAsync()
        {
            var runs = await this.service.ListAsync(this.listOptions);
            Assert.NotNull(runs);
            Assert.Equal("list", runs.Object);
            Assert.Single(runs.Data);
            Assert.Equal("scheduled_query_run", runs.Data[0].Object);
        }
    }
}
