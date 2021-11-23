using Microsoft.Extensions.Hosting;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.Extensions.DependencyInjection;

namespace Test
{
    public class Program
    {
        static void Main(string[] args)
        {
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddMediatR(typeof(Program));
                    services.AddTransient<INotificationHandler<MyEvent>, GenericEventHandler<MyEvent, MyCommand>>();
                })
                .Build()
                .Run();
        }
    }

    public class MyCommand { }

    public class MyEvent : INotification { }

    public class GenericEventHandler<TEvent, TCommand> : INotificationHandler<TEvent>
        where TEvent : INotification
    {
        public Task Handle(TEvent notification, CancellationToken cancellationToken)
            => Task.CompletedTask;
    }
}
