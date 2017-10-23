﻿using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace VolunteerRegistrationRestAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
                .CaptureStartupErrors(true)
                .UseStartup<Startup>()
                .Build();
        }
    }
}