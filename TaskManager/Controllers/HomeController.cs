using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TaskManager.Models;

namespace TaskManager.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View(TaskStore.GetTasks());
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(TaskItem task)
    {
        if (!ModelState.IsValid) return View(task);

        TaskStore.AddTask(task);

        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult Complete(int taskId)
    {
        TaskStore.SetCompleted(taskId);

        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult Delete(int taskId)
    {
        TaskStore.DeleteTask(taskId);

        return RedirectToAction("Index");
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}