using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace TestProject.Interfaces
{
    public interface IContainerView
    {
        Button ContainerButton { get; }
        Image Background { get; }
        GameObject GameObject { get; }

        float AnimationDuration { get; }
    }
}