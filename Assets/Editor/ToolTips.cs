using OUCC.MusicGame.Manager;
using UnityEditor;

namespace OUCC.MusicGame.Assets.Editor
{
    public static class ToolTips
    {
        [MenuItem("Tools/Generate JSON")]
        public static void GenerateEmptyJson()
        {
            ConfigManager.Instance.Save(true);
        }
    }
}
