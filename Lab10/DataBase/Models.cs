namespace Lab10.DataBase;

public class BaseModel
{
    public Guid Id { get; set; }
    public string? Name  { get; set; }
}

public class Animal : BaseModel
{
    public string? Type { get; set; }
    public string? Eats { get; set; }
    public Guid AviaryId { get; set; }
    public Aviary? Aviary { get; set; }
}

public class Aviary : BaseModel
{
    public string? Position { get; set; }
}