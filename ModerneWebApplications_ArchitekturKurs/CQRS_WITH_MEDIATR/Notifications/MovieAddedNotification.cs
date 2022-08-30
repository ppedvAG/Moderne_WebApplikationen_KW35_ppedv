using CQRS_WITH_MEDIATR.Data.Entities;
using MediatR;

namespace CQRS_WITH_MEDIATR.Notifications
{
    public record MovieAddedNotification(Movie Movie) : INotification;
}
