using Tracer.Core;
using Tracer.Serialization.Abstractions;
using System.Xml.Serialization;

namespace Tracer.Serialization.Xml;

public class XmlTraceResultSerializer : ITraceResultSerializer
{
    public string Format { get; }

    public XmlTraceResultSerializer()
    {
        Format = "xml"; //TODO: not sure its a good idea
    }
    
    public void Serialize(TraceResult traceResult, Stream to)
    {
        try
        {
            var xmlSerializer = new XmlSerializer(typeof(TraceResult));
            xmlSerializer.Serialize(to, traceResult);
        }
        catch (InvalidOperationException e)
        {
            Console.Error.WriteLine(e.Message);
        }
    }
}