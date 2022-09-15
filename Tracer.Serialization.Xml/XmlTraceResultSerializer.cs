using Tracer.Core;
using Tracer.Serialization.Abstractions;
using XSerializer;

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
            var xmlSerializer = XmlSerializer.Create(typeof(TraceResult));
            xmlSerializer.Serialize(to, traceResult);
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