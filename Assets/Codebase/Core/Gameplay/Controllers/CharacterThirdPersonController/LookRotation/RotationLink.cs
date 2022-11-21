using System;
using UnityEngine;

namespace Codebase.Core.Gameplay.Controllers.CharacterThirdPersonController.LookRotation
{
    [Serializable]
    public class RotationLink
    {
        [SerializeField] private MouseAxis _mouseAxis;
        [SerializeField] private RotationAxis _rotationAxis;

        public MouseAxis MouseAxis => _mouseAxis;

        public RotationAxis RotationAxis => _rotationAxis;
    }
}