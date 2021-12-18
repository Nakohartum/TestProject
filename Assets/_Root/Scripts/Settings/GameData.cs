using UnityEngine;

namespace TestProject.Settings
{
    [CreateAssetMenu(fileName = nameof(GameData), menuName = "Settings/Game/" + nameof(GameData), order = 0)]
    public class GameData : ScriptableObject
    {
        [SerializeField] private LevelData[] _levelDatas;

        public LevelData[] LevelDatas
        {
            get => _levelDatas;
        }
    }
}