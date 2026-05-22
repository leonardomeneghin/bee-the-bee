using beethebee.Scripts.Behavior.abstractions;
using beethebee.Scripts.Helpers;
using Godot;
using System;

public partial class FlowerCollectableAreaComponent : Area2D
{
    private bool givePointsToPlayer = false;
    Timer scoreTimer;
    public override void _Ready()
    {
        this.AreaEntered += FlowerPointsBehavior_MouseAreaEntered;
        base._Ready();
    }

    private void FlowerPointsBehavior_MouseAreaEntered(Area2D area)
    {
        if (area is IMouseShape mouse)
        {
            GameManager.Instance.AddScore(1);
        }
    }


}
