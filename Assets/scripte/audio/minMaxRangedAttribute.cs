using System;

public class minMaxRangedAttribute: Attribute
{
    public minMaxRangedAttribute(float min, float max)
    {
        Min = min;
        Max = max;
    }

    public float Min { get; }
    public float Max { get; }
}
