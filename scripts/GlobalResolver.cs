global using Godot;
global using GUITest.scripts.EX;
using Codartesien.SourceGenerators.SceneNodeResolver;

namespace GUITest.scripts;

/// <summary>
///     Top-level autoload node for resolving internal node references for all nodes added to the scene tree.
///     From
///     <see
///         href="https://medium.com/@romain.mouillard.fr/optimizing-onready-in-c-with-source-generators-for-better-performance-76e87600b30a" />
///     >
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