//-------------------------------------------------------------------------------
// <copyright file="NamedArgument.cs" company="Appccelerate">
//   Copyright (c) 2008-2015
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//       http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
// </copyright>
//-------------------------------------------------------------------------------

namespace Appccelerate.CommandLineParser
{
    using System;
    using System.Collections.Generic;

    public class NamedArgument : Argument, INamedArgument
    {
        public NamedArgument(string shortName, Action<string> callback)
        {
            this.Name = shortName;
            this.Callback = callback;
            this.AllowedValues = Optional<IEnumerable<string>>.CreateNotSet();
        }

        public string Name { get; private set; }
        
        public Action<string> Callback { get; private set; }

        public Optional<IEnumerable<string>> AllowedValues { get; set; }
    }

    public class Optional<T>
    {
        private readonly T value;

        public static Optional<T> CreateSet(T value)
        {
            return new Optional<T>(value);
        }

        public static Optional<T> CreateNotSet()
        {
            return new Optional<T>();
        }

        public Optional()
        {
            this.IsSet = false;
        }

        private Optional(T value)
        {
            this.IsSet = true;
            this.value = value;
        }

        public T Value
        {
            get
            {
                if (!this.IsSet)
                {
                    throw new InvalidOperationException("Optional value is not set and cannot be queried.");
                }

                return this.value;
            }
        }

        public bool IsSet
        {
            get;
            private set;
        }
    }
}