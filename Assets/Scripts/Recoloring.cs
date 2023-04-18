using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Recoloring : MonoBehaviour
{
    //вынести константы цветов наверх 
    
    private const float ColorHueMin=0f;
    private const float ColorHueMax=1f;
    private const float ColorSaturationMin=0.7f;
    private const float ColorSaturationMax=1f;
    private const float ColorValueMin=1f;
    private const float ColorValueMax=1f;
    
    [SerializeField] private float _recoloringDuration = 2f;
    [SerializeField] private float _recoloringDelay = 2f;
    
    private Color _startColor;
    private Color _nextColor;
    private Renderer _renderer;

    private float _recoloringTime;
    private float _delayTime;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        GenerateNextColor();
    }

    private void GenerateNextColor()
    {
        _startColor = _renderer.material.color;
        _nextColor = Random.ColorHSV(ColorHueMin, ColorHueMax, ColorSaturationMin, ColorSaturationMax, ColorValueMin,
            ColorValueMax);
    }

    private void Update()
    {
        if (_delayTime<_recoloringDelay)
        {
            _delayTime += Time.deltaTime;
            return;
        }

        if (_recoloringTime<_recoloringDuration)
        {
            _recoloringTime += Time.deltaTime;
            var progress = _recoloringTime / _recoloringDuration;
            var currentColor=Color.Lerp(_startColor, _nextColor, progress);
            _renderer.material.color = currentColor;
            
        }
        
        else
        {
            _delayTime = 0;
            _recoloringTime=0;
            GenerateNextColor();
        }
    }

}
