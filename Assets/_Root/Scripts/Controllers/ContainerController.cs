using System;
using DG.Tweening;
using TestProject.Interfaces;
using TestProject.Views;
using UnityEngine;
using Object = UnityEngine.Object;

namespace TestProject.Controllers
{
    public class ContainerController : IDisposable
    {
        private IContainerView _containerView;
        private GameChecker _gameChecker;
        public ContainerController(ContainerView containerView, GameChecker gameChecker)
        {
            _containerView = containerView;
            _containerView.ContainerButton.onClick.AddListener(CheckValue);
            _gameChecker = gameChecker;
            _gameChecker.SubscribeToChange(OnLevelChange);
            _gameChecker.SubscribeToGameFinish(OnLevelChange);
        }

        private void CheckValue()
        {
            var valueView = _containerView.GameObject.GetComponentInChildren<ValueView>();
            if (_gameChecker.CheckValue(valueView.Key))
            {
                PlayCorrectAnswerAnimation(valueView, ChangeLevel);
            }
            else
            {
                WrongAsnwerAnimationPlay(valueView);
            }
        }

        private void WrongAsnwerAnimationPlay(ValueView valueView)
        {
            if (_containerView != null)
            {
                Sequence sequence = DOTween.Sequence();
                sequence.Append(valueView.transform.DOLocalMoveX(20f, 0.1f));
                sequence.Append(valueView.transform.DOLocalMoveX(-20f, 0.1f));
                sequence.Append(valueView.transform.DOLocalMoveX(0f, 0.1f));
            }
            
        }

        private void PlayCorrectAnswerAnimation(ValueView valueView, TweenCallback OnAnimationComplete)
        {
            valueView.Particles.Play();
            CorrectAnswerAnimation(valueView, OnAnimationComplete);
        }
        
        private void CorrectAnswerAnimation(ValueView valueView, TweenCallback OnAnimationComplete)
        {
            if (_containerView != null)
            {
                Sequence sequence = DOTween.Sequence();
                sequence.Append(valueView.transform.DOScale(0.8f, 0.1f));
                sequence.Append(valueView.transform.DOScale(1.2f, 0.1f));
                sequence.Append(valueView.transform.DOScale(1.0f, 0.1f));
                sequence.AppendInterval(1f);
                sequence.OnKill(OnAnimationComplete);
            }
        }
        
        public void CreateAnimationPlay()
        {
            if (_containerView != null)
            {
                _containerView.GameObject.transform.DOScale(Vector3.one, _containerView.AnimationDuration);
            }
            
        }
        
        private void OnLevelChange()
        {
            Object.Destroy(_containerView.GameObject);
            Dispose();
        }

        private void ChangeLevel()
        {
            _gameChecker.ChangeLevel();
        }

        public void Dispose()
        {
            _containerView.ContainerButton.onClick.RemoveAllListeners();
            _gameChecker.UnSubscribeToChange(OnLevelChange);
            _gameChecker.UnSubscribeToGameFinish(OnLevelChange);
        }
    }
}