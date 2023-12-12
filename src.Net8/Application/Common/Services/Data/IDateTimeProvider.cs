namespace RapidBlazor.Application.Common.Services.Data;

public interface IDateTimeProvider
{
    DateTime UtcNow { get; }
}
