using Homies.Models;

namespace Homies.Contracts
{
    public interface IEventService
    {
        Task AddEventAsync(EventAddViewModel viewModel);
        Task AddEventToJoinedAsync(string userId, EventAllViewModel joinedEvent);
        Task EditEventAsync(EventAddViewModel model, int id);
        Task<IEnumerable<EventAllViewModel>> GetAllEventsAsync();
        Task<EventAddViewModel?> GetEventByIdForEditAsync(int id);
        Task<EventAllViewModel?> GetEventByIdForViewingAsync(int id);
        Task<IEnumerable<EventAllViewModel>> GetMyJoinedEventsAsync(string userId);
        Task<EventAddViewModel> GetNewEventAddModelAsync();
        Task RemoveEventToJoinedAsync(string userId, EventAllViewModel joinedEvent);
    }
}
