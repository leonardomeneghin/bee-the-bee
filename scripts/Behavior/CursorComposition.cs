using Godot;
using System;

public partial class CursorComposition : Node
{
    [Export] Texture2D[] CursorFrames;
    [Export] public float FrameTime = 0.1f;
    private Godot.Timer _timer;
    private int _currentFrame = 0;
    public override void _Ready()
    {
        if (CursorFrames is null) return;
        _timer = new Godot.Timer();
        _timer.WaitTime = FrameTime;
        _timer.OneShot = false;
        _timer.Timeout += ChangeCursorFrameTimeOut;
        AddChild(_timer);
        _timer.Start();
        if (CursorFrames.Length > 0)
        {
            Input.SetCustomMouseCursor(CursorFrames[0]);
        }
    }
    private void ChangeCursorFrameTimeOut()
    {
        if (CursorFrames is null) return;
        _currentFrame = (_currentFrame + 1) % CursorFrames.Length;
        Input.SetCustomMouseCursor(CursorFrames[_currentFrame]);
}
}
