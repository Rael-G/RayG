﻿using System.Numerics;
using RayG;
using Raylib_cs;

namespace Breakout.Resources
{
    internal struct Particle
    {
        public Vector2 Position;
        public Vector2 Size;
        public Color Color;
        public float Alpha;
        public bool Active;

        public Particle(Vector2 position, Vector2 size, Color color, float alpha)
        {
            Position = position;
            Size = size;
            Color = color;
            Alpha = alpha;
            Active = true;
        }
    }
}
