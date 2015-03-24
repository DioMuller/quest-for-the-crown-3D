using UnityEngine;
using System.Collections;

public class Firefly : MonoBehaviour 
{
    private float[] _hsl;
    private float _currentValue = 0.0f;
    private float _initialIntensity;
    private Vector3 _basePosition;

    public Light FireflyLight;

    public float HueChange = 1.0f;

    public float IntensityChange = 0.5f;
    public float IntensityCyclesPerSecond = 1.0f;
    public float RandomIntensityPerFrame = 0.3f;

    public Vector3 WanderDistance = new Vector3(10.0f, 0.5f, 10.0f);

    public bool AllowMovement = false;
    public bool AllowColorChange = false;
    public bool AllowIntensityChange = true;

    void Start()
    {
        if( FireflyLight != null )
        {
            #region HSL
            var rgb = FireflyLight.color;

            _hsl = new float[3]{0,0,0};

            var rl = rgb.r;
            var gl = rgb.g;
            var bl = rgb.b;

            var Cmax = Mathf.Max(rl, gl, bl);
            var Cmin = Mathf.Min(rl, gl, bl);
            var delta = Cmax - Cmin;

            // H
            if( Cmax == rl )
            {
                _hsl[0] = 60 * (((gl - bl) / delta) % 6);
            }
            else if( Cmax == gl )
            {
                _hsl[0] = 60 * (((bl - rl) / delta) + 2);
            }
            else if(Cmax == bl)
            {
                _hsl[0] = 60 * (((rl - gl) / delta) + 4);
            }
            else
            {
                Debug.LogError("Invalid Cmax!");
            }

            // L
            _hsl[2] = (Cmax + Cmin) / 2;

            // S
            if( delta == 0.0f )
            {
                _hsl[1] = 0.0f;
            }
            else
            {
                _hsl[1] = delta / (1 - Mathf.Abs(2 * _hsl[2] - 1));
            }
            #endregion HSL

            _initialIntensity = FireflyLight.intensity;
            _basePosition = transform.position;
        }

    }

    void Update()
    {
        if( FireflyLight != null )
        {
            if (AllowColorChange)
            {
                #region Hue Change
                _hsl[0] += (HueChange * Time.deltaTime);
                if (_hsl[0] >= 360.0f) _hsl[0] -= 360.0f;

                var C = (1 - Mathf.Abs(2 * _hsl[2] - 1)) * _hsl[1];
                var X = C * (1 - Mathf.Abs(((_hsl[0] / 60.0f) % 2) - 1));
                var m = _hsl[2] - C / 2.0f;

                var rl = 0.0f;
                var gl = 0.0f;
                var bl = 0.0f;

                if (0.0f <= _hsl[0] && _hsl[0] < 60.0f)
                {
                    rl = C;
                    gl = X;
                    bl = 0.0f;
                }
                else if (60.0f <= _hsl[0] && _hsl[0] < 120.0f)
                {
                    rl = X;
                    gl = C;
                    bl = 0.0f;
                }
                else if (120.0f <= _hsl[0] && _hsl[0] < 180.0f)
                {
                    rl = 0.0f;
                    gl = C;
                    bl = X;
                }
                else if (180.0f <= _hsl[0] && _hsl[0] < 240.0f)
                {
                    rl = 0.0f;
                    gl = X;
                    bl = C;
                }
                else if (240.0f <= _hsl[0] && _hsl[0] < 300.0f)
                {
                    rl = X;
                    gl = 0.0f;
                    bl = C;
                }
                else if (300.0f <= _hsl[0] && _hsl[0] < 360.0f)
                {
                    rl = C;
                    gl = 0.0f;
                    bl = X;
                }

                var newColor = new Color(rl + m, gl + m, bl + m);
                FireflyLight.color = newColor;
                #endregion Hue Change
            }

            if (AllowIntensityChange || AllowMovement)
            {
                _currentValue += (IntensityCyclesPerSecond * Time.deltaTime);

                if (AllowIntensityChange)
                {
                    var random = Random.Range(-RandomIntensityPerFrame, RandomIntensityPerFrame);
                    FireflyLight.intensity = _initialIntensity + Time.timeScale * ((Mathf.Cos(Mathf.PI * _currentValue) * IntensityChange) + random);
                }

                if (AllowMovement)
                {
                    transform.position = _basePosition + new Vector3(WanderDistance.x * Mathf.Sin(_currentValue),
                                                                WanderDistance.y * Mathf.Tan(_currentValue),
                                                                WanderDistance.z * Mathf.Cos(_currentValue));
                }
            }
        }
    }
}
