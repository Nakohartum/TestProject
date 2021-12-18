using System;
using TestProject.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace TestProject.Views
{
    public class ContainerView : MonoBehaviour, IContainerView
    {
        [field: SerializeField] public Button ContainerButton { get; private set; }
        [field: SerializeField] public Transform ValueContainer { get; private set; }
        [field: SerializeField] public Image Background { get; private set; }
        [field: SerializeField] public float AnimationDuration { get; private set; }
        public GameObject GameObject => gameObject;
        
    }
}