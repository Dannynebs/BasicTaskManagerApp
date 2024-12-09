// See https://aka.ms/new-console-template for more information
using TaskManager;

string filePath = "todo.txt";
List<UserTask> taskList = new List<UserTask>();
Console.WriteLine("Welcome to the task manager!");

while (true)
{
    Console.WriteLine("1. View tasks");
    Console.WriteLine("2. Add task");
    Console.WriteLine("3. Remove task");
    Console.WriteLine("4. Exit");

    Console.WriteLine("Enter your choice (1-4): ");
    string userInput = Console.ReadLine();

    switch (userInput)
    {
        case "1":
            TaskOperations.ViewTask();
            break;

        case "2":
            TaskOperations.AddTask();
            break;

        case "3":
            TaskOperations.RemoveTask();
            break;

        case "4":
            Environment.Exit(0);
            break;

        default:
            Console.WriteLine("Invalid choice. Please enter a number between 1 and 4.");
            break;
    }

}

