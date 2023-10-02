// Copyright (c) 2023 Morgan Wall. All rights reserved.

using System;
using AI.UtilitySystems.Options;
using AI.UtilitySystems.Options.Utils;
using UnityEngine;

namespace AI.Options
{
    [Serializable]
    [CreateAssetMenu(fileName = "Option", menuName = "Options/Option")]
    public sealed class OptionConfig : OptionConfigBase
    {
        #region IOptionKeyProvider

        public override int GetKey()
        {
            var optionRegistry = OptionRegistry.Instance;
            if (optionRegistry != null && optionRegistry.TryGetKey(this, out int key))
            {
                return key;
            }
            return IOptionKeyProvider.InvalidKey;
        }

        #endregion // IOptionKeyProvider
    }
}
