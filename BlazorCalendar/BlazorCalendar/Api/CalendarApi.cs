using BlazorCalendar.Shared.DTOs.Calendar;
using BlazorCalendar.Shared.UseCases.Calendar;

namespace BlazorCalendar.Api
{
    public static class CalendarApi
    {
        public static void MapCalendarEndpoints(this WebApplication app)
        {
            var group = app.MapGroup("api/v1/calendar");
            group.MapGet("/", async (IGetCalendar getCalendarUseCase, int year, int month, string userId)
                    => Results.Ok(await getCalendarUseCase.GetAsync(year, month, userId))); 

            group.MapPost("/", async (EventData requestModel, IAddDayEvent addDayEventUseCase) => {
                var timestamp = requestModel.Timestamp;
                var addnewEventModel = new AddOrEditEventModel(requestModel.UserId!)
                {
                    Day = timestamp.Day,
                    Month = timestamp.Month,
                    Year = timestamp.Year,
                    Title = requestModel.Title,
                    Description = requestModel.Description,
                    Hours = timestamp.Hour,
                    Minutes = timestamp.Minute
                };
                
                var eventAdded = await addDayEventUseCase.ProcessAsync(addnewEventModel);

                return eventAdded.IsSuccess ? 
                    Results.Ok(new NewEventCreatedResponse(eventAdded.EventId!)) : Results.BadRequest();
            });

            group.MapPut("/{eventId}", async (IUpdateDayEvent updateDayEventUseCase, string eventId, EventData requestModel) => {
                var timestamp = requestModel.Timestamp;
                var updateEventModel = new AddOrEditEventModel(requestModel.UserId!)
                {
                    EventId = eventId,
                    Day = timestamp.Day,
                    Month = timestamp.Month,
                    Year = timestamp.Year,
                    Title = requestModel.Title,
                    Description = requestModel.Description,
                    Hours = timestamp.Hour,
                    Minutes = timestamp.Minute
                };

                var eventUpdated = await updateDayEventUseCase.ProcessAsync(updateEventModel);

                return eventUpdated.IsSuccess ? Results.NoContent() : Results.BadRequest();
            });

            group.MapDelete("/{eventId}", async (IDeleteDayEvent deleteDayEventUseCase, string eventId) => {
                await deleteDayEventUseCase.DeleteEvent(eventId);

                return Results.Ok();
            });

            group.RequireAuthorization();
        }
    }
}
