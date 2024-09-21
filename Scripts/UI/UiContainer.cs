using Godot;

namespace DungeonRpg.Scripts.UI;

public partial class UiContainer : VBoxContainer
{
    [Export] public ContainerType ContainerType { get; private set; }
    [Export] public Button ButtonNode { get; private set; }
}