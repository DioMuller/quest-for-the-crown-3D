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
            return new Vector3(mX, 0, mZ);
        }

		/// <summary>
		/// Gets the current input movement.
		/// </summary>
		/// <returns></returns>
		public Vector3 GetTarget(CameraTrack cameraInfo)
		{
			var mX = GetAxis("AimHorizontal");
			var mZ = GetAxis("AimVertical");

            var camera = cameraInfo == null?
                null : CameraManager.Instance.GetCamera(cameraInfo.CameraNumber);

            if (UseMouse && camera != null)
            {
                var mouse = UnityEngine.Input.mousePosition;
                mouse.z = (camera.transform.position - cameraInfo.gameObject.transform.position).magnitude;

                var mouseTarget = camera.ScreenToWorldPoint(mouse) - cameraInfo.gameObject.transform.position;
                //Debug.Log(mouse.z);
                mouseTarget.y = 0;
                //Vector3.Normalize(mouseTarget);
                return mouseTarget;
            }

			return new Vector3(mX, 0, mZ);
		}
    }
}
