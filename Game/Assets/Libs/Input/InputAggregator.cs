namespace Assets.Libs.Input
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Input = UnityEngine.Input;

    class InputAggregator
    {
        readonly string[] _inputSourcesPrefix;

        public InputAggregator(params string[] schemas)
        {
            _inputSourcesPrefix = (schemas ?? new string[] { "" })
                .Select(s => s ?? "")
                .Distinct()
                .Select(i => string.IsNullOrEmpty(i) ? "" : i + '_')
                .ToArray();
        }

        public bool GetButton(string name)
        {
            return InputSourceNames(name)
                .Any(s => Input.GetButton(s));
        }

        public float GetAxis(string name)
        {
            return InputSourceNames(name).Max(s => Input.GetAxis(s));
        }

        protected IEnumerable<string> InputSourceNames(string input)
        {
            return _inputSourcesPrefix.Select(p => p + input);
        }
    }
}
