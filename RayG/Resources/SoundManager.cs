﻿using Raylib_cs;

namespace RayG
{
    public class SoundManager : ResourceManager<Sound>
    {
        public SoundManager(string path, string[] names) : base(path, names) { }

        public void PlaySound(string name, float volume = 1f, float pitch = 1f)
        {
            var sound = Resources[name];
            Raylib.SetSoundVolume(sound, volume);
            Raylib.SetSoundPitch(sound, pitch);
            Raylib.PlaySound(Resources[name]);
        }

        protected override void Load()
        { 
            foreach (var name in Names)
            {
                var sound = Raylib.LoadSound(Path + name);

                var splitedName = name.Split('.');
                Resources.Add(splitedName[0], sound);
            }
        }

        protected override void Unload()
        {
            foreach (var sound in Resources)
            {
                Raylib.UnloadSound(sound.Value);
            }
            Resources.Clear();
        }
    }
}