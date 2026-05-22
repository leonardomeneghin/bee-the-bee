using beethebee.Scripts.Behavior.abstractions;
using beethebee.Scripts.Helpers;
using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class FlowerPathPatternInfinite : Path2D
{
    private PackedScene _flowerScene;
    private PathFollow2D pathFollow;
    private Timer _timer;
    private Random _random = new Random();
    public override void _Ready()
    {
        _flowerScene = GD.Load<PackedScene>(Helper.FLOWER_COLLECTABLE_SCENE);
        pathFollow = ConfigPathFollow();
        _timer = ConfigureTimer();
        base._Ready();
    }

    private PathFollow2D ConfigPathFollow()
    {
        var pf = new PathFollow2D();
        pf.Rotates = false;
        this.AddChild(pf);
        return pf;
    }

    public override void _Process(double delta)
    {
        if (GameManager.Instance.playerDefeated)
        {
            _timer.Stop();
            return;
        }
        pathFollow.ProgressRatio += (float)delta /10;
        base._Process(delta);
    }
    
    public void AddFlowerToScene()
    {
        var flower = _flowerScene.Instantiate() as Flower;
        var total = this.Curve.PointCount;
        var globalCurvePos = Curve.GetPointPosition(GD.RandRange(0, total));
        GD.Print(globalCurvePos); //DEBUG
        var localpos = pathFollow.ToLocal(globalCurvePos);

        flower.GlobalPosition = localpos;
        flower.TreeEntered += SpawnStop;
        this.pathFollow.AddChild(flower);
        flower.TreeExited += SpawnStart;
    }

    private void SpawnStart()
    {
        _timer.Start();
    }

    private void SpawnStop()
    {
        _timer.Stop();
    }

    private Timer ConfigureTimer()
    {
        var timer = new Timer()
        {
            Autostart = true,
            OneShot = false,
            WaitTime = _random.Next(3, 30), 
            Paused = false
        };
        timer.Timeout += AddFlowerToScene;
        timer.Autostart = true;
        this.AddChild(timer);
        return timer;
    }
}
