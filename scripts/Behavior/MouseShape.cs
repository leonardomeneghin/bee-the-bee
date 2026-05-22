using System;
using beethebee.Scripts.Behavior.abstractions;
using Godot;

public partial class MouseShape : Area2D, IMouseShape
{
    public override void _Process(double delta)
    {
        this.GlobalPosition = GetGlobalMousePosition() + new Vector2(64,48);
        base._Process(delta);
    }
}
