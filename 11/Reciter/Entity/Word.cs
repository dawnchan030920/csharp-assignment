namespace Reciter.Entity;

public class Word
{
    public int Id { get; set; }
    
    public required string English { get; set; }
    
    public required string Chinese { get; set; }
}