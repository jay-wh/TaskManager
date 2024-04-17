using TaskManager.Models;

namespace TaskManager;

public static class TaskStore
{
    private static List<TaskItem> Tasks { get; } = new();

    public static List<TaskItem> GetTasks()
    {
        return Tasks;
    }

    public static void AddTask(TaskItem item)
    {
        item.Id = Tasks.Any() ? Tasks.Last().Id + 1 : 1;

        Tasks.Add(item);
    }

    public static void SetCompleted(int taskId)
    {
        var task = Tasks.FirstOrDefault(t => t.Id.Equals(taskId));

        if (task != null)
        {
            task.Completed = true;
        }
    }

    public static void DeleteTask(int taskId)
    {
        var taskToDelete = Tasks.FirstOrDefault(t => t.Id.Equals(taskId));

        if (taskToDelete != null)
        {
            Tasks.Remove(taskToDelete);
        }
    }
}