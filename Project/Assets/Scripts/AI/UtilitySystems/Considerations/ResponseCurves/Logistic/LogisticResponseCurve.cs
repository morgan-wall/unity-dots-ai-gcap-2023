// Copyright (c) 2023 Morgan Wall. All rights reserved.

using Unity.Entities;

namespace AI.UtilitySystems.Considerations.ResponseCurves.Logistic
{
    public struct LogisticResponseCurve : IComponentData
    {
        // Function: y = k / (1 + (1000 * e * m)^(-x + c)) + b
        public float K;
        public float M;
        public float B;
        public float C;
    }
}
