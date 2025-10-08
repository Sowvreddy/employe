using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class Employee
{
    public string Name { get; set; } = string.Empty;
    public int TotalTimeWorked { get; set; }

    public Employee() { }

    public Employee(string name, int hours)
    {
        Name = name;
        TotalTimeWorked = hours;
    }
}

class Program
{
    static void Main()
    {
        // Create a list of 10 employees manually (you can fetch from API instead)
        List<Employee> employees = new List<Employee>
        {
            new Employee("Sowmya", 120),
            new Employee("Raj", 80),
            new Employee("Anil", 150),
            new Employee("Lakshmi", 95),
            new Employee("Vikram", 110),
            new Employee("Kiran", 105),
            new Employee("Neha", 130),
            new Employee("Ramesh", 75),
            new Employee("Priya", 140),
            new Employee("Ajay", 100)
        };

        // Order employees by TotalTimeWorked descending
        var orderedEmployees = employees.OrderByDescending(e => e.TotalTimeWorked).ToList();

        // Build the HTML table
        string html = "<html><head><style>" +
                      "table { border-collapse: collapse; width: 60%; }" +
                      "th, td { border: 1px solid black; padding: 8px; text-align: left; }" +
                      ".low-hours { background-color: #ffcccc; }" +
                      "</style></head><body>";

        html += "<h2>Employee Total Time Worked</h2><table>";
        html += "<tr><th>Name</th><th>Total Time Worked (hours)</th></tr>";

        foreach (var emp in orderedEmployees)
        {
            string rowClass = emp.TotalTimeWorked < 100 ? "low-hours" : "";
            html += $"<tr class='{rowClass}'><td>{emp.Name}</td><td>{emp.TotalTimeWorked}</td></tr>";
        }

        html += "</table></body></html>";

        // Save to employees.html in the current directory
        string fileName = "employees.html";
        File.WriteAllText(fileName, html);

        Console.WriteLine($"HTML file '{fileName}' created successfully. Open it in your browser.");
    }
}
