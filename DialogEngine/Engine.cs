using DialogEngine.Parser;

namespace DialogEngine
{
    public class Engine
    {
        private BaseNode currentNode = null;
        public bool Ended => currentNode == null;
        private BaseNode initialNode = null;

        public static Engine FromJson(string filePath = "dialog.json")
        {
            var parser = new DialogJsonParser();
            var engine = new Engine();
            var firstNode = parser.ParseFile(engine, filePath);
            engine.Start(firstNode);
            return engine;
        }

        public void Start(BaseNode startNode)
        {
            if (currentNode != null)
            {
                return;
            }
            currentNode = startNode;
            initialNode = startNode;
        }

        public void Restart(BaseNode startFrom = null)
        {
            if (startFrom == null)
            {
                currentNode = initialNode;
                return;
            }
            currentNode = startFrom;
        }

        public BaseNode GetCurrentNode()
        {
            return currentNode;
        }

        public void SetCurrentNode(BaseNode node) => currentNode = node;

        public BaseNode Next()
        {
            if (currentNode == null) return null;
            currentNode = currentNode.GetNextNode();
            return currentNode;
        }

        public bool IsLastNode() => currentNode != null && !currentNode.HasNext();
    }
}