class StudentCollection
{
    private string[] students = new string[3];

    public string this[int index]
    {
        get
        {
            if (index < 0 || index >= students.Length)
                return "Invalid Index";
            return students[index];
        }
        set
        {
            if (index >= 0 && index < students.Length)
                students[index] = value;
        }
    }
}