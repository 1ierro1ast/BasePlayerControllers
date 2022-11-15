using UnityEngine;

namespace Codebase.Core.Gameplay.Controllers.ShootingGallery.PlayerAiming
{
    public class AimTarget : MonoBehaviour, IAim
    {
        public Vector3 Position => transform.position;
    }
}