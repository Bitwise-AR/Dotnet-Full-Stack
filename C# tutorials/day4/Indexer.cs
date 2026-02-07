class Marks
{
    private int[] marks = { 80, 90, 85 };

    public int this[int index]
    {
        get { return marks[index]; }
    }
}

// Indexer Overloading

class EmployeeDirectory
{
    private Dictionary<int, string> employees = new Dictionary<int, string>();

    public string this[int id]
    {
        get { return employees[id]; }
        set { employees[id] = value; }
    }

    public string this[string name]
    {
        get
        {
            return employees.FirstOrDefault(e => e.Value == name).Value;
        }
    }
}