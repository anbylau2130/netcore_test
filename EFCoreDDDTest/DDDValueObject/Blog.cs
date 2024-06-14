namespace EFCoreDDDTest.DDDValueObject;

public class Blog
{
    public int Id { get; set; }
    public MultiLangString Title { get; set; }
    public MultiLangString Body { get; set; }
}