using System;
using System.Collections.Generic;
using beethebee.Scripts.Helpers;
using Godot;

public partial class EnemyPathPatternSquare : Path2D
{
    private PathFollow2D pathFollow;
    public Timer _timer;

    private PackedScene _enemy;
    public override void _Ready()
    {
        _enemy = GD.Load<PackedScene>(Helper.ENEMY);
        _timer = ConfigureTimer();
        pathFollow = ConfigPathFollow();
        base._Ready();
    }
    public void OnTimerTimeout()
    {
        RigidBody2D enemy = _enemy.Instantiate() as RigidBody2D;
        pathFollow.ProgressRatio = GD.Randf();
        enemy.GlobalPosition = pathFollow.GlobalPosition;

        
        Vector2 direction = pathFollow.GlobalPosition.DirectionTo(GetGlobalMousePosition());
        enemy.Rotation = direction.Angle();
        enemy.LinearVelocity = direction * 1000f;
        AddChild(enemy);
        GD.Print(direction);
    }

    private Timer ConfigureTimer()
    {
        var timer = new Timer()
        {
            Autostart = true,
            OneShot = false,
            WaitTime = GameManager.Instance.SpawnRate,
            Paused = false
        };
        timer.Timeout += OnTimerTimeout;
        timer.Autostart = true;
        this.AddChild(timer);
        return timer;
    }

    public override void _Process(double delta)
    {
        if (GameManager.Instance.playerDefeated)
        {
            _timer.Stop();
            return;
        }
        pathFollow.ProgressRatio += (float)delta / 4;
        base._Process(delta);
    }

    private PathFollow2D ConfigPathFollow()
    {
        var pf = new PathFollow2D();
        pf.Rotates = false;
        this.AddChild(pf);
        return pf;
    }

}
