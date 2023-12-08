using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RapidBlazor.Old.Application.WeatherForecasts.Queries;
using RapidBlazor.Old.WebUI.Shared.WeatherForecasts;

namespace RapidBlazor.Old.WebUI.Server.Controllers;

[Authorize]
public class WeatherForecastController : ApiControllerBase
{
    [HttpGet]
    public async Task<IList<WeatherForecast>> Get()
    {
        return await Mediator.Send(new GetWeatherForecastsQuery());
    }
}
