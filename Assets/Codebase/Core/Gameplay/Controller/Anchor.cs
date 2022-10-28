using Codebase.Infrastructure.GameFlow;
using Codebase.Infrastructure.Services;
using Codebase.Infrastructure.Services.Input;
using Codebase.Infrastructure.Services.Settings;
using UnityEngine;

namespace Codebase.Core.Gameplay.Controller
{
    public class Anchor : MonoBehaviour
    {
        private bool _mousePressed;
        private IInputService _inputService;
        private MoveSettings _moveSettings;
        private IEventBus _eventBus;
        private bool _isMoving;
        private float _xOffset;

        private void EventBus_OnLevelFinishedEvent()
        {
            _isMoving = false;
        }

        private void EventBus_OnGamePlayStartEvent()
        {
            _isMoving = true;
        }

        private void Awake()
        {
            _moveSettings = AllServices.Container.Single<GameSettings>().MoveSettings;
            
            _inputService = AllServices.Container.Single<IInputService>();

            _inputService.LeftMouseButtonDownEvent += InputService_OnLeftMouseButtonDownEvent;
            _inputService.LeftMouseButtonUpEvent += InputService_OnLeftMouseButtonUpEvent;

            _eventBus = AllServices.Container.Single<IEventBus>();
            
            _eventBus.GamePlayStartEvent += EventBus_OnGamePlayStartEvent;
            _eventBus.LevelFinishedEvent += EventBus_OnLevelFinishedEvent;
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
            var normalizedAnchorXPosition = transform.localPosition.x / _moveSettings.AnchorMaxDeviation;
            _xOffset = normalizedAnchorXPosition - GetPercentFromViewPort(_inputService.MousePositionInViewport);
        }

        private void Update()
        {
            if (_mousePressed && _isMoving)
            {
                MoveAnchor();
            }
        }

        private void MoveAnchor()
        {
            var mouseXPositionPercent = (GetPercentFromViewPort(_inputService.MousePositionInViewport) + _xOffset) *
                                        _moveSettings.AnchorMaxDeviation;
            transform.localPosition = new Vector3(mouseXPositionPercent, 0, 0);
        }

        private float GetPercentFromViewPort(Vector3 mousePosition) => (mousePosition.x - 0.5f) * 2;
    }
}