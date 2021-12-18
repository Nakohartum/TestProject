using System.Threading;
using TestProject.Controllers;
using TestProject.Settings;
using TestProject.Views;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace TestProject
{
    public class Root : MonoBehaviour
    {
        [Header("Place the containters' places")]
        [SerializeField] private Transform[] _placeForContainers;
        
        [Header("Place the scene data (how game should go)")] 
        [SerializeField] private GameData _gameData;

        [Header("Where to show text")] 
        [SerializeField] private TextView _text;

        [Header("Which level to choose")] 
        [SerializeField] private int _levelNumber;
        
        [Header("Restart Button")] 
        [SerializeField] private Button _restartButton;
        
        [Header("Level Background")] 
        [SerializeField] private Image _levelBackground;
        
        [Header("Load Screen")] 
        [SerializeField] private Image _loadScreen;
        
        
        

        private void Start()
        {
            new GameInitializer(_placeForContainers, _gameData, _text, _levelNumber, _restartButton, _levelBackground, _loadScreen);
        }
        
    }
}