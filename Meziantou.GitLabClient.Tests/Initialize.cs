﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

[assembly: Parallelize(Scope = ExecutionScope.MethodLevel)]

namespace Meziantou.GitLab.Tests
{
    [TestClass]
    public class Initialize
    {
        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext context)
        {
            var container = new GitLabDockerContainer();
            container.Setup().Wait(context.CancellationTokenSource.Token);

            GitLabTestContext.DockerContainer = container;
        }
    }
}
