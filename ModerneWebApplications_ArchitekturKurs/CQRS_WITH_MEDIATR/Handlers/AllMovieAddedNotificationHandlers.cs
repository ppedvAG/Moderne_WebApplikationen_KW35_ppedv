using CQRS_WITH_MEDIATR.Data;
using CQRS_WITH_MEDIATR.Notifications;
using MediatR;

namespace CQRS_WITH_MEDIATR.Handlers
{
    public class EmailHandler : INotificationHandler<MovieAddedNotification>
    {
        private readonly FakeDataStore _fakeDataStore;

        public EmailHandler(FakeDataStore fakeDataStore, IMediator mediator)
        {
            _fakeDataStore = fakeDataStore;
        } 


        public async Task Handle(MovieAddedNotification notification, CancellationToken cancellationToken)
        {
            //simulierter Workflow
            await _fakeDataStore.EventOccured(notification.Movie, "Email sent");
         
            await Task.CompletedTask;
        }
    }

    public class CacheInvalidationHandler : INotificationHandler<MovieAddedNotification>
    {
        private readonly FakeDataStore _fakeDataStore;

        public CacheInvalidationHandler(FakeDataStore fakeDataStore) => _fakeDataStore = fakeDataStore;

        public async Task Handle(MovieAddedNotification notification, CancellationToken cancellationToken)
        {
            await _fakeDataStore.EventOccured(notification.Movie, "Cache Invalidated");
            await Task.CompletedTask;
        }
    }
}
