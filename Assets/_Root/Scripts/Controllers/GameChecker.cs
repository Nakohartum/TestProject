using System;
using System.Collections.Generic;
using TestProject.Settings;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;


namespace TestProject.Controllers
{
    public class GameChecker
    {
        private string _randomKey;
        private List<string> _keysOnLevel;
        private DisplayTextController _displayTextController;
        private CurrentLevelController _levelController;

        public int CurrentLevel => _levelController.CurrentLevel;

        public GameChecker(DisplayTextController displayTextController, 
            CurrentLevelController currentLevelController)
        {
            _keysOnLevel = new List<string>();
            _displayTextController = displayTextController;
            _levelController = currentLevelController;
        }


        public bool CheckValue(string key)
        {
            return _randomKey == key;
        }
        public void ChangeKey()
        {
            _randomKey = _keysOnLevel[Random.Range(0, _keysOnLevel.Count)];
            _displayTextController.ChangeKey(_randomKey);
        }

        public void AddKey(string key)
        {
            _keysOnLevel.Add(key);
        }


        public void SubscribeToGameFinish(UnityAction OnLevelsFinish)
        {
            _levelController.OnLevelsFinished += OnLevelsFinish;
        }
        
        public void UnSubscribeToGameFinish(UnityAction OnLevelsFinish)
        {
            _levelController.OnLevelsFinished -= OnLevelsFinish;
        }

        
        public void SubscribeToChange(UnityAction OnLevelChangeAction)
        {
            _levelController.OnLevelChange += OnLevelChangeAction;
        }
        
        public void UnSubscribeToChange(UnityAction OnLevelChangeAction)
        {
            _levelController.OnLevelChange -= OnLevelChangeAction;
        }
        
        public void ChangeLevel()
        {
            _keysOnLevel.Clear();
            _levelController.ChangeLevel();
        }
    }
}