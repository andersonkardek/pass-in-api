﻿using PassIn.Communication.Responses;
using PassIn.Exceptions;
using PassIn.Infrastructure;

namespace PassIn.Application.UseCases.Events.GetById;
public class GetEventByIdUseCase
{
    public ResponseEventJson Execute(Guid id)
    {
        var dbContext = new PassInDbContext();

        var even = dbContext.Events.Find(id);

        if (even is null)
        {
            throw new PassInException("Event not found if this Id");
        }

        return new ResponseEventJson
        {
            Id = even.Id,
            Title = even.Title,
            Details = even.Details,
            MaximumAttendees = even.Maximum_Attendees,
            AttendeesAmount = -1,
        };
    }
}