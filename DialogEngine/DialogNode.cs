namespace DialogEngine
{
    public class DialogNode : BaseNode
    {
        private BaseNode nextNode;

        public DialogNode(string title, string description = "", int id = -1, BaseNode nextNode = null)
        {
            NodeType = NodeType.Dialog;
            Title = title;
            Description = description;
            this.nextNode = nextNode;
            Id = id;
        }

        public override BaseNode GetNextNode() => nextNode;
        public void SetNextNode(BaseNode node) => nextNode = node;

        public override bool HasNext()
        {
            return nextNode != null;
        }
    }
}