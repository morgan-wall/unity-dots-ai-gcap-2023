// Copyright (c) 2023 Morgan Wall. All rights reserved.

using System;
using AI.UtilitySystems.Utils;
using Unity.Entities;
using UnityEngine;

namespace AI.UtilitySystems.Considerations.Inputs
{
    [Serializable]
    public abstract class InputConfigBase : ScriptableObject, IDeferredAuthor 
    {
        #region IDeferredAuthor

        public abstract void Bake(IBaker baker, Entity entity);

        #endregion // IDeferredAuthor
    }
}
