using UnityEngine;

namespace Codebase.Core.Gameplay.Controllers.ShootingGalleryController.PlayerAiming
{
    public class Aiming : MonoBehaviour
    {
        [SerializeField] private AimTarget _aimTarget;

        private void LateUpdate()
        {
            transform.LookAt(_aimTarget.Position);
        }
    }
}