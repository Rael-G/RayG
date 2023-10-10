﻿using RayG;
using Raylib_cs;
using System.Numerics;

namespace Breakout.GameLogic.States
{
    internal class StartState : GameObject
    {
        GameStateRef State { get; set; }

        const string breakoutMsg = "Breakout";
        const string startMsg = "Start";
        const string highScoreMsg = "High Score";
        const int breakoutHeight = 150;
        const int optionsHeight = 50;

        int breakoutWidth;
        int startWidth;
        int highScoreWidth;
        Vector2 breakoutPosition;
        Vector2 startPosition;
        Vector2 highScorePosition;

        Color startColor = Color.BLUE;
        Color highScoreColor = Color.WHITE;

        public StartState(GameStateRef state) 
        {
            State = state;
        }

        public override void Start()
        {
            breakoutWidth = Raylib.MeasureText(breakoutMsg, breakoutHeight);
            startWidth = Raylib.MeasureText(startMsg, optionsHeight);
            highScoreWidth = Raylib.MeasureText(highScoreMsg, optionsHeight);

            breakoutPosition = new(Window.Width / 2 - breakoutWidth / 2, Window.Height / 2 - breakoutHeight);
            startPosition = new(Window.Width / 2 - startWidth / 2, Window.Height - optionsHeight * 4);
            highScorePosition = new(Window.Width / 2 - highScoreWidth / 2, Window.Height - optionsHeight * 2);
            base.Start();
        }

        public override void Update()
        {
            if(Raylib.IsKeyPressed(KeyboardKey.KEY_UP))
            {
                startColor = Color.BLUE;
                highScoreColor = Color.WHITE;
            }
            else if(Raylib.IsKeyPressed(KeyboardKey.KEY_DOWN))
            {
                startColor = Color.WHITE;
                highScoreColor = Color.BLUE;
            }
            base.Update();
        }

        public override void Canvas()
        {
            Raylib.DrawText(breakoutMsg, (int)breakoutPosition.X, (int)breakoutPosition.Y, breakoutHeight, Color.WHITE);
            Raylib.DrawText(startMsg, (int)startPosition.X, (int)startPosition.Y, optionsHeight, startColor);
            Raylib.DrawText(highScoreMsg, (int)highScorePosition.X, (int)highScorePosition.Y, optionsHeight, highScoreColor);
            base.Canvas();
        }
    }
}
