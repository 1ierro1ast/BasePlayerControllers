using System;
using UnityEngine;

namespace Codebase.Core.Gameplay.Controller
{
    [Serializable]
    public class MoveSettings
    {
        [SerializeField] private float _forwardSpeed = 5;
        [SerializeField] private float _strafeSpeed = 10;
        [SerializeField] private float _anchorMaxDeviation = 1.5f;
        
        public float ForwardSpeed => _forwardSpeed;
        public float StrafeSpeed => _strafeSpeed;
        public float AnchorMaxDeviation => _anchorMaxDeviation;
    }
}