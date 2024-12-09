using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager
{
    public class TaskOperations
    {
        private List<UserTask> TaskList = new List<UserTask>();

        public void AddTask(UserTask task)
        {
            TaskList.Add(task);
        }
        public void RemoveTask(string title)
        {
            UserTask task = TaskList.Find(t => t.Title == title);
            if (task != null)
            {
                TaskList.Remove(task);
            }
            else
            {
                Console.WriteLine("Task not found");
            }
        }
        public List<UserTask> ViewTasks()
        {
            return TaskList;
        }

        public List<UserTask> GetRemainingTasks()
        {
            return TaskList.FindAll(t => t.IsCompleted == false);
        }
        public List<UserTask> GetCompletedTasks()
        {
            return TaskList.FindAll(t => t.IsCompleted);
        }








        //File I/O
        public static void AddTask()
        {
            Console.WriteLine("What is the title of the task you would like to add?");
            string taskName = Console.ReadLine();

            using (StreamWriter streamWriter = new StreamWriter("todo.txt", true))
            {
                streamWriter.WriteLine(taskName);
            }
            Console.WriteLine($"{taskName} has been successfully added to the task list.");
        }
        public static void ViewTask()
        {

            Console.WriteLine("\nTasks:");

            if (File.Exists("todo.txt"))
            {
                string[] tasks = File.ReadAllLines("todo.txt");

                for (int i = 0; i < tasks.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {tasks[i]}");
                }
            }
            else
            {
                Console.WriteLine("No tasks available.");
            }

            Console.WriteLine();
        }
        public static void RemoveTask()
        {
            List<string> tasks = new List<string>();
            if (File.Exists("todo.txt"))
            {
                tasks.AddRange(File.ReadAllLines("todo.txt"));
            }
            else
            {
                Console.WriteLine("No tasks file found");
            }

            ViewTask();
            Console.WriteLine("Which task would you like to delete?");
            int taskNumber;
            if (int.TryParse(Console.ReadLine(), out taskNumber) && taskNumber >= 1 && taskNumber <= tasks.Count)
            {
                string taskToDelete = tasks[taskNumber - 1];
                tasks.RemoveAt(taskNumber - 1);
                File.WriteAllLines("todo.txt", tasks);
                Console.WriteLine($"{taskToDelete} has been deleted.");
            }
            else
            {
                Console.WriteLine("Invalid task number.");
            }

            Console.WriteLine("Updated tasks");
            foreach (string task in tasks)
            {
                Console.WriteLine(task);
            }



        }

    }
}
