using Godot;
using System;

public partial class DieOnTimeoutBehavior : Timer
{
    public override void _EnterTree()
    {
            WaitTime = new Random().Next(6, 19);
            Timeout += Die;
            base._Ready();
            base._EnterTree();
    }
    public void Die()
    {
        GetParent().QueueFree();
        GC.Collect();
    }
}
