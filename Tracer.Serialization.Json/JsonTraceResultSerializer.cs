using System.Text;
using System.Text.Json;
using Tracer.Core;
using Tracer.Serialization.Abstractions;
using System.Text.Json.Serialization;

namespace Tracer.Serialization.Json;

public class JsonTraceResultSerializer : ITraceResultSerializer
{
    public string Format { get; }

    public JsonTraceResultSerializer()
    {
        Format = "json";
    }
    public void Serialize(TraceResult traceResult, Stream to)
    {
        try
        {
            var json = JsonSerializer.Serialize(traceResult);
            to.Write(Encoding.ASCII.GetBytes(json));
            to.Flush();
        }
        catch (InvalidOperationException e)
        {
            Console.Error.WriteLine(e.Message);
        }
        catch (IOException e)
        {
            Console.Error.WriteLine(e.Message);
        }
    }
}