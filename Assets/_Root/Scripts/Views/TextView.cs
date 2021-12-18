using TMPro;
using UnityEngine;

namespace TestProject.Views
{
    public class TextView : MonoBehaviour
    {
        [field: SerializeField] public float AnimationDuration { get; private set; }
        [field: SerializeField] public TMP_Text Text { get; private set; }
    }
}