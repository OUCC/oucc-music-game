#nullable enable
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;

namespace OUCC.MusicGame.Manager
{
    /// <summary>
    /// 現在の設定を示します
    /// </summary>
    public class ConfigManager
    {
        public static readonly ConfigManager Instance = new();

        /// <summary>
        /// 現在選択されている音楽
        /// </summary>
        public MusicEntity CurrentMusic { get; private set; }

        /// <summary>
        /// 1秒あたりに進む速度
        /// </summary>
        public float Speed { get; set; }

        /// <summary>
        /// ゲーム全体の情報
        /// </summary>
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

        /// <summary>
        /// 音楽IDをセットしようとします
        /// </summary>
        /// <returns>該当する音楽がないときfalse</returns>
        public bool TrySetMusic(int id)
        {
            var music = GameConfig.Musics.FirstOrDefault(m => m.Id == id);
            if (music is null)
                return false;

            CurrentMusic = music;
            return true;
        }

        /// <summary>
        /// データを保存する
        /// </summary>
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
