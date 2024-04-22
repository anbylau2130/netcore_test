namespace EFCore;

public class Node
{

    public long Id { get; set; }
    public long? ParentId { get; set; }

    public string Name { get; set; }
    public Node Parent { get; set; }

    public List<Node> Children { get; set; }=new();

    public bool IsDeleted { get; set; } = false;


    public byte[] RowVersion { get; set; }

}