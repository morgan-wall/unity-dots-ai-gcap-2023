// Copyright (c) 2023 Morgan Wall. All rights reserved.

using Unity.Entities;

namespace AI.UtilitySystems.Considerations.ResponseCurves.Linear
{
    public struct LinearResponseCurve : IComponentData
    {
        // Function: y = m * (x - c) + b
        public float M;
        public float B;
        public float C;
    }
}
