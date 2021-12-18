using System;
using System.Reflection;
using DG.Tweening;
using TestProject.Settings;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace TestProject.Controllers
{
    public class CurrentLevelController
    {
        private GameData _gameData;
        private Button _restartButton;
        private ScreenController _screenController;
        public int CurrentLevel { get; private set; }
        public UnityAction OnLevelChange;
        public UnityAction OnLevelsFinished;

        public CurrentLevelController(int currentLevel, GameData gameData, Button restartButton, ScreenController screenController)
        {
            CurrentLevel = currentLevel - 1;
            _gameData = gameData;
            _restartButton = restartButton;
            _screenController = screenController;
            _restartButton.onClick.AddListener(RestartLevels);
        }

        private void RestartLevels()
        {
            CurrentLevel = 0;
            Sequence sequence = DOTween.Sequence();
            _restartButton.gameObject.SetActive(false);
            sequence.Append(_screenController.BackgroundFadeOut());
            sequence.Append(_screenController.LoaderFadeIn()).OnComplete(CallOnLevelChange);
            sequence.Append(_screenController.LoaderFadeOut());
            
        }

        private void CallOnLevelChange()
        {
            OnLevelChange?.Invoke();
        }


        
        public void ChangeLevel()
        {
            if (_gameData.LevelDatas.Length > CurrentLevel + 1)
            {
                CurrentLevel++;
                CallOnLevelChange();
            }
            else
            {
                OnLevelsFinished?.Invoke();
                EndLevels();
            }
        }

        private void EndLevels()
        {
            _screenController.BackgroundFadeIn();
            _restartButton.gameObject.SetActive(true);
        }
    }
}