// Copyright (c) 2023 Morgan Wall. All rights reserved.

using AI.UtilitySystems.Considerations.Groups;
using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;

namespace AI.UtilitySystems.Considerations.ResponseCurves.Logistic
{
    [BurstCompile]
    [UpdateInGroup(typeof(ConsiderationResponseCurveSystemGroup))]
    public partial struct LogisticResponseCurveSystem : ISystem
    {
        public void OnCreate(ref SystemState state) {}
    
        public void OnDestroy(ref SystemState state) {}

        public void OnUpdate(ref SystemState state)
        {
            new LogisticResponseCurveJob().ScheduleParallel();
        }
    }
    
    [BurstCompile]
    public partial struct LogisticResponseCurveJob : IJobEntity
    {
        private const float MinOutput = 0.0f;
        private const float MaxOutput = 1.0f;
        
        private void Execute(in LogisticResponseCurve responseCurve, ref Consideration consideration)
        {
            // Function: y = k / (1 + (1000 * e * m)^(-x + c)) + b
            consideration.ResponseCurveOutput = responseCurve.K / (1.0f + math.pow(1000.0f * math.E * responseCurve.M, -consideration.NormalizedInput + responseCurve.C)) + responseCurve.B;
            consideration.ResponseCurveOutput = math.clamp(consideration.ResponseCurveOutput, MinOutput, MaxOutput);
        }
    }
}
