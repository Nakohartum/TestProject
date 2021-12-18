using System.Collections.Generic;
using TestProject.Settings;
using TestProject.Views;
using UnityEngine;

namespace TestProject.Factory
{
    public class ValueFactory
    {
        public ValueView CreateValue(LevelData levelData, Transform valuePlacement, List<string> usedKeys)
        {
            ValueView prefab;
            do
            {
                prefab = levelData.LevelObjects.ViewObjects[Random.Range(0,levelData.LevelObjects.ViewObjects.Length)];
            } while (usedKeys.Contains(prefab.Key));
            var view = Object.Instantiate(prefab, valuePlacement);
            view.Particles.Stop();
            return view;
        }
    }
}