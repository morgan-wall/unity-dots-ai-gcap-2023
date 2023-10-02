// Copyright (c) 2023 Morgan Wall. All rights reserved.

using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

namespace Examples.Jobs
{
    [BurstCompile]
    public struct QuadraticFunctionEvaluatorJob : IJobParallelFor
    {
        [ReadOnly] public float A;
        [ReadOnly] public float B;
        [ReadOnly] public float C;
        [ReadOnly] public NativeArray<float> X;
        [WriteOnly] public NativeArray<float> Y;
    
        public void Execute(int index)
        {
            // Equation: y = ax^2 + bx + c
            Y[index] = A * math.pow(X[index], 2) + B * X[index] + C;
        }
    }
    
    public class QuadraticFunctionEvaluatorDriver : MonoBehaviour
    {
        [SerializeField]
        private float _a = 1.0f;
    
        [SerializeField]
        private float _b = 1.0f;
    
        [SerializeField]
        private float _c = 0.0f;
    
        [SerializeField]
        private int _samples = 10000;
    
        [SerializeField]
        private float _minX = 0.0f;
    
        [SerializeField]
        private float _maxX = 1.0f;
    
        private void Update()
        {
            NativeArray<float> x = new NativeArray<float>(_samples, Allocator.TempJob);
            NativeArray<float> y = new NativeArray<float>(_samples, Allocator.TempJob);
    
            float step = (_maxX - _minX) / _samples;
            for (int i = 0; i < _samples; ++i)
            {
                x[i] = _minX + (i + 1) * step;
                y[i] = 0.0f;
            }
            
            QuadraticFunctionEvaluatorJob job = new QuadraticFunctionEvaluatorJob();
            job.A = _a;
            job.B = _b;
            job.C = _c;
            job.X = x;
            job.Y = y;
    
            const int innerLoopBatchCount = 1;
            JobHandle jobHandle = job.Schedule(x.Length, innerLoopBatchCount);
            jobHandle.Complete();
    
            for (int i = 0; i < _samples; ++i)
            {
                Debug.Log($"X: {x[i]} Y: {y[i]}");
            }
    
            x.Dispose();
            y.Dispose();
        }
    }
}
