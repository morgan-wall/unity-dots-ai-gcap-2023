// Copyright (c) 2023 Morgan Wall. All rights reserved.

using Unity.Entities;

namespace AI.UtilitySystems.Considerations
{
    public struct Consideration : IComponentData
    {
        public float RawInput;
        public float NormalizedInput;
        public float ResponseCurveOutput;
    }
}
