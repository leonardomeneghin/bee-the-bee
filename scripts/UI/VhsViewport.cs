using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using beethebee.Scripts.Helpers;
using Godot;
using static System.Formats.Asn1.AsnWriter;

namespace beethebee.Scripts.UI
{
    public partial class VhsViewport : Control
    {
        [Export] Label score;
        [Export] Label life;
        public override void _Ready()
        {
            GameManager.Instance.SetViewportSize(Size);

            GameManager.ScoreChanged += UpdateScore;

            GameManager.LifeChanged += UpdateLife;

            UpdateLife();

            UpdateScore();
            base._Ready();
        }


        public void UpdateScore()
        {
            score.Text = "Score: " + GameManager.Instance.Score.ToString() ;
        }



        public void UpdateLife()
        {
            life.Text = "Life: " + GameManager.Instance.Life.ToString();
        }


    }
}
