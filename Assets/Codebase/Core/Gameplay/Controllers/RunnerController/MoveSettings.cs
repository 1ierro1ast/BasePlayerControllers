using System;
using UnityEngine;

namespace Codebase.Core.Gameplay.Controllers.RunnerController
{
    [Serializable]
    public class MoveSettings
    {
        [SerializeField] private float _forwardSpeed = 5;
        [SerializeField] private float _strafeSpeed = 10;
        [SerializeField] private float _inputSense = 1.5f;

        [Space] 
        [SerializeField] private LayerMask _groundLayerMask;

        [SerializeField] private Vector3 _offsetFromGround;
        [SerializeField] private float _raycastDistance;

        [Space] 
        [SerializeField] private float _rotationMultiplier;

        [SerializeField] private bool _rotateWhenStrafe;


        public float ForwardSpeed => _forwardSpeed;
        public float StrafeSpeed => _strafeSpeed;
        public float InputSense => _inputSense;
        public LayerMask GroundLayerMask => _groundLayerMask;
        public Vector3 OffsetFromGround => _offsetFromGround;
        public float RaycastDistance => _raycastDistance;
        public float RotationMultiplier => _rotationMultiplier;
        public bool RotateWhenStrafe => _rotateWhenStrafe;
    }
}