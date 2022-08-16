﻿#region license

// Copyright 2021 - 2022 Arcueid Elizabeth D'athemon
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//     http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

#endregion

using System;
using UnityEngine;

namespace CorePlugin.Extensions
{
    [Serializable]
    public struct Range<T> where T : new()
    {
        [SerializeField] private T min;
        [SerializeField] private T max;

        public T Min => min;
        public T Max => max;

        public Range(T minValue, T maxValue)
        {
            min = minValue;
            max = maxValue;
        }

        public Range<T> UpdateMax(T maxValue)
        {
            max = maxValue;
            return this;
        }

        public Range<T> UpdateMin(T minValue)
        {
            min = minValue;
            return this;
        }
    }
}
