using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Libs.Input
{
    class CharacterInput : InputAggregator
    {
        public CharacterInput(params string[] schemas)
            : base(schemas)
        {
        }

        /// <summary>
        /// Gets the current input movement.
        /// </summary>
        /// <returns></returns>
        public Vector3 GetMovement()
        {
            var mX = GetAxis("Horizontal");
            var mZ = GetAxis("Vertical");
            return new Vector3(mX, 0, mZ);
        }

        /// <summary>
        /// Check if Fire1 is being pressed.
        /// </summary>
        /// <returns></returns>
        public bool Fire1()
        {
            return GetButton("Fire1");
        }
    }
}
