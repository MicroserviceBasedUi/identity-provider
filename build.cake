var target = Argument("target", "Default");

var sourceDir = @".\src";
var projectDir = System.IO.Path.Combine(sourceDir, "Zuehlke.IdentityProvider");
var project = System.IO.Path.Combine(projectDir, "Zuehlke.IdentityProvider.csproj");

var runSettings = new DotNetCoreRunSettings
{
    WorkingDirectory = projectDir
};

Task("Restore")
    .Does(() =>
{
    DotNetCoreRestore(sourceDir);
});

Task("Build")
    .IsDependentOn("Restore")
    .Does(() =>
{
    DotNetCoreBuild(sourceDir);
});

Task("Run")
    .IsDependentOn("Build")
    .Does(() =>
{
    DotNetCoreRun(project,runSettings);
});

Task("Default")
    .IsDependentOn("Build")
    .Does(() =>
{
});

RunTarget(target);