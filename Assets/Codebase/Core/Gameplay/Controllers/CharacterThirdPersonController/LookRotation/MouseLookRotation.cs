using UnityEngine;

namespace Codebase.Core.Gameplay.Controllers.CharacterThirdPersonController.LookRotation
{
    public class MouseLookRotation : MonoBehaviour
    {
        private ObjectRotationToMouseLink[] _rotationToMouseLinks;

        private void Update()
        {
            foreach (var rotationToMouseLink in _rotationToMouseLinks)
            {
                transform.localRotation = rotationToMouseLink.GetRotation();
            }
        }
    }
}