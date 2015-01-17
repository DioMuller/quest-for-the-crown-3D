namespace Assets.Libs.Input
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class InputAggregator
    {
        readonly string[] _inputSourcesPrefix;

        public InputAggregator(IEnumerable<string> schemas)
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
				.Any(s => cInput.GetButton(s));
        }

        public float GetAxis(string name)
        {
            return InputSourceNames(name)
                .Select(s => cInput.GetAxisRaw(s))
                .OrderByDescending(v => Math.Abs(v))
                .FirstOrDefault();
        }

        protected IEnumerable<string> InputSourceNames(string input)
        {
            return _inputSourcesPrefix.Select(p => p + input);
        }
    }
}
