namespace EFCore;

public class PersonCard
{
    public long Id { get; set; }
    public string NO { get; set; }
    //1对1关系必须在其中一个实体中增加一个自定义外键属性
    public long? PersonId { get; set; }
    public Person Person { get; set; }


}