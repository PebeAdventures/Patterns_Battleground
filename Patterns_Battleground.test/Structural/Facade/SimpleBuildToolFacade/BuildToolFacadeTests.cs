using Patterns_Battleground.Structural.Facade.SimpleBuildToolFacade.Core;
using Patterns_Battleground.test.Structural.Facade.SimpleBuildToolFacade.Mock;

namespace Patterns_Battleground.test.Structural.Facade.SimpleBuildToolFacade
{
    public class BuildToolFacadeTests
    {
        private readonly FakeTester _tester;
        private readonly FakePackager _packager;
        private readonly FakeBuilder _builder;
        private readonly TestCallTracker _callTracker;
        private readonly BuildToolFacade _facade;

        public BuildToolFacadeTests()
        {
            _callTracker = new TestCallTracker();
            _builder = new FakeBuilder(_callTracker);
            _tester = new FakeTester(_callTracker);
            _packager = new FakePackager(_callTracker);

            _facade = new BuildToolFacade(_builder, _tester, _packager);
        }

        [Fact]
        public void BuildSolution_WhenCalled_ShouldCallOnlyBuildComponent()
        {
            //Act
            _facade.BuildSolution();

            //Assert
            Assert.True(_builder.WasCalled);
            Assert.False(_packager.WasCalled);
            Assert.False(_tester.WasCalled);
        }

        [Fact]
        public void BuildAndTestSolution_WhenCalled_ShouldCallOnlyBuildAndTestComponents()
        {
            //Act
            _facade.BuildAndTestSolution();

            //Assert
            Assert.True(_builder.WasCalled);
            Assert.False(_packager.WasCalled);
            Assert.True(_tester.WasCalled);
        }

        [Fact]
        public void BuildTestAndPackageSolution_WhenCalled_ShouldCallOnlyBuildAndTestAndPackageComponents()
        {
            //Act
            _facade.BuildTestAndPackageSolution();

            //Assert
            Assert.True(_builder.WasCalled);
            Assert.True(_packager.WasCalled);
            Assert.True(_tester.WasCalled);
        }

        [Fact]
        public void BuildTestAndPackageSolution_WhenCalled_ShouldRunInCorrectOrder()
        {
            //Act
            _facade.BuildTestAndPackageSolution();

            //Assert
            Assert.Equal(new[] { "build", "test", "package" }, _callTracker.Calls);
        }
    }
}
