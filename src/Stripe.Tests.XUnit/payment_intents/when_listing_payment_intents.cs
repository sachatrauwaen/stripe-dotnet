﻿using FluentAssertions;
using Stripe.Tests.Xunit;
using System.Collections.Generic;
using System;
using System.Linq;
using Xunit;

namespace Stripe.Tests.XUnit
{
    public class when_listing_payment_intents : IClassFixture<payment_intents_fixture>
    {
        private readonly payment_intents_fixture fixture;
        private StripeList<StripePaymentIntent> result;

        public when_listing_payment_intents(payment_intents_fixture fixture)
        {
            this.fixture = fixture;
            result = fixture.PaymentIntentList;
        }

        [Fact]
        public void list_is_iterable()
        {
            var count = 0;
            IEnumerable<StripePaymentIntent> enumerable = result as IEnumerable<StripePaymentIntent>;
            foreach (var obj in enumerable)
            {
                count += 1;
            }
            Assert.Equal(result.ToList().Count > 0, true);
            Assert.Equal(result.ToList().Count, count);

        }

        [Fact]
        public void list_contents_equal()
        {

            var datahash = new HashSet<String>();
            foreach (var obj in result.Data)
            {
                datahash.Add(obj.Id);
            }

            var enumhash = new HashSet<String>();
            IEnumerable<StripePaymentIntent> enumerable = result as IEnumerable<StripePaymentIntent>;
            foreach (var obj in enumerable)
            {
                enumhash.Add(obj.Id);
            }

            Assert.Equal(datahash, enumhash);

        }

        [Fact]
        public void list_contains_extra_attributes()
        {
            Assert.NotNull(result.Object);
            Assert.Equal(result.Object, "list");
            Assert.NotNull(result.Data);
            Assert.NotNull(result.Url);
        }

    }
}
