using Codartesien.SourceGenerators.SceneNodeResolver;
using Godot;

namespace GUITest.scripts;

/// <summary>
/// Top-level auto-load node for resolving internal node references for all nodes added to the scene tree.
/// from <see href="https://medium.com/@romain.mouillard.fr/optimizing-onready-in-c-with-source-generators-for-better-performance-76e87600b30a"/>>
/// </summary>
public partial class GlobalResolver : Node
{
    public override void _EnterTree()
    {
        // Listen for new nodes added to the scene tree
        GetTree().NodeAdded += OnNodeAdded;
    }

    private static void OnNodeAdded(Node node)
    {
        // Resolve internal node references by resolving [SceneNode] attributes
        if (node is not ISceneNodeResolver sceneNode) return;
        sceneNode.ResolveNodes();
    }
}