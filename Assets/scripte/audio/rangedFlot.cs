using System;
[Serializable]
public struct rangedFlot 
{
    public float _minValue;
    public float _maxValue;

    public rangedFlot(float minValue, float maxValue)
    {
        _minValue = minValue;
        _maxValue = maxValue;
    }
}
