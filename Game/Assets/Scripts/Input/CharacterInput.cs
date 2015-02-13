using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Libs.Input
{
    public class CharacterInput : InputAggregator
    {
        static readonly Dictionary<IEnumerable<string>, CharacterInput> _loadedInputs = new Dictionary<IEnumerable<string>, CharacterInput>();
        public readonly bool UseMouse;

        public static CharacterInput FromSchemas(IEnumerable<string> schemas)
        {
            if (!_loadedInputs.ContainsKey(schemas))
				_loadedInputs.Add(schemas, new CharacterInput(schemas));

			return _loadedInputs[schemas];
        }

        private CharacterInput(IEnumerable<string> schemas)
            : base(schemas)
        {
            UseMouse = schemas.Contains("Keyboard");
        }

        /// <summary>
        /// Gets the current input movement.
        /// </summary>
        /// <returns></returns>
        public Vector3 GetMovement()
        {
            var mX = GetAxis("MoveHorizontal");
			var mZ = GetAxis("MoveVertical");
            var input = new Vector3(mX, 0, mZ);

            if( input.sqrMagnitude > 1.0 )
                input.Normalize();

            return input;
        }

		/// <summary>
		/// Gets the current input movement.
		/// </summary>
		/// <returns></returns>
		public Vector3 GetTarget(CameraTrack cameraInfo, GameObject reference)
		{
			var mX = GetAxis("AimHorizontal");
			var mZ = GetAxis("AimVertical");

            var camera = cameraInfo == null?
                null : CameraManager.Instance.GetCamera(cameraInfo.CameraNumber);

            if (UseMouse && camera != null && (UnityEngine.Input.GetMouseButton(0) ||
                                               UnityEngine.Input.GetMouseButton(1)))
            {
                var mouse = UnityEngine.Input.mousePosition;
                mouse.z = (camera.transform.position - reference.transform.position).magnitude;

                var mouseTarget = camera.ScreenToWorldPoint(mouse) - reference.transform.position;
                mouseTarget.y = 0;
                return mouseTarget;
            }

            var input = new Vector3(mX, 0, mZ);
            input.Normalize();

            return input;
		}
    }
}
