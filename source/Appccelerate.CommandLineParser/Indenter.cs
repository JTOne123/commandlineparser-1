﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Indenter.cs" company="Appccelerate">
//   Copyright (c) 2008-2018 Appccelerate
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
// --------------------------------------------------------------------------------------------------------------------

namespace Appccelerate.CommandLineParser
{
    using System;

    /// <summary>
    /// Use this class to indent lines of text.
    /// </summary>
    /// <example>
    /// Writing the parsing error with usage to the console - with indented options:
    ///     Usage usage = new UsageComposer(configuration).Compose();
    ///     Console.WriteLine(parseResult.Message);
    ///     Console.WriteLine("usage:" + usage.Arguments);
    ///     Console.WriteLine("options");
    ///     Console.WriteLine(usage.Options.IndentBy(4));
    ///     Console.WriteLine();
    /// </example>
    public static class Indenter
    {
        public static string IndentBy(this string lines, int indentation)
        {
            CheckLinesNotNull(lines);

            if (lines.Length == 0)
            {
                return string.Empty;
            }

            string spaces = string.Empty.PadLeft(indentation);

            return spaces + lines.Replace(Environment.NewLine, string.Concat(Environment.NewLine, spaces));
        }

        private static void CheckLinesNotNull(string lines)
        {
            if (lines == null)
            {
                throw new ArgumentNullException("lines");
            }
        }
    }
}