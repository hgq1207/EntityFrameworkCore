﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.EntityFrameworkCore.Query;

namespace Microsoft.EntityFrameworkCore
{
    public class InMemoryComplianceTest : ComplianceTestBase
    {
        protected override ICollection<Type> IgnoredTestBases { get; } = new HashSet<Type>
        {
            typeof(FunkyDataQueryTestBase<>),
            typeof(OptimisticConcurrencyTestBase<>),
            typeof(StoreGeneratedTestBase<>),
            typeof(LoadTestBase<>),                        // issue #15318
            typeof(GraphUpdatesTestBase<>),                // issue #15318
            typeof(ProxyGraphUpdatesTestBase<>),           // issue #15318
            typeof(ComplexNavigationsWeakQueryTestBase<>), // issue #15285
            typeof(FiltersInheritanceTestBase<>),          // issue #15264
            typeof(FiltersTestBase<>),                     // issue #15264
            typeof(OwnedQueryTestBase<>)                  // issue #15285
        };

        protected override Assembly TargetAssembly { get; } = typeof(InMemoryComplianceTest).Assembly;
    }
}
