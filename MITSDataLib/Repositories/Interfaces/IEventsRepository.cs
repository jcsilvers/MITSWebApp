﻿using MITSDataLib.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MITSDataLib.Repositories.Interfaces
{
    public interface IEventsRepository
    {
        Task<Event> GetEvent(int id);
        Task<List<Event>> GetEvents();
        Task<Event> CreateEvent(Event newEvent);
        Task<List<WildApricotEvent>> GetWaEventByEventId(int id);
        Task<List<WildApricotRegistration>> GetWaRegistrationTypesByWaEventId(int id);
    }
}
