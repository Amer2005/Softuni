using Homies.Contracts;
using Homies.Models;
using Microsoft.AspNetCore.Mvc;

namespace Homies.Controllers
{
    public class EventController : BaseController
    {
        private readonly IEventService eventService;

        public EventController(IEventService eventService)
        {
            this.eventService = eventService;
        }

        public async Task<IActionResult> All()
        {
            var model = await eventService.GetAllEventsAsync();
            return View(model);
        }

        public async Task<IActionResult> Add()
        {
            var model = await eventService.GetNewEventAddModelAsync();

            model.OrganiserId = GetUserId();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(EventAddViewModel model)
        {
            model.OrganiserId = GetUserId();

            await eventService.AddEventAsync(model);

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            EventAddViewModel? editEvent = await eventService.GetEventByIdForEditAsync(id);

            if (editEvent == null)
            {
                return RedirectToAction(nameof(All));
            }

            return View(editEvent);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EventAddViewModel model)
        {
            await eventService.EditEventAsync(model, id);

            return RedirectToAction(nameof(All));
        }

        public async Task<IActionResult> Joined()
        {
            var model = await eventService.GetMyJoinedEventsAsync(GetUserId());

            return View(model);
        }

        public async Task<IActionResult> Join(int id)
        {
            var joinedEvent = await eventService.GetEventByIdForViewingAsync(id);

            if (joinedEvent == null)
            {
                return RedirectToAction(nameof(All));
            }

            var userId = GetUserId();

            await eventService.AddEventToJoinedAsync(userId, joinedEvent);

            return RedirectToAction(nameof(Joined));
        }

        public async Task<IActionResult> Leave(int id)
        {
            var joinedEvent = await eventService.GetEventByIdForViewingAsync(id);

            if (joinedEvent == null)
            {
                return RedirectToAction(nameof(All));
            }

            var userId = GetUserId();

            await eventService.RemoveEventToJoinedAsync(userId, joinedEvent);

            return RedirectToAction(nameof(All));
        }
    }
}
