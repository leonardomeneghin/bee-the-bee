using Godot;
using System;

public partial class Main : Node2D
{
    public override void _Ready()
    {
        var dummy1 = ResourceLoader.Load<PackedScene>("res://scenes/PathInfiniteObject.tscn");
        var dummy2 = ResourceLoader.Load<PackedScene>("res://scenes/FlowerCollectable.tscn");
        var dummy3 = ResourceLoader.Load<PackedScene>("res://scenes/enemy.tscn");
    }
}
