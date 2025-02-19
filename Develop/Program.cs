#pragma warning disable CA1822
namespace Develop;

using BunnyTail.ObjectProjection;

internal static class Program
{
    public static void Main()
    {
        var service = new Service();
        var controller = new Controller(service);

        var response = controller.Execute(new Request { Id = 1 });

        Console.WriteLine(response.Name);
    }
}

internal static partial class ProjectionExtensions
{
    [ProjectionExtension]
    public static partial IServiceContextParameter AsServiceContext(this Request request);

    [ProjectionExtension]
    public static partial IResponse AsResponse(this Entity entity);
}

internal sealed class Request
{
    public int? Id { get; set; }
}

internal interface IResponse
{
    string Name { get; }
}

internal sealed class Controller(Service service)
{
    public IResponse Execute(Request request)
    {
        // マップで解決する問題ではない
        return service.Query(request.AsServiceContext()).AsResponse();
    }
}

internal interface IServiceContextParameter
{
    public int Id { get; }
}

internal sealed class Service
{
    public Entity Query(IServiceContextParameter parameter)
    {
        return new Entity { Name = $"Name-{parameter.Id}" };
    }
}

internal sealed class Entity
{
    public string Name { get; set; } = default!;
}

// TODO Delete
internal static partial class ProjectionExtensions
{
    public static partial IServiceContextParameter AsServiceContext(this Request request)
    {
        return null!;
    }

    public static partial IResponse AsResponse(this Entity entity)
    {
        return null!;
    }
}
