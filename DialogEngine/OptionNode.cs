namespace DialogEngine
{
    public class OptionNode : DialogNode
    {
        public readonly string Option;
        public readonly int NextId;

        public OptionNode(string option, int nextId = -1, BaseNode nextNode = null) : base("", "", -1, nextNode)
        {
            Option = option;
            NodeType = NodeType.OptionNode;
            NextId = nextId;
        }
    }
}