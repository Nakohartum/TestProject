using TestProject.Views;
using UnityEngine;

namespace TestProject.Settings
{
    [CreateAssetMenu(fileName = nameof(LevelObjectData), menuName = "Settings/Game/" + nameof(LevelObjectData), order = 0)]
    public class LevelObjectData : ScriptableObject
    {
        [SerializeField] private ValueView[] _viewObjects;

        public ValueView[] ViewObjects => _viewObjects;
        
        
    }
}