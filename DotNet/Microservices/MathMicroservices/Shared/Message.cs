namespace Shared;

public class Message
{
    public string CorrelationId { get; set; }
    public int Number { get; set; }
    public List<int> Numbers { get; set; } // for batch input
    public int Result { get; set; }
    public string Type { get; set; }
}