using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace X12ResourceTool.Spec
{
    public interface IName
    {
        string name { get; }
    }

    public interface IXid
    {
        string xid { get; }
    }

    public interface IUsage
    {
        string Usage { get; }
    }

    public interface ITransaction : IName, IXid
    {
        ILoop loop { get; }
    }

    public interface ITransaction<TLoop,TSegment,TElement> : ITransaction
        where TLoop : ILoop<TSegment,TElement>
        where TSegment : ISegment<TElement>
        where TElement : IElement
    {
        TLoop loop { get; }
    }

    public interface ILoop : IName, IXid
    {
        string name { get; }
        IReadOnlyList<ISegment> Segments { get; }
    }

    public interface ILoop<TSegment,TElement> : ILoop
        where TSegment : ISegment<TElement>
        where TElement : IElement
    {
        string name { get; }
        TSegment[] segment { get; }
    }

    public interface ISegment : IName, IXid, IUsage
    {
        string name { get; }
        IReadOnlyList<IElement> Elements { get; }
    }

    public interface ISegment<TElement> : ISegment
        where TElement : IElement
    {
        string name { get; }
        TElement[] element { get; }
    }

    public interface IElement : IName, IXid, IUsage //: IElement
        //where TElement : IElement
    {
        string name { get; }
        //TElement[] element { get; }
    }
}
