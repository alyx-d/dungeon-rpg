using Godot;

namespace DungeonRpg.Scripts.UI;

public partial class UiContainer : Container
{
    [Export] public ContainerType ContainerType { get; private set; }
    [Export] public Button ButtonNode { get; private set; }
    
    [Export] public TextureRect TextureNode { get; private set; }
    [Export] public Label DescriptionLabelNode { get; private set; }
}