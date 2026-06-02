using LibraryManagement.Application.ResponseModel;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.API.Extensions;
public static class ResponseModelExtensions
{
    public static IActionResult ToActionResult<T>(
        this ResponseModel<T> response, ControllerBase controller)
        => controller.StatusCode(response.StatusCode, response);
}
