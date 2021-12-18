using DG.Tweening;
using UnityEngine.UI;

namespace TestProject.Controllers
{
    public class ScreenController
    {
        private Image _backround;
        private Image _loadScreen;

        public ScreenController(Image backround, Image loadScreen)
        {
            _backround = backround;
            _loadScreen = loadScreen;
        }
        
        public Tween LoaderFadeIn()
        {
            _loadScreen.gameObject.SetActive(true);
            return Fade(_loadScreen, 1, 1f);
        }

        public Tween LoaderFadeOut()
        {
            return Fade(_loadScreen, 0, 1f).OnComplete(DeactivateLoadScreen);
        }

        private void DeactivateLoadScreen()
        {
            _loadScreen.gameObject.SetActive(false);
        }

        private void ActivateLoadScreen()
        {
            _loadScreen.gameObject.SetActive(true);
        }
        
        public void BackgroundFadeIn()
        {
            _backround.gameObject.SetActive(true);
            Fade(_backround, 1, 0.1f);
        }

        public Tween BackgroundFadeOut()
        {
            return Fade(_backround, 0, 0.1f).OnComplete(DeactivateBackground);
        }
        
        
        private void DeactivateBackground()
        {
            _backround.gameObject.SetActive(false);
        }

        private void ActivateBackground()
        {
            _loadScreen.gameObject.SetActive(true);
        }
        private Tween Fade(Image image, float value, float time)
        {
            var tween = image.DOFade(value, time);
            return tween;
        }
    }
}