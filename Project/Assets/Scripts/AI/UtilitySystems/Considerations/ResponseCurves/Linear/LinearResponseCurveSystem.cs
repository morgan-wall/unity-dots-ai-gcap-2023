// Copyright (c) 2023 Morgan Wall. All rights reserved.

using AI.UtilitySystems.Considerations.Groups;
using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;

namespace AI.UtilitySystems.Considerations.ResponseCurves.Linear
{
    [BurstCompile]
    [UpdateInGroup(typeof(ConsiderationResponseCurveSystemGroup))]
    public partial struct LinearResponseCurveSystem : ISystem
    {
        public void OnCreate(ref SystemState state) {}
    
        public void OnDestroy(ref SystemState state) {}

        public void OnUpdate(ref SystemState state)
        {
            new LinearResponseCurveJob().ScheduleParallel();
        }
    }
    
    [BurstCompile]
    public partial struct LinearResponseCurveJob : IJobEntity
    {
        private const float MinOutput = 0.0f;
        private const float MaxOutput = 1.0f;
        
        private void Execute(in LinearResponseCurve responseCurve, ref Consideration consideration)
        {
            // Function: y = m * (x - c) + b
            consideration.ResponseCurveOutput = responseCurve.M * (consideration.NormalizedInput - responseCurve.C) + responseCurve.B;
            consideration.ResponseCurveOutput = math.clamp(consideration.ResponseCurveOutput, MinOutput, MaxOutput);
        }
    }
}
