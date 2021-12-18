using System;
using UnityEngine;

namespace TestProject.Views
{
    public class ValueView : MonoBehaviour
    {
        [SerializeField] private string _key;
        [SerializeField] private ParticleSystem _particles;
        public string Key => _key;
        public ParticleSystem Particles => _particles;
        private void OnValidate()
        {
            _particles = GetComponent<ParticleSystem>();
        }

        private void Start()
        {
            _particles = GetComponent<ParticleSystem>();
        }

        
        
        
    }
}