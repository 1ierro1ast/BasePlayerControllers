using System;
using Codebase.Infrastructure.GameFlow;
using Codebase.Infrastructure.Services;
using Codebase.Infrastructure.Services.Settings;
using UnityEngine;

namespace Codebase.Core.Gameplay.Controller
{
    public class ForwardMover : MonoBehaviour
    {
        private MoveSettings _moveSettings;
        private IEventBus _eventBus;
        private bool _isMoving;
        
        private void Awake()
        {
            _moveSettings = AllServices.Container.Single<GameSettings>().MoveSettings;
            _eventBus = AllServices.Container.Single<IEventBus>();

            _eventBus.GamePlayStartEvent += EventBus_OnGamePlayStartEvent;
            _eventBus.LevelFinishedEvent += EventBus_OnLevelFinishedEvent;
        }

        private void OnDestroy()
        {
            _eventBus.GamePlayStartEvent -= EventBus_OnGamePlayStartEvent;
            _eventBus.LevelFinishedEvent -= EventBus_OnLevelFinishedEvent;
        }

        private void Update()
        {
            if (!_isMoving) return;
            transform.Translate(Vector3.forward * (_moveSettings.ForwardSpeed * Time.deltaTime));
        }

        private void EventBus_OnLevelFinishedEvent()
        {
            _isMoving = false;
        }

        private void EventBus_OnGamePlayStartEvent()
        {
            _isMoving = true;
        }
    }
}
