using System;
using Microsoft.EntityFrameworkCore;
using VolunteerRegistrationDAL.Context;

namespace VRBDALTests
{
    public static class TestContext
    {
        public static VolunteerRegistrationContext Context => new VolunteerRegistrationContext(new DbContextOptionsBuilder<VolunteerRegistrationContext>()
            .UseInMemoryDatabase($"{Guid.NewGuid()}")
            .Options);
    }
}