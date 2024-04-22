namespace EFCore;

public class Person
{
    public long Id { get; set; }
    public string Name { get; set; }

    public PersonCard PersonCard { get; set; }

}