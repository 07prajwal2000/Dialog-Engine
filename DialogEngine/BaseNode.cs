namespace DialogEngine
{
    public abstract class BaseNode
    {
        public int Id { get; protected set; }
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public NodeType NodeType { get; protected set; }

        public virtual bool HasNext()
        {
            return false;
        }
        public abstract BaseNode GetNextNode();
    }
}