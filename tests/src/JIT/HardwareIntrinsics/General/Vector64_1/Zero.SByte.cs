// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

/******************************************************************************
 * This file is auto-generated from a template file by the GenerateTests.csx  *
 * script in tests\src\JIT\HardwareIntrinsics\General\Shared. In order to make    *
 * changes, please update the corresponding template and run according to the *
 * directions listed in the file.                                             *
 ******************************************************************************/

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics;

namespace JIT.HardwareIntrinsics.General
{
    public static partial class Program
    {
        private static void ZeroSByte()
        {
            var test = new VectorZero__ZeroSByte();

            // Validates basic functionality works
            test.RunBasicScenario();

            // Validates calling via reflection works
            test.RunReflectionScenario();

            if (!test.Succeeded)
            {
                throw new Exception("One or more scenarios did not complete as expected.");
            }
        }
    }

    public sealed unsafe class VectorZero__ZeroSByte
    {
        private static readonly int LargestVectorSize = 8;

        private static readonly int ElementCount = Unsafe.SizeOf<Vector64<SByte>>() / sizeof(SByte);

        public bool Succeeded { get; set; } = true;

        public void RunBasicScenario()
        {
            TestLibrary.TestFramework.BeginScenario(nameof(RunBasicScenario));

            Vector64<SByte> result = Vector64<SByte>.Zero;

            ValidateResult(result);
        }

        public void RunReflectionScenario()
        {
            TestLibrary.TestFramework.BeginScenario(nameof(RunReflectionScenario));

            object result = typeof(Vector64<SByte>)
                                .GetProperty(nameof(Vector64<SByte>.Zero), new Type[] { })
                                .GetGetMethod()
                                .Invoke(null, new object[] { });

            ValidateResult((Vector64<SByte>)(result));
        }

        private void ValidateResult(Vector64<SByte> result, [CallerMemberName] string method = "")
        {
            SByte[] resultElements = new SByte[ElementCount];
            Unsafe.WriteUnaligned(ref Unsafe.As<SByte, byte>(ref resultElements[0]), result);
            ValidateResult(resultElements, method);
        }

        private void ValidateResult(SByte[] resultElements, [CallerMemberName] string method = "")
        {
            for (var i = 0; i < ElementCount; i++)
            {
                if (resultElements[i] != 0)
                {
                    Succeeded = false;
                    break;
                }
            }

            if (!Succeeded)
            {
                TestLibrary.TestFramework.LogInformation($"Vector64.Zero(SByte): {method} failed:");
                TestLibrary.TestFramework.LogInformation($"  result: ({string.Join(", ", resultElements)})");
                TestLibrary.TestFramework.LogInformation(string.Empty);
            }
        }
    }
}
