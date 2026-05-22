using System;
using beethebee.Scripts.Helpers;
using Godot;
using static System.Formats.Asn1.AsnWriter;

public partial class DefeatMenu : CanvasLayer
{
    [Export] public Button ConfirmButton;
    [Export] public AudioStreamPlayer AudioGameOver;
    [Export] public Label Score;


    public override void _Ready()
    {
        Visible = false;

        ConfirmButton.Pressed += OnConfirmButton;

        GameManager.OnDefeat += OnDefeat;
        Score.Text += GameManager.Instance.Score;
    }

    private void OnConfirmButton()
    {
        ChangeSceneToMain();
    }


    private void ChangeSceneToMain()
    {
        string mainScene = Helper.MAIN;
        GetTree().ChangeSceneToFile(mainScene);
    }

    private void OnDefeat()
    {
        AudioGameOver.Play();
        Visible = true;
        Score.Text = GameManager.Instance.Score.ToString();
        //GetTree().Paused = true;
        
    }

    public override void _UnhandledInput(InputEvent @event)
    {
        if(Input.IsActionJustPressed("ui_accept") && GameManager.Instance.playerDefeated)
        {
            string mainScene = Helper.MAIN;
            GetTree().ChangeSceneToFile(mainScene);
        }
        base._UnhandledInput(@event);
    }
}
