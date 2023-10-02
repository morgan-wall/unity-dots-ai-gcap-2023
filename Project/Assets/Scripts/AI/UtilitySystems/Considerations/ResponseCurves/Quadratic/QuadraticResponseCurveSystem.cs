// Copyright (c) 2023 Morgan Wall. All rights reserved.

using AI.UtilitySystems.Considerations.Groups;
using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;

namespace AI.UtilitySystems.Considerations.ResponseCurves.Quadratic
{
    [BurstCompile]
    [UpdateInGroup(typeof(ConsiderationResponseCurveSystemGroup))]
    public partial struct QuadraticResponseCurveSystem : ISystem
    {
        public void OnCreate(ref SystemState state) {}
    
        public void OnDestroy(ref SystemState state) {}

        public void OnUpdate(ref SystemState state)
        {
            new QuadraticResponseCurveJob().ScheduleParallel();
        }
    }
    
    [BurstCompile]
    public partial struct QuadraticResponseCurveJob : IJobEntity
    {
        private const float MinOutput = 0.0f;
        private const float MaxOutput = 1.0f;
        
        private void Execute(in QuadraticResponseCurve responseCurve, ref Consideration consideration)
        {
            // Function: y = m * (x - c)^k + b
            consideration.ResponseCurveOutput = responseCurve.M * math.pow(consideration.NormalizedInput - responseCurve.C, responseCurve.K) + responseCurve.B;
            consideration.ResponseCurveOutput = math.clamp(consideration.ResponseCurveOutput, MinOutput, MaxOutput);
        }
    }
}
