using Codebase.Core.Gameplay.Controllers.BoundMoveController;
using Codebase.Core.Gameplay.Controllers.MoveProviders;
using Codebase.Infrastructure.Services;
using Codebase.Infrastructure.Services.Input;
using UnityEngine;

namespace Codebase.Core.Gameplay.Controllers.CharacterThirdPersonController
{
    public class ThirdPersonMover : BoundMover
    {
        [SerializeField] private float _speed;

        private IInputService _inputService;
        private IMoveProvider _moveProvider;
        private Vector3 _direction;

        protected override void OnInitialize()
        {
            base.OnInitialize();
            _inputService = AllServices.Container.Single<IInputService>();
            _moveProvider = GetComponent<IMoveProvider>();
            if(_moveProvider == null) Debug.LogWarning("There is no move providers on object!");
        }

        protected override void OnMove()
        {
            base.OnMove();
            var cachedTransform = transform;
            _direction = (_inputService.VerticalSpeed * cachedTransform.forward +
                          _inputService.HorizontalSpeed * cachedTransform.right).normalized;
            _moveProvider?.Move(_direction, _speed * Time.deltaTime);
        }
    }
}