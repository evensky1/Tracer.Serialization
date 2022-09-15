using System.Text;
using Tracer.Core;
using Tracer.Serialization.Abstractions;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace Tracer.Serialization.Yaml;

public class YamlTraceResultSerializer : ITraceResultSerializer
{
    public string Format { get; }

    public YamlTraceResultSerializer()
    {
        Format = "yaml";
    }
    
    public void Serialize(TraceResult traceResult, Stream to)
    {
        var serializer = new SerializerBuilder()
            .WithNamingConvention(CamelCaseNamingConvention.Instance)
            .Build();

        try
        {
            var yaml = serializer.Serialize(traceResult);
            to.Write(Encoding.ASCII.GetBytes(yaml));
            to.Flush();
        }
        catch (Exception e)
        {
            Console.Error.WriteLine(e.Message);
        }
    }
}