// Copyright (c) 2023 Morgan Wall. All rights reserved.

namespace AI.UtilitySystems.Options.Utils
{
    public interface IOptionKeyProvider
    {
        public static int InvalidKey = -1;
        
        int GetKey();
    }
}
