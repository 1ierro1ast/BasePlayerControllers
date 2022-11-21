using Codebase.Infrastructure.Services;
using Codebase.Infrastructure.Services.Input;
using UnityEngine;

namespace Codebase.Core.Gameplay.Controllers.ShootingGalleryController
{
    public class AimRaycasterPoint : MonoBehaviour
    {
        [SerializeField] private float _raycastDistance;
        [SerializeField] private LayerMask _raycastMask;
        private IInputService _inputService;
        
        private void Awake()
        {
            _inputService = AllServices.Container.Single<IInputService>();
        }

        public RaycastResult Raycast()
        {
            Ray ray = _inputService.GetRayByScreenPoint(transform.position);
            RaycastHit hit;
            bool notEmpty = Physics.Raycast(ray, out hit, _raycastDistance, _raycastMask);
            return new RaycastResult{NotEmpty = notEmpty, Hit = hit};
        }
    }
}