// Copyright (c) 2023 Morgan Wall. All rights reserved.

using AI.UtilitySystems.Considerations.Groups;
using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;

namespace AI.UtilitySystems.Considerations.ResponseCurves.Cosine
{
    [BurstCompile]
    [UpdateInGroup(typeof(ConsiderationResponseCurveSystemGroup))]
    public partial struct CosineResponseCurveSystem : ISystem
    {
        public void OnCreate(ref SystemState state) {}
    
        public void OnDestroy(ref SystemState state) {}

        public void OnUpdate(ref SystemState state)
        {
            new CosineResponseCurveJob().ScheduleParallel();
        }
    }
    
    [BurstCompile]
    public partial struct CosineResponseCurveJob : IJobEntity
    {
        private const float MinOutput = 0.0f;
        private const float MaxOutput = 1.0f;
        
        private void Execute(in CosineResponseCurve responseCurve, ref Consideration consideration)
        {
            // Function: y = k * cos(m * (x - c)) + b
            consideration.ResponseCurveOutput = responseCurve.K * math.cos(responseCurve.M * (consideration.NormalizedInput - responseCurve.C)) + responseCurve.B;
            consideration.ResponseCurveOutput = math.clamp(consideration.ResponseCurveOutput, MinOutput, MaxOutput);
        }
    }
}
