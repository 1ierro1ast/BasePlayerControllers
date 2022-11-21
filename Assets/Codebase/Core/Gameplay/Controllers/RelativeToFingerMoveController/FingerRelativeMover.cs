using Codebase.Core.Gameplay.Controllers.BoundMoveController;
using Codebase.Infrastructure.Services;
using Codebase.Infrastructure.Services.Input;
using UnityEngine;

namespace Codebase.Core.Gameplay.Controllers.RelativeToFingerMoveController
{
    public class FingerRelativeMover : BoundMover
    {
        private IInputService _inputService;
        private Vector3 _startPosition;
        private Vector3 _delta;
        private bool _mousePressed;

        protected override void OnInitialize()
        {
            base.OnInitialize();
            _inputService = AllServices.Container.Single<IInputService>();
            
            _inputService.LeftMouseButtonDownEvent += InputService_OnLeftMouseButtonDownEvent;
            _inputService.LeftMouseButtonUpEvent += InputService_OnLeftMouseButtonUpEvent;
        }

        private void OnDestroy()
        {
            _inputService.LeftMouseButtonDownEvent -= InputService_OnLeftMouseButtonDownEvent;
            _inputService.LeftMouseButtonUpEvent -= InputService_OnLeftMouseButtonUpEvent;
        }

        private void InputService_OnLeftMouseButtonUpEvent()
        {
            _mousePressed = false;
        }

        private void InputService_OnLeftMouseButtonDownEvent()
        {
            _startPosition = _inputService.MousePositionInScreen;
            _delta = transform.position - _startPosition;
            _mousePressed = true;
        }

        protected override void OnMove()
        {
            if (!_mousePressed) return;

            transform.position = _inputService.MousePositionInScreen + _delta;
        }
    }
}