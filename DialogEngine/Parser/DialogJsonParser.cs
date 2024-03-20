using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DialogEngine.Parser
{
    public class DialogJsonParser
    {
        private static Random randomGenerator = new Random();
        private Dictionary<int, BaseNode> dialogsRawData = new Dictionary<int, BaseNode>();

        private RawDialogJsonType[] JsonDeserialize(string jsonData)
        {
            return JsonConvert.DeserializeObject<RawDialogJsonType[]>(jsonData);
        }

        private int GenerateRandom(int min, int max)
        {
            return randomGenerator.Next(min, max);
        }

        public BaseNode ParseFile(Engine engine, string path)
        {
            var rawJson = File.ReadAllText(path);

            var rawDialog = JsonDeserialize(rawJson);
            foreach (var dialog in rawDialog)
            {
                BaseNode node = null;
                if (dialogsRawData.ContainsKey(dialog.Id) || dialog.Id <= 0)
                {
                    dialog.Id = GenerateRandom(1_000, 100_000);
                }
                if (dialog.Type == NodeType.Dialog)
                {
                    node = new DialogNode(dialog.Title, dialog.Description, dialog.Id);
                }
                else if (dialog.Type == NodeType.Branch)
                {
                    var bNode = new BranchNode(engine, dialog.Title, dialog.Description, dialog.Id);
                    foreach (var option in dialog.Nodes)
                    {
                        bNode.AddNode(new OptionNode(option.Title, option.Next));
                    }
                    node = bNode;
                }
                dialogsRawData.Add(dialog.Id, node);
            }
            MapNextNodes(rawDialog);
            return dialogsRawData.First().Value;
        }

        private void MapNextNodes(RawDialogJsonType[] rawData)
        {
            foreach (var rawNode in rawData)
            {
                if (rawNode.Type == NodeType.Dialog)
                {
                    if (rawNode.Next < 1) continue;

                    var dialog = (DialogNode)dialogsRawData[rawNode.Id];
                    dialog.SetNextNode(dialogsRawData[rawNode.Next]);
                }
                else if (rawNode.Type == NodeType.Branch)
                {
                    var branch = (BranchNode)dialogsRawData[rawNode.Id];
                    foreach (var choice in branch.GetList())
                    {
                        if (choice.NextId < 1 || !dialogsRawData.ContainsKey(choice.NextId)) continue;

                        choice.SetNextNode(dialogsRawData[choice.NextId]);
                    }
                }
            }
        }
    }
}