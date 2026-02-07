class CallBy
{
    public int x = 10;
    public void IncByTen(ref int a)
    {
        a = a + 10;
    }
}