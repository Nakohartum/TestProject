using System.Collections.Generic;
using DG.Tweening;
using TestProject.Controllers;
using TestProject.Settings;
using UnityEngine;

namespace TestProject.Factory
{
    public class ObjectFactory
    {
        private ContainerFactory _containerFactory;
        private ValueFactory _valueFactory;
        private GameData _gameData;
        private GameChecker _gameChecker;
        private List<string> _usedKeys;

        public ObjectFactory(Transform[] placeForContainers, GameData gameData, GameChecker gameChecker)
        {
            _gameChecker = gameChecker;
            _gameData = gameData;
            _containerFactory = new ContainerFactory(placeForContainers);
            _valueFactory = new ValueFactory();
            _usedKeys = new List<string>();
            _gameChecker.SubscribeToChange(CreateObject);
            _gameChecker.SubscribeToGameFinish(ClearUsedKeysList);
        }

        private void ClearUsedKeysList()
        {
            _usedKeys.Clear();
        }


        public void CreateObject()
        {
            _containerFactory.ChangeLevelData(_gameData.LevelDatas[_gameChecker.CurrentLevel]);
            for (int i = 0; i < _gameData.LevelDatas[_gameChecker.CurrentLevel].RowsCount; i++)
            {
                for (int j = 0; j < _gameData.LevelDatas[_gameChecker.CurrentLevel].ColumnsCount; j++)
                {
                    var container = _containerFactory.CreateContainer(_gameChecker, i);
                    var value = _valueFactory.CreateValue(_gameData.LevelDatas[_gameChecker.CurrentLevel], container.ValueContainer, _usedKeys);
                    _gameChecker.AddKey(value.Key);
                    _usedKeys.Add(value.Key);
                }
            }
            _gameChecker.ChangeKey();
        }

    }
}