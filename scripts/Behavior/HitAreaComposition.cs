using beethebee.Scripts.Behavior.abstractions;
using beethebee.Scripts.Helpers;
using Godot;
using System;

public partial class HitAreaComposition : Area2D
{
    public override void _Ready()
    {
        AreaEntered += HitAreaComposition_MouseEntered;
        //this.MouseEntered += HitAreaComposition_MouseEntered;
        base._Ready();
    }

    private void HitAreaComposition_MouseEntered(Area2D area)
    {
        if (area is IMouseShape mouse)
        {
            GameManager.Instance.ApplyDamage(1);
            foreach (var item in area.GetChildren())
            {
                if (item is AudioStreamPlayer2D audio)
                {
                    audio.Play();
                }
            }
        }
    }

    public override void _Process(double delta)
    {
        base._Process(delta);
    }
}
