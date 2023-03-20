#nullable enable
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;

namespace OUCC.MusicGame.Manager
{
    public class ConfigManager
    {
        public static readonly ConfigManager Instance = new();

        public MusicEntity CurrentMusic { get; private set; }

        public GameConfig GameConfig { get; private set; }

        public ConfigManager()
        {
#if UNITY_EDITOR
            var path = Directory.GetCurrentDirectory();
#else
            var path = Application.persistentDataPath;
#endif
            path += "/game-config/config.json";
            if (File.Exists(path))
            {
                var configStr = File.ReadAllText(path, Encoding.UTF8);
                GameConfig = JsonUtility.FromJson<GameConfig>(configStr);
                GameConfig.Musics = GameConfig.Musics.OrderBy(m => m.Id).ToArray();
                CurrentMusic = GameConfig.Musics.FirstOrDefault() ?? new MusicEntity();
            }
            else
            {
                GameConfig = new GameConfig()
                {
                    Musics = new MusicEntity[] {
                        new(),
                    }
                };
                CurrentMusic = GameConfig.Musics.First();
            }
        }

        public bool TrySetMusic(int id)
        {
            var music = GameConfig.Musics.FirstOrDefault(m => m.Id == id);
            if (music is null)
                return false;

            CurrentMusic = music;
            return true;
        }

        public void Save(bool prettyPrint = false)
        {
#if UNITY_EDITOR
            var path = Directory.GetCurrentDirectory();
#else
            var path = Application.persistentDataPath;
#endif
            path += "/game-config";
            if(!Directory.Exists(path))
                Directory.CreateDirectory(path);
            path += "/config.json";

            var json = JsonUtility.ToJson(GameConfig, prettyPrint);
            File.WriteAllText(path, json, Encoding.UTF8);
        }
    }
}
