using System.Linq;

var storage = new StorageService("expenses.json");
List<Expense> expenses = storage.Load<List<Expense>>();

bool running = true;

while (running)
{
    Console.Clear();
    Console.WriteLine("===Expense Tracker===");
    Console.WriteLine("1. Add Expense");
    Console.WriteLine("2. View Expenses");
    Console.WriteLine("3. View Total Expenses");
    Console.WriteLine("4. Delete Expense");
    Console.WriteLine("5. Edit Expense");
    Console.WriteLine("6. View Average Expense");
    Console.WriteLine("7. Clear all Expenses");
    Console.WriteLine("8. Exit");
    Console.WriteLine("9. Show Data File Location");
    Console.Write("Select an option: ");

    string input = Console.ReadLine();

    switch (input)
{
    case "1":
        AddExpense();
        break;
    case "2":
        ViewExpenses();
        break;
    case "3":
        ViewTotalExpenses();
        break;
    case "4":
        DeleteExpense();
        break;
    case "5":
        EditExpense();
        break;
    case "6":
        ViewAverageExpense();
        break;
    case "7":
        ClearExpenses();
        break;
    case "8":
        running = false;
        Console.WriteLine("\nExiting...");
        break;
    case "9":
        Console.WriteLine($"\nSaving to: {storage.GetFilePath()}");
        break;
    default:
        Console.WriteLine("Invalid option. Please try again.");
        break;
}

    if (running)
    {
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }
}



 void AddExpense()
{
    Console.Write("\nEnter expense name: ");
    string name = Console.ReadLine()?.Trim() ?? "";

    if (string.IsNullOrWhiteSpace(name))
    {
        Console.WriteLine("\nExpense name cannot be empty.");
        return;
    }

    Console.Write("Enter expense amount: ");
    decimal amount;
    while (!decimal.TryParse(Console.ReadLine(), out amount) || amount < 0)
    {
        Console.Write("Invalid amount. Please enter a valid positive number: ");
    }

    expenses.Add(new Expense { Name = name, Amount = amount });
    storage.Save(expenses);
    Console.WriteLine("\nExpense added successfully!");
}

void ViewExpenses()
{
    if (expenses.Count == 0)
    {
        Console.WriteLine("No expenses recorded.");
        return;
    }

    Console.WriteLine("=== Expenses ===");
    for (int i = 0; i < expenses.Count; i++)
    {
        var expense = expenses[i];
        Console.WriteLine($"{i + 1}. {expense.Name}: {expense.Amount:C}");
    }
}

void ViewTotalExpenses()
{
    decimal total = expenses.Sum(e => e.Amount);
    Console.WriteLine($"\nTotal Expenses: {total:C}");
}

void DeleteExpense()
{
    if (expenses.Count == 0)
    {
        Console.WriteLine("No expenses to delete.");
        return;
    }

    ViewExpenses();
    Console.Write("Enter the number of the expense to delete: ");

    if (!int.TryParse(Console.ReadLine(), out int choice))
    {
        Console.WriteLine("Invalid number.");
        return;
    }

    int index = choice - 1;

    if (index < 0 || index >= expenses.Count)
    {
        Console.WriteLine("Expense not found.");
        return;
    }

    var toDelete = expenses[index];
    Console.Write($"Delete \"{toDelete.Name}\" ({toDelete.Amount:C})? (y/n): ");
    var confirm = Console.ReadLine();

    if (confirm?.Trim().ToLower() != "y")
    {
        Console.WriteLine("Cancelled.");
        return;
    }

    expenses.RemoveAt(index);
    storage.Save(expenses);
    Console.WriteLine("Expense deleted successfully!"); 
}


void EditExpense()
{
    if (expenses.Count == 0)
    {
        Console.WriteLine("\nNo expenses to edit.");
        return;
    }

    ViewExpenses();
    Console.Write("\nEnter the number of the expense to edit: ");

    if (!int.TryParse(Console.ReadLine(), out int choice))
    {
        Console.WriteLine("\nInvalid number.");
        return;
    }

    int index = choice - 1;

    if (index < 0 || index >= expenses.Count)
    {
        Console.WriteLine("\nExpense not found.");
        return;
    }

    var expenseToEdit = expenses[index];

    Console.Write($"Enter new expense name (leave blank to keep \"{expenseToEdit.Name}\"): ");
    string newName = Console.ReadLine();

    if (!string.IsNullOrWhiteSpace(newName))
    {
        expenseToEdit.Name = newName.Trim();
    }

    Console.Write($"Enter new expense amount (leave blank to keep {expenseToEdit.Amount:C}): ");
    string amountInput = Console.ReadLine();

    if (!string.IsNullOrWhiteSpace(amountInput))
    {
        decimal newAmount;
        while (!decimal.TryParse(amountInput, out newAmount) || newAmount < 0)
        {
            Console.Write("Invalid amount. Please enter a valid positive number: ");
            amountInput = Console.ReadLine();
        }

        expenseToEdit.Amount = newAmount;
    }

    Console.WriteLine("\nExpense updated successfully!");
    storage.Save(expenses); 

}
void ViewAverageExpense()
{
    if (expenses.Count == 0)
    {
        Console.WriteLine("\nNo expenses recorded.");
        return;
    }

    decimal average = expenses.Average(e => e.Amount);
    Console.WriteLine($"\nAverage Expense: {average:C}");
}

void ClearExpenses()
{
    if (expenses.Count == 0)
    {
        Console.WriteLine("\nNo expenses to clear.");
        return;
    }

    Console.Write("Are you sure you want to clear all expenses? (y/n): ");
    var confirm = Console.ReadLine();

    if (confirm?.Trim().ToLower() != "y")
    {
        Console.WriteLine("Cancelled.");
        return;
    }

    expenses.Clear();
    storage.Save(expenses);
    Console.WriteLine("\nAll expenses cleared successfully!");
}
