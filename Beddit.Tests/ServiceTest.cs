using System;
using System.Configuration;
using Beddit.Net;
using Beddit.Net.RequestModel;
using FluentAssertions;
using NUnit.Framework;

namespace Beddit.Tests
{
    [TestFixture]
    public class ServiceTest
    {
        [Test]
        public void ValidLoginTest()
        {
            var service = new BedditService();
            var beddit = new BedditAuthorizationRequest(ConfigurationManager.AppSettings["username"], ConfigurationManager.AppSettings["password"]);
            var result = service.AuthorizeUser(beddit);
            result.Should().NotBeNull();
            result.AccessToken.Should().NotBeNullOrEmpty();
        }

        [Test]
        public void BadLoginTest()
        {
            var service = new BedditService();
            var beddit = new BedditAuthorizationRequest("beddit@example.com","password");
            Action action = () => service.AuthorizeUser(beddit);
            action.ShouldThrow<BedditException>()
                .And.Error.Should().Be("invalid_credentials");

        }

        [Test]
        public void GetTokenInfoTest()
        {
            var service = new BedditService();
            var beddit = new BedditAuthorizationRequest(ConfigurationManager.AppSettings["username"], ConfigurationManager.AppSettings["password"]);
            
            var auth = service.AuthorizeUser(beddit);

            var result = service.GetTokenInfo();
            result.Should().NotBeNull();
            result.TokenType.Should().Be("user");
            result.User.Should().Be(auth.User);
        }

        [Test]
        public void GetTokenInfoFailTest()
        {
            var service = new BedditService();
            
            Action act = ()=> service.GetTokenInfo();
            act.ShouldThrow<BedditException>()
                .And.Error.Should().Be("Not Authorized");

        }

        [Test]
        public void GetSleepDataDatesTest()
        {
            var service = new BedditService();
            var beddit = new BedditAuthorizationRequest(ConfigurationManager.AppSettings["username"], ConfigurationManager.AppSettings["password"]);

            var auth = service.AuthorizeUser(beddit);
            var request = new BedditSleepDataStartAndEndDateRequest(DateTime.Now.AddDays(-2), DateTime.Now);
            var response = service.GetSleepData(request);
            response.Should().NotBeNullOrEmpty();
        }

        [Test]
        public void GetSleepDataSinceTest()
        {
            var service = new BedditService();
            var beddit = new BedditAuthorizationRequest(ConfigurationManager.AppSettings["username"], ConfigurationManager.AppSettings["password"]);

            var auth = service.AuthorizeUser(beddit);
            TimeSpan t = (DateTime.UtcNow.AddDays(-2) - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc));
            double seconds = (double)t.TotalSeconds;
            var request = new BedditSleepDataUpdatedAfterRequest(seconds);
            var response = service.GetSleepData(request);
            response.Should().NotBeNullOrEmpty();
        }
    }
}
