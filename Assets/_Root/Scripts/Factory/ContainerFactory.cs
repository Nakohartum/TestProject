using TestProject.Controllers;
using TestProject.Settings;
using TestProject.Views;
using UnityEngine;

namespace TestProject.Factory
{
    public class ContainerFactory
    {
        private Transform[] _placeForContainers;
        private LevelData _levelData;

        public ContainerFactory(Transform[] placeForContainers)
        {
            _placeForContainers = placeForContainers;
        }

        public ContainerView CreateContainer(GameChecker gameChecker, int currentIndex)
        {
            var view = Object.Instantiate(Resources.Load<ContainerView>("Prefabs/ContainerView"), _placeForContainers[currentIndex]);
            var controller = new ContainerController(view, gameChecker);
            if (_levelData.AnimationEnabled)
            {
                if (view != null)
                {
                    view.GameObject.transform.localScale = Vector3.zero;
                    controller.CreateAnimationPlay();
                }
            }
            return view;
        }

        public void ChangeLevelData(LevelData levelData)
        {
            _levelData = levelData;
        }
    }
}