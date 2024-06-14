namespace EFCoreDDDTest;

/// <summary>
/// 测试值对象 Gender
/// </summary>
public class Person
{
    public long Id { get; init; }
    public string Name { get; private set; }


    private Person()
    {

    }

    public Person(string name)
    {
        this.Name = name;
    }

    public Gender Gender { get; set; }

}

public enum Gender
{
    Female,Male
}