using System;
using System.Drawing;
using Godot;

namespace beethebee.Scripts.Helpers
{
    public partial class GameManager : Node
    {
        public static GameManager Instance { get; private set; }

        public int Score { get; private set; } = 0;
        public int Life {  get; private set; } = 3;
        
        private int LifeCounter { get; set; } = 0;
        public double SpawnRate { get; private set; } = 3;

        public static event Action OnDefeat;
        public static event Action LifeChanged;
        public static event Action ScoreChanged;
        public bool playerDefeated = false;
        private Vector2 ViewportSize;
        public override void _Ready()
        {
            Instance = this;
        }

        public void SetViewportSize(Vector2 size_viewport)
        {
            ViewportSize = size_viewport;
        }

        public Vector2 GetViewPortSize()
        {
            return ViewportSize;
        }
    

        public void AddScore(int points)
        {
            Score += points;
            AddLife();
            ChangeEnemySpawnRate();
            ScoreChanged.Invoke();
        }
        private void AddLife()
        {
            if (LifeCounter % 50 == 1)
            {
                LifeCounter = 0;
                Life++;
                LifeChanged.Invoke();
            }
        }

        internal void ApplyDamage(int v)
        {
            Life--;
            LifeChanged.Invoke();
            if (Life <= 0)
            {
                TriggerDefeat();
            }
        }

        private void TriggerDefeat()
        {
            playerDefeated = true;
            OnDefeat.Invoke();
        }
        public void ChangeEnemySpawnRate()
        {
            if (SpawnRate <= 3.0)
            {
                SpawnRate = 3;
                return;
            }
            var amount = Score % 30;
            SpawnRate -= 0.2*amount;

        }
    }
}

