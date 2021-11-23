using Microsoft.Extensions.DependencyInjection;
using System;
using Xunit;
using MediatR;

namespace Test.Tests
{    
    public class UnitTest1
    {        
        [Fact]
        public void Should_find_generic_handler()
        {
            var provider = GetServiceProvider();

            var handler = provider.GetService<INotificationHandler<MyEvent>>();

            Assert.NotNull(handler);
            Assert.IsType<GenericEventHandler<MyEvent, MyCommand>>(handler);
        }

        private IServiceProvider GetServiceProvider()
        {
            return new ServiceCollection()
                .AddMediatR(typeof(Program))
                .AddTransient<INotificationHandler<MyEvent>, GenericEventHandler<MyEvent, MyCommand>>()
                .BuildServiceProvider();
        }
    }
}
