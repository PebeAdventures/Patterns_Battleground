namespace Patterns_Battleground.Structural.Facade.SimpleBuildToolFacade.Core;

public class BuildToolFacade
{
    private readonly IBuilder _builder;
    private readonly ITester _tester;
    private readonly IPackager _packager;

    public BuildToolFacade(IBuilder builder, ITester tester, IPackager packager)
    {
        _builder = builder;
        _tester = tester;
        _packager = packager;
    }
    public void BuildSolution()
    {
        _builder.Build();

    }
    public void BuildAndTestSolution() 
    {
        _builder.Build();
        _tester.RunTests();
    }

    public void BuildTestAndPackageSolution()
    {
        _builder.Build();
        _tester.RunTests();
        _packager.Package();
    }
}
