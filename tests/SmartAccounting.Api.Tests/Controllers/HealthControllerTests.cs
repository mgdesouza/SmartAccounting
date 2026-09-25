using Microsoft.AspNetCore.Mvc;
using SmartAccounting.Api.Controllers;

namespace SmartAccounting.Api.Tests.Controllers;

public class HealthControllerTests
{
    [Fact]
    public void Health_ShouldReturnOk()
    {
        var controller = new HealthController();

        var result = controller.Health();

        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal(200, okResult.StatusCode);
    }

    [Fact]
    public void Health_ShouldReturnHealthyStatus()
    {
        var controller = new HealthController();

        var result = controller.Health();

        var okResult = Assert.IsType<OkObjectResult>(result);
        var value = Assert.NotNull(okResult.Value);

        var status = value.GetType().GetProperty("status")?.GetValue(value)?.ToString();
        var service = value.GetType().GetProperty("service")?.GetValue(value)?.ToString();

        Assert.Equal("Healthy", status);
        Assert.Equal("SmartAccounting.Api", service);
    }
}
