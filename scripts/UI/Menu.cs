using beethebee.Scripts.Helpers;
using Godot;
using System;

public partial class Menu : CanvasLayer
{
    private Button startButton;
    private Button quitButton;
    private Button resumeButton;

    private Control vhsViewport;
    private Control pause;

    private object icon; // Não foi usado no script original

    [Export] private AudioStreamPlayer menuSong;
    [Export] private AudioStreamPlayer gameStartedSound;
    [Export] public TextureRect texture;
    public override void _Ready()
    {
        Visible = true; // TODO: HABILITA ISSO

        //// Encontrando botões por nome
        startButton = FindChild("StartGame", true) as Button;
        resumeButton = FindChild("ResumeGame") as Button;
        quitButton = FindChild("QuitGame") as Button;

        // Pegando referências com @onready
        vhsViewport = GetNode("vhs-viewport") as Control;
        pause = GetNode<Control>("pause");

        VerifyButtons();

        if (startButton != null)
            startButton.Pressed += OnStartGamePressed;

        if (quitButton != null)
            quitButton.Pressed += OnQuitGamePressed;

        if (resumeButton != null)
            resumeButton.Pressed += OnResumePressed;

        GetTree().Paused = true;
        menuSong?.Play();
    }

    private void OnStartGamePressed()
    {
        pause.Visible = false;
        GetTree().Paused = false;
        vhsViewport.Visible = true;
        menuSong?.Stop();
        texture.Visible = false;
        gameStartedSound.Play();
    }

    private void OnQuitGamePressed()
    {
        GetTree().Quit();
    }


    private void OnResumePressed()
    {
        OnStartGamePressed(); // It's the same as start
    }

    private void VerifyButtons()
    {
        if (GetTree().Paused)
        {
            startButton.Disabled = true;
            startButton.Visible = false;
            resumeButton.Disabled = false;
            resumeButton.Visible = true;
        }
        else
        {
            startButton.Disabled = false;
            startButton.Visible = true;
            resumeButton.Disabled = true;
            resumeButton.Visible = false;
        }
    }

    private void OnResumeGamePressed()
    {
        menuSong?.Stop();
        pause.Visible = false;
        GetTree().Paused = false;
    }

    public override void _UnhandledInput(InputEvent @event)
    {
        if (GameManager.Instance.playerDefeated) return;
        if (@event.IsActionPressed("ui_cancel"))
        {
            pause.Visible = true;
            GetTree().Paused = true;
            VerifyButtons();
        }
    }
}
