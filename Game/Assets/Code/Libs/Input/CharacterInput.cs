using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Libs.Input
{
    class CharacterInput : InputAggregator
    {
        static readonly Dictionary<IEnumerable<string>, CharacterInput> _loadedInputs = new Dictionary<IEnumerable<string>, CharacterInput>();

        public static CharacterInput FromSchemas(IEnumerable<string> schemas)
        {
            if (!_loadedInputs.ContainsKey(schemas))
                _loadedInputs.Add(schemas, new CharacterInput(schemas));

            return _loadedInputs[schemas];
        }

        private CharacterInput(IEnumerable<string> schemas)
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
    }
}
