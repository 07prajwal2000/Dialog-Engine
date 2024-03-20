using DialogEngine;
using Raylib_CsLo;

var engine = Engine.FromJson();

Raylib.InitWindow(1280, 720, "Dialog Engine Demos");
Raylib.SetTargetFPS(60);

var rect = new Rectangle(100, 100, 500, 200);
var rectBtn = new Rectangle(100, 60, 150, 30);

var node = engine.GetCurrentNode();

RayGui.GuiSetStyle(0, 16, 18);
var f = Raylib.LoadFont("font.ttf");
RayGui.GuiSetFont(f);
while (!Raylib.WindowShouldClose())
{
    Raylib.BeginDrawing();
    Raylib.ClearBackground(Raylib.SKYBLUE);
    if (!engine.Ended)
    {
        RenderDialog();
    }
    else
    {
        if (RayGui.GuiButton(new Rectangle(100, 100, 150, 30), "Restart"))
        {
            engine.Restart();
            node = engine.GetCurrentNode();
        }
    }

    Raylib.EndDrawing();
}

void RenderDialog()
{
    var isLastNode = engine.IsLastNode();
    if (RayGui.GuiButton(rectBtn, isLastNode ? "Close" : "Next") && node?.NodeType != NodeType.Branch)
    {
        node = engine.Next();
        Console.WriteLine(engine.IsLastNode());
    }
    if (node != null && node.NodeType == NodeType.Dialog)
    {
        RayGui.GuiTextBoxMulti(rect, node.Title, 22, false);
    }
    if (node != null && node.NodeType == NodeType.Branch)
    {
        var branch = (BranchNode)node;
        var idx = 0;
        var rectText = new Rectangle(100, 100, 100, 20);
        RayGui.GuiLabel(rectText, "Select option");
        foreach (var listNode in branch.GetList())
        {
            var r = new Rectangle(120, 120 + (idx * 35), 100, 30);
            if (RayGui.GuiButton(r, listNode.Option))
            {
                engine.SetCurrentNode(branch.SelectByIndex(idx)!);
                node = engine.Next();
            }
            idx++;
        }
    }
}

Raylib.CloseWindow();