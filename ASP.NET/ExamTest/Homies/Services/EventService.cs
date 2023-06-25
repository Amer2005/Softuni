using Homies.Contracts;
using Homies.Data;
using Homies.Data.Models;
using Homies.Models;
using Microsoft.EntityFrameworkCore;

namespace Homies.Services
{
    public class EventService : IEventService
    {
        private readonly HomiesDbContext dbContext;

        public EventService(HomiesDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<EventAllViewModel>> GetAllEventsAsync()
        {
            return await dbContext
                .Events
                .Select(e => new EventAllViewModel
                {
                    Name = e.Name,
                    Start = e.Start,
                    Organiser = e.Organiser.UserName,
                    Type = e.Type.Name,
                    Id = e.Id
                })
                .ToListAsync();
        }

        public async Task AddEventAsync(EventAddViewModel viewModel)
        {
            Event newEvent = new Event
            {
                Name = viewModel.Name,
                Description = viewModel.Description,
                CreatedOn = DateTime.UtcNow,
                Start = viewModel.Start,
                End = viewModel.End,
                TypeId = viewModel.TypeId,
                OrganiserId = viewModel.OrganiserId
            };

            await dbContext.Events.AddAsync(newEvent);
            await dbContext.SaveChangesAsync();
        }

        public async Task<EventAddViewModel> GetNewEventAddModelAsync()
        {
            var types = await dbContext.Types
                .Select(c => new TypeViewModel
                {
                    Id = c.Id,
                    Name = c.Name
                }).ToListAsync();



            var model = new EventAddViewModel
            {
                Types = types
            };

            return model;
        }

        public async Task<EventAddViewModel?> GetEventByIdForEditAsync(int id)
        {
            var types = await dbContext.Types
                .Select(c => new TypeViewModel
                {
                    Id = c.Id,
                    Name = c.Name
                }).ToListAsync();

            return await dbContext.Events
                .Where(b => b.Id == id)
                .Select(b => new EventAddViewModel
                {
                    Name = b.Name,
                    Description = b.Description,
                    Start = b.Start,
                    End = b.End,
                    TypeId = b.TypeId,
                    OrganiserId = b.OrganiserId,
                    Types = types
                }).FirstOrDefaultAsync();
        }

        public async Task<EventAllViewModel?> GetEventByIdForViewingAsync(int id)
        {
            return await dbContext.Events
                .Where(b => b.Id == id)
                .Select(b => new EventAllViewModel
                {
                    Name = b.Name,
                    Start = b.Start,
                    Id = b.Id
                }).FirstOrDefaultAsync();
        }

        public async Task EditEventAsync(EventAddViewModel model, int id)
        {
            var editeEvent = await dbContext.Events.FindAsync(id);

            if (editeEvent != null)
            {
                editeEvent.Name = model.Name;
                editeEvent.Description = model.Description;
                editeEvent.Start = model.Start;
                editeEvent.End = model.End;
                editeEvent.TypeId = model.TypeId;

                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<EventAllViewModel>> GetMyJoinedEventsAsync(string userId)
        {
            return await dbContext.EventsParticipants
                .Where(ep => ep.HelperId == userId)
                .Select(ep => ep.Event)
                .Select(e => new EventAllViewModel
                {
                    Name = e.Name,
                    Start = e.Start,
                    Organiser = e.Organiser.UserName,
                    Type = e.Type.Name,
                    Id = e.Id
                }).ToListAsync();
        }

        public async Task AddEventToJoinedAsync(string userId, EventAllViewModel joinedEvent)
        {
            bool alreadyAdded = await dbContext.EventsParticipants
                .AnyAsync(x => x.HelperId == userId && x.EventId == joinedEvent.Id);

            if (alreadyAdded == false)
            {
                var eventParticipant = new EventParticipant
                {
                    HelperId = userId,
                    EventId = joinedEvent.Id
                };

                await dbContext.EventsParticipants.AddAsync(eventParticipant);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task RemoveEventToJoinedAsync(string userId, EventAllViewModel joinedEvent)
        {
            bool alreadyAdded = await dbContext.EventsParticipants
                .AnyAsync(x => x.HelperId == userId && x.EventId == joinedEvent.Id);

            if (alreadyAdded == true)
            {
                var toRemove = await dbContext.EventsParticipants
                    .Where(x => x.HelperId == userId && x.EventId == joinedEvent.Id)
                    .FirstAsync();

                dbContext.EventsParticipants
                    .Remove(toRemove);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
