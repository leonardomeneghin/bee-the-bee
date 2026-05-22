using beethebee.Scripts.Behavior.abstractions;
using beethebee.Scripts.Helpers;
using Godot;
using System;
using System.ComponentModel;
using System.Linq;

public partial class Flower : Node2D, IFlowerCollectable
{
    PackedScene flower_asset;
    [Export]
    AnimatedSprite2D sprite;

    public override void _Ready()
    {
        if (sprite == null) { throw new Exception("Houve um erro ao carregar o Animated sprite de flower"); }
        sprite.Play(new Random().Next(2).ToString()); //TODO: Melhorar o uso do random baseado no tamanho maximo de animações contidas no AnimatedSprite
        base._Ready();
    }
    public override void _Process(double delta)
    {
        sprite.Rotate(0.05f);
        base._Process(delta);
    }

}
