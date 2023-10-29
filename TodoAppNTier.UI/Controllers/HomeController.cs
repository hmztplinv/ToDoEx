using Microsoft.AspNetCore.Mvc;

public class HomeController:Controller
{
    private readonly IWorkService _workService;

    public HomeController(IWorkService workService)
    {
        _workService = workService;
    }

    public async Task<IActionResult> Index()
    {
        var works = await _workService.GetAllAsync();
        return View(works);
    }
}