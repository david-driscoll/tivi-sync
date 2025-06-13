using Projects;

var builder = DistributedApplication.CreateBuilder(args);

var minio = builder.AddMinIO("minio")
    .WithDataVolume();
builder.AddProject<tivi>("tivi")
    .WithReference(minio)
    .WaitFor(minio);

builder.Build().Run();
