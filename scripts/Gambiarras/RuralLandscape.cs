using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Godot;
public partial class RuralLandscape : Sprite2D
{
    public Viewport Viewport { get; private set; }
    public override void _Ready()
    {
        Viewport = GetViewport();
        Position = Viewport.GetVisibleRect().GetCenter();
        
        base._Ready();
    }
    public override void _Process(double delta)
    {
        //foreach (var item in Viewport.GetSignalList())
        //{
        //    GD.Print(item);
        //}
        base._Process(delta);
    }
}
