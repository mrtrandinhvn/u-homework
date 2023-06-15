using Application;
using AutoMapper;
using Infrastructure;
using Website;

namespace WebsiteTests
{
    public class AutoMapperConfigurationTest
    {
        [Fact]
        public void AutoMapperConfiguration_Should_Be_Valid()
        {
            var configuration = new MapperConfiguration(config =>
            {
                config.AddProfile<WebsiteMappingProfile>();
                config.AddProfile<InfrastructureMappingProfile>();
                config.AddProfile<ApplicationMappingProfile>();
            });

            configuration.AssertConfigurationIsValid();
        }
    }
}