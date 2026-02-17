# Expense Tracker (C# / .NET)

A console-based expense tracking application built with C# and .NET. This project allows users to record, edit, delete, and analyze expenses with persistent JSON storage. It demonstrates object-oriented programming, file persistence, and interactive console application design.

---

## Features

- Add new expenses with name and amount
- View all recorded expenses
- Edit existing expenses
- Delete expenses
- View total expenses
- View average expense amount
- Persistent storage using JSON (data is saved automatically)
- Clean and user-friendly console interface

---

## Technologies Used

- C#
- .NET
- System.Text.Json
- Object-Oriented Programming (OOP)
- Console Application Architecture

---

## How It Works

Expenses are stored in memory using a `List<Expense>` and automatically saved to a JSON file located at:

```
%LOCALAPPDATA%\ExpenseTracker\expenses.json
```

When the application starts, it loads any existing data from this file. Any changes made during runtime are immediately saved to ensure persistence.

---

## How to Run

### Prerequisites

- .NET SDK installed (version 6 or later recommended)

Check your installation:

```
dotnet --version
```

### Steps

Clone the repository:

```
git clone https://github.com/elenac28/ExpenseTracker.git
```

Navigate to the project folder:

```
cd ExpenseTracker
```

Run the application:

```
dotnet run
```

---

## Example Usage

```
=== Expense Tracker ===
1. Add Expense
2. View Expenses
3. View Total Expenses
4. Delete Expense
5. Edit Expense
6. View Average Expense
7. Exit
```

---

## Project Structure

```
ExpenseTracker/
│
├── Program.cs
├── Expense.cs
├── Services/
│   └── StorageService.cs
├── ExpenseTracker.csproj
└── README.md
```

---

## What I Learned

This project helped reinforce important C# and .NET concepts, including:

- Class design and object-oriented programming
- Working with collections (`List<T>`)
- File persistence using JSON serialization
- Input validation and error handling
- Console application architecture
- Separating storage logic from application logic

---

## Future Improvements

- Add expense categories
- Add expense dates and filtering
- Export expenses to CSV
- Build a graphical user interface (GUI)
- Convert to a web API using ASP.NET Core

---

## Author

Elena Cole  
Computer Science Graduate  
GitHub: https://github.com/elenac28

