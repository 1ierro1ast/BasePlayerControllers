using Codebase.Core.Gameplay.Controllers.BoundMoveController;
using Codebase.Core.Gameplay.Controllers.MoveProviders;
using Codebase.Infrastructure.GameFlow;
using Codebase.Infrastructure.Services;
using Codebase.Infrastructure.Services.Input;
using Codebase.Infrastructure.Services.Settings;
using UnityEngine;

namespace Codebase.Core.Gameplay.Controllers.RunnerController
{
    public class StrafeMover : BoundMover
    {
        private MoveSettings _moveSettings;
        private IEventBus _eventBus;
        private IInputService _inputService;
        private IMoveProvider _moveProvider;

        private bool _mousePressed;
        private bool _isMoving;
        private float _xOffset;

        protected override void OnInitialize()
        {
            _moveSettings = AllServices.Container.Single<GameSettings>().MoveSettings;
            _moveProvider = GetComponent<IMoveProvider>();
            _inputService = AllServices.Container.Single<IInputService>();

            _inputService.LeftMouseButtonDownEvent += InputService_OnLeftMouseButtonDownEvent;
            _inputService.LeftMouseButtonUpEvent += InputService_OnLeftMouseButtonUpEvent;

            _eventBus = AllServices.Container.Single<IEventBus>();

            _eventBus.GamePlayStartEvent += EventBus_OnGamePlayStartEvent;
            _eventBus.LevelFinishedEvent += EventBus_OnLevelFinishedEvent;
        }

        protected override void OnMove()
        {
            if (_mousePressed && _isMoving)
            {
                MoveAnchor();
            }
        }

        private void OnDestroy()
        {
            _inputService.LeftMouseButtonDownEvent -= InputService_OnLeftMouseButtonDownEvent;
            _inputService.LeftMouseButtonUpEvent -= InputService_OnLeftMouseButtonUpEvent;

            _eventBus.GamePlayStartEvent -= EventBus_OnGamePlayStartEvent;
            _eventBus.LevelFinishedEvent -= EventBus_OnLevelFinishedEvent;
        }

        private void InputService_OnLeftMouseButtonUpEvent()
        {
            _mousePressed = false;
        }

        private void InputService_OnLeftMouseButtonDownEvent()
        {
            _mousePressed = true;
            var normalizedAnchorXPosition = transform.localPosition.x / _moveSettings.InputSense;
            _xOffset = normalizedAnchorXPosition - GetPositionWithZeroCenter(_inputService.MousePositionInViewport);
        }

        private void EventBus_OnLevelFinishedEvent()
        {
            _isMoving = false;
        }

        private void EventBus_OnGamePlayStartEvent()
        {
            _isMoving = true;
        }

        private void MoveAnchor()
        {
            var mouseXPositionPercent = (GetPositionWithZeroCenter(_inputService.MousePositionInViewport) + _xOffset) *
                                        _moveSettings.InputSense;
            var localPosition = transform.localPosition;
            var newLocalPosition = new Vector3(mouseXPositionPercent, localPosition.y, localPosition.z);
            _moveProvider.SetLocalPosition(newLocalPosition);
        }

        private float GetPositionWithZeroCenter(Vector3 mousePosition) => (mousePosition.x - 0.5f) * 2;
    }
}