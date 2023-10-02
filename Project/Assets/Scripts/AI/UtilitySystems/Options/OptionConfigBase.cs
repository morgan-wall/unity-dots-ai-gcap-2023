// Copyright (c) 2023 Morgan Wall. All rights reserved.

using System;
using AI.UtilitySystems.Options.Utils;
using UnityEngine;

namespace AI.UtilitySystems.Options
{
    [Serializable]
    public abstract class OptionConfigBase : ScriptableObject, IOptionKeyProvider
    {
        #region IOptionKeyProvider

        public abstract int GetKey();

        #endregion // IOptionKeyProvider
    }
}
