// Copyright (c) 2023 Morgan Wall. All rights reserved.

using AI.UtilitySystems.Considerations.Groups;
using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;

namespace AI.UtilitySystems.Considerations.ResponseCurves.Exponential
{
    [BurstCompile]
    [UpdateInGroup(typeof(ConsiderationResponseCurveSystemGroup))]
    public partial struct ExponentialResponseCurveSystem : ISystem
    {
        public void OnCreate(ref SystemState state) {}
    
        public void OnDestroy(ref SystemState state) {}

        public void OnUpdate(ref SystemState state)
        {
            new ExponentialResponseCurveJob().ScheduleParallel();
        }
    }
    
    [BurstCompile]
    public partial struct ExponentialResponseCurveJob : IJobEntity
    {
        private const float MinOutput = 0.0f;
        private const float MaxOutput = 1.0f;
        
        private void Execute(in ExponentialResponseCurve responseCurve, ref Consideration consideration)
        {
            // Function: y = m^(k * (x - c)) + b
            consideration.ResponseCurveOutput = math.pow(responseCurve.M, responseCurve.K * (consideration.NormalizedInput - responseCurve.C)) + responseCurve.B;
            consideration.ResponseCurveOutput = math.clamp(consideration.ResponseCurveOutput, MinOutput, MaxOutput);
        }
    }
}
