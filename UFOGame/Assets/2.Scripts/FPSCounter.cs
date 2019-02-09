using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class FPSCounter : MonoBehaviour
{
    private int _frameCount;
    private float _accumulatedTime;

    const float updateInterval = 0.5f;

    private Text _text;

    private void Start()
    {
        _text = GetComponent<Text>();
        _frameCount = 0;
        _accumulatedTime = 0f;
    }


    private void Update()
    {
        _frameCount++;
        _accumulatedTime += Time.deltaTime;
        if (_accumulatedTime > updateInterval)
        {
            float fps = _frameCount / _accumulatedTime;
            _text.text = fps.ToString("##");
            _frameCount = 0;
            _accumulatedTime -= updateInterval;
        }
    }
}
