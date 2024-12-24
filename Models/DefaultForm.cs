namespace feedback.Models;

public class DefaultForm
{
    public int ID { get; set; }
    public int FormID { get; set; }
    public Form Form { get; set; }

    public enum Type
    {
        Community,
        Indestry
    }
    
    public Type type { get; set; }
    
}