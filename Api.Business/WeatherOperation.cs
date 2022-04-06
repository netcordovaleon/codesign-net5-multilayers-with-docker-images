using System;

namespace Api.Business
{
    public class WeatherOperation
    {

        public  string[] Summaries () {
            return new string[] { "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching" };
        }

    }
}
