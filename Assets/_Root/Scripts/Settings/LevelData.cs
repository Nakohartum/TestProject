using UnityEngine;

namespace TestProject.Settings
{
    [CreateAssetMenu(fileName = nameof(LevelData), menuName = "Settings/Game/" + nameof(LevelData), order = 0)]
    public class LevelData : ScriptableObject
    {
        [SerializeField] private int _columnsCount;
        [SerializeField] private int _rowsCount;
        [SerializeField] private LevelObjectData _object;
        [SerializeField] private bool _animationEnabled;
        
        public LevelObjectData LevelObjects => _object;
        public int ColumnsCount => _columnsCount;
        public int RowsCount => _rowsCount;

        public bool AnimationEnabled => _animationEnabled;
    }
}