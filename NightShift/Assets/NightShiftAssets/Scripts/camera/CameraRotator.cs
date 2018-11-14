using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace dallagnol.tom.nightshift
{
    public class CameraRotator : AMouseUpdatable
    {
        //need to follow a player
        [SerializeField]
        [Tooltip("Add the gameobject that the camera will follow in a TPS style")]
        private Transform _target;
        [SerializeField]
        [Tooltip("The space that the camera will have with the  gameobject")]
        private float _spaceBehindObject;
        [SerializeField]
        private Transform _cameraTransform;

        [SerializeField]
        private float _verticalSensitivity;

        [SerializeField]
        private float _horizontalSensitivity;

        [SerializeField]
        private Vector3 _aimOffset;

        private float _angleX;
        private float _angleY;

        /// <summary>
        ///     At each update, the camera will place itself behind the player
        ///     and rotate according the mouse movements
        /// </summary>
        public override void UpdateWithMouseAxis(MouseAxis axis)
        {
            //calculate the camera angle
            _angleX += axis.horizontal * _horizontalSensitivity;
            _angleY += (-axis.vertical) * _verticalSensitivity;

            _angleY = Mathf.Clamp(_angleY, 2f, 80f);

            //execute the move
            Vector3 direction = new Vector3(0, 0, -_spaceBehindObject);
            Quaternion rotation = Quaternion.Euler(_angleY, _angleX, 0);

            _cameraTransform.position = _target.position + rotation * direction;
            //the camera must look at the object after it moves
            _cameraTransform.LookAt(_target.position + _aimOffset);
        }
    }
}
