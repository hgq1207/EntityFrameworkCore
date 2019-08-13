// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.EntityFrameworkCore.Query
{
    /// <summary>
    ///     <para>
    ///         A factory for creating <see cref="RelationalQueryOptimizer"/> instances.
    ///     </para>
    ///     <para>
    ///         The service lifetime is <see cref="ServiceLifetime.Singleton"/>. This means a single instance
    ///         is used by many <see cref="DbContext"/> instances. The implementation must be thread-safe.
    ///         This service cannot depend on services registered as <see cref="ServiceLifetime.Scoped"/>.
    ///     </para>
    /// </summary>
    public class RelationalQueryOptimizerFactory : QueryOptimizerFactory
    {
        public RelationalQueryOptimizerFactory(
            QueryOptimizerDependencies dependencies,
            RelationalQueryOptimizerDependencies relationalDependencies)
            : base(dependencies)
        {
            RelationalDependencies = relationalDependencies;
        }

        protected virtual RelationalQueryOptimizerDependencies RelationalDependencies { get; }

        public override QueryOptimizer Create(QueryCompilationContext queryCompilationContext)
             => new RelationalQueryOptimizer(Dependencies, RelationalDependencies, queryCompilationContext);
    }
}