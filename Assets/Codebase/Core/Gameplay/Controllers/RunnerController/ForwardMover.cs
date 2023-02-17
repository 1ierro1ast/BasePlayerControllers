using Codebase.Core.Gameplay.Controllers.BoundMoveController;
using Codebase.Core.Gameplay.Controllers.MoveProviders;
using Codebase.Infrastructure.GameFlow.EventBusSystem;
using Codebase.Infrastructure.GameFlow.Events;
using Codebase.Infrastructure.Services;
using Codebase.Infrastructure.Services.Settings;
using UnityEngine;

namespace Codebase.Core.Gameplay.Controllers.RunnerController
{
    public class ForwardMover : BoundMover
    {
        private MoveSettings _moveSettings;
        private IEventBus _eventBus;
        private bool _isMoving;
        private IMoveProvider _moveProvider;
        
        protected override void OnInitialize()
        {
            _moveSettings = AllServices.Container.Single<GameSettings>().MoveSettings;
            _eventBus = AllServices.Container.Single<IEventBus>();
            _moveProvider = GetComponent<IMoveProvider>();

            _eventBus.Subscribe<GameplayStarted>(OnGameplayStarted);
            _eventBus.Subscribe<LevelFinished>(OnLevelFinished);
        }

        protected override void OnMove()
        {
            if (!_isMoving) return;
            //var forwardSpeed = Vector3.forward * (_moveSettings.ForwardSpeed * Time.deltaTime);
            //transform.Translate(forwardSpeed);
            _moveProvider.Move(Vector3.forward, _moveSettings.ForwardSpeed * Time.deltaTime);
        }

        private void OnDestroy()
        {
            _eventBus.Unsubscribe<GameplayStarted>(OnGameplayStarted);
            _eventBus.Unsubscribe<LevelFinished>(OnLevelFinished);
        }

        private void OnLevelFinished()
        {
            _isMoving = false;
        }

        private void OnGameplayStarted()
        {
            _isMoving = true;
        }
    }
}
