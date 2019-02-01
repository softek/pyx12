using System.Collections.Generic;
// ReSharper disable InconsistentNaming

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

    public interface ILoop : IName, IXid
    {
        IReadOnlyList<ILoop> Loops { get; }
        IReadOnlyList<ISegment> Segments { get; }
    }

    public interface ISegment : IName, IXid, IUsage
    {
        IReadOnlyList<IElement> Elements { get; }
    }

    public interface IElement : IName, IXid, IUsage
    {
    }
}
