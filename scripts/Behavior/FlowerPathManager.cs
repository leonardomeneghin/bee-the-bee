using beethebee.Scripts.Helpers;
using Godot;
using System;
using System.Collections.Generic;

public partial class FlowerPathManager : Node2D
{
    Timer timer;
    private List<Path2D> pathList = new List<Path2D>();
    private bool shouldSpawnPath = false;
    private PackedScene _path;
    public override void _Ready()
    {
        _path = GD.Load<PackedScene>(Helper.PATH_INFINITE_OBJECT_SCENE);
        timer = ConfigureTimer();
        base._Ready();
    }
    public override void _Process(double delta)
    {
        if (pathList.Count == 3)
        {
            timer.Stop();
        }
        base._Process(delta);
    }
    private Timer ConfigureTimer()
    {
        var timer = new Timer()
        {
            Autostart = true,
            OneShot = false,
            WaitTime = 1,
            Paused = false
         };
         timer.Timeout += AddAnotherPathToScene;
         this.AddChild(timer);
         return timer;
    }

    private void AddAnotherPathToScene()
    { 
        var path = _path.Instantiate() as Path2D;
        path.GlobalPosition = GetViewport().GetVisibleRect().GetCenter();
        pathList.Add(path);
        AddChild(path);
        
    }
}
