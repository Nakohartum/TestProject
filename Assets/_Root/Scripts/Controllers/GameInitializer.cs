using TestProject.Factory;
using TestProject.Settings;
using TestProject.Views;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TestProject.Controllers
{
    public class GameInitializer
    {
        public GameInitializer(Transform[] placeForContainers, GameData gameData, TextView text, int currentLevel, 
            Button restartButton, Image backGround, Image loadScreen)
        {
            var screenController = new ScreenController(backGround, loadScreen);
            var currentLevelController = new CurrentLevelController(currentLevel, gameData, restartButton, screenController);
            var displayTextController = new DisplayTextController(text);
            var gameChecker = new GameChecker(displayTextController, currentLevelController);
            var objectFactory = new ObjectFactory(placeForContainers, gameData, gameChecker);
            objectFactory.CreateObject();
        }
    }
}