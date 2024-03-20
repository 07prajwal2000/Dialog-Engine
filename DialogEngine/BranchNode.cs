using System.Collections.Generic;

namespace DialogEngine
{
    public class BranchNode : BaseNode
    {
        private List<OptionNode> branchNodes = new List<OptionNode>();
        private OptionNode selected;
        private readonly Engine engine;

        public BranchNode(Engine engine, string title, string description = "", int id = -1)
        {
            NodeType = NodeType.Branch;
            Title = title;
            Description = description;
            this.engine = engine;
            Id = id;
        }

        public void AddNode(OptionNode node) => branchNodes.Add(node);

        public IEnumerable<OptionNode> GetList() => branchNodes;

        public BaseNode SelectByIndex(int index)
        {
            if (index < 0 || index >= branchNodes.Count) return null;
            selected = branchNodes[index];
            engine.SetCurrentNode(selected);
            return selected;
        }

        public override bool HasNext()
        {
            return true;
        }

        public override BaseNode GetNextNode()
        {
            return selected;
        }
    }
}