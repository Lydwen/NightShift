using UnityEngine;
using System.Collections;
namespace dallagnol.tom.nightshift
{
    public class CharacterController : AMouseUpdatable
    {
        [SerializeField]
        private CameraRotator _cameraRotator;
        private Transform _cameraTransform;
        [SerializeField]
        private SimpleMovement _simpleMovement;

        /// <summary>
        ///     Update the current character according to the mouse input
        /// </summary>
        public override void UpdateWithMouseAxis(MouseAxis mouseAxis)
        {
            _cameraRotator.UpdateWithMouseAxis(mouseAxis);
            _simpleMovement.UpdateMovement(_cameraTransform.forward, _cameraTransform.right);
        }

        private void OnValidate()
        {
            if(_cameraRotator != null)
            {
                _cameraTransform = _cameraRotator.transform;
            }
        }
    }
}
