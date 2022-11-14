using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using Raylib_cs;
using System.Reflection;

namespace Andonuts.Audio
{
	public class AudioManager : IDisposable
	{
		public static AudioManager Instance
		{
			get
			{
				if (AudioManager.instance == null)
				{
					AudioManager.instance = new AudioManager();
				}
				return AudioManager.instance;
			}
		}

		private AudioManager()
		{
			
		}

		public virtual void Update()
		{
			//this.UpdateFaders();
			Raylib.UpdateMusicStream(bgm);

			/*if (loop)
            {
				if (musicLoopFile != null)
				{
					if (!Raylib.IsSoundPlaying(bgm2) && !Raylib.IsSoundPlaying(bgm))
					{
						Console.WriteLine("kys");
						Raylib.PlaySound(bgm2);
					}
				}
				else
                {
					if (!Raylib.IsSoundPlaying(bgm))
                    {
						Raylib.PlaySound(bgm);
					}
                }

			}*/

			if (loopStart != 0 && loopEnd != 0)
            {
				if (Raylib.GetMusicTimePlayed(bgm) >= loopEnd)
                {
					Raylib.SeekMusicStream(bgm, loopStart);
                }
            }
			//Console.WriteLine(Raylib.GetMusicTimeLength(bgm));


		}

		public void Dispose()
		{
			

			GC.SuppressFinalize(this);
		}

		public void SetBGM(string name)
		{
			Console.WriteLine($"REQUESTING BGM: {name}");
			musicFile = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "/Resources/Audio/" + name;
			bgm = Raylib.LoadMusicStream(musicFile);
			Raylib.PlayMusicStream(bgm);
			loopStart = 0;loopEnd = 0;
		}

		public void SetBGM(string name,float start,float end)
		{
			Raylib.UnloadMusicStream(bgm); 
			Console.WriteLine($"REQUESTING BGM: {name}");
			musicFile = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "/Resources/Audio/" + name;
			bgm = Raylib.LoadMusicStream(musicFile);
			Raylib.PlayMusicStream(bgm);
			loopStart = start; loopEnd = end;
		}

		public event OnCompleteHandler OnComplete;

		/*public void playSound(string name)
		{
			bgm = Raylib.LoadSound(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "/Resources/Audio/" + name);
			Raylib.PlaySoundMulti(bgm);

		}*/

		private static AudioManager instance;

		private Music bgm;

		private string musicFile;

		private float loopStart = 0;

		private float loopEnd = 0;

		//private bool loop = false;

		public delegate void OnCompleteHandler(Sound sender);

		//private List<AudioManager.Fader> faders;

		//private List<AudioManager.Fader> deadFaders;

		protected Dictionary<int, int> instances;

		//protected Dictionary<int, CarbineSound> sounds;

		protected float musicVolume;

		protected float effectsVolume;

		protected bool disposed;

		/*protected CarbineSound bgmSound;

		private class Fader
		{
			public CarbineSound sound;

			public uint ticks;

			public uint duration;

			public float fromVolume;

			public float toVolume;

			public bool stopOnEnd;
		}*/
	}

}