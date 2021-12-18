using System;
using DG.Tweening;
using TestProject.Views;
using TMPro;
using UnityEngine;

namespace TestProject.Controllers
{
    public class DisplayTextController
    {
        private string _key;
        private TextView _text;
        private float _animationDuration;
        private Tweener _fadeTween;

        public DisplayTextController(TextView text)
        {
            _text = text;
            _animationDuration = _text.AnimationDuration;
        }

        public void ChangeKey(string key)
        {
            _key = key;
            ChangeText();
        }

        private void ChangeText()
        {
            FadeOut();
            _text.Text.text = $"Find {_key}";
            FadeIn();
        }
        
        public void FadeOut()
        {
            if (CheckTween())
            {
                _fadeTween.Kill(true);
            }
            Fade(0f, 0f);
        }
        
        public void FadeIn()
        {
            if (CheckTween())
            {
                _fadeTween.Kill(true);
                _fadeTween = null;
            }

            Fade(1f, _animationDuration);
        }

        private bool CheckTween()
        {
            return _fadeTween != null;
        }
        
        private void Fade(float endValue, float animationDuration)
        {
            _fadeTween = _text.Text.DOFade(endValue, animationDuration);
        }
    }
}