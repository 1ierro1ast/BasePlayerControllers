using Codebase.Infrastructure.Services;
using Codebase.Infrastructure.Services.Input;
using UnityEngine;

namespace Codebase.Core.Gameplay.Controllers.CharacterThirdPersonController.LookRotation
{
    [RequireComponent(typeof(MouseLookRotation))]
    public class ObjectRotationToMouseLink : MonoBehaviour, IObjectRotation
    {
        [SerializeField] private RotationLink _rotationLink;
        [SerializeField] private float _sensitivity;
        [SerializeField] private bool _clampRotation;
        [SerializeField] private float _rotationLimit;
        
        private float _axisRotation;
        private IInputService _inputService;

        private void Awake()
        {
            _inputService = AllServices.Container.Single<IInputService>();
        }

        public Quaternion GetRotation()
        {
            _axisRotation += GetInputAxis() * _sensitivity;
            if(_clampRotation) _axisRotation = Mathf.Clamp(_axisRotation, -_rotationLimit, _rotationLimit);
            var resultRotation = Quaternion.AngleAxis(_axisRotation, GetRotationAxis());
            return resultRotation;
        }

        private Vector3 GetRotationAxis()
        {
            switch (_rotationLink.RotationAxis)
            {
                case RotationAxis.X:
                    return Vector3.up;
                case RotationAxis.Y:
                    return Vector3.left;
                case RotationAxis.Z:
                    return Vector3.forward;
                default: return Vector3.zero;
            }
        }

        private float GetInputAxis()
        {
            switch (_rotationLink.MouseAxis)
            {
                case MouseAxis.X:
                    return _inputService.MouseX;
                case MouseAxis.Y:
                    return _inputService.MouseY;
                default: return 0;
            }
        }
    }
}