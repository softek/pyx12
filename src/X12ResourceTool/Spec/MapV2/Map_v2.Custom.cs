using System;
using System.Collections.Generic;

// ReSharper disable InconsistentNaming

namespace X12ResourceTool.Spec.MapV2
{
    public partial class transactionType : ITransaction
    {
        public override string ToString() => $"transactionType: {xid}-{name}\r\n{loop}";
        ILoop ITransaction.loop => loopField;
    }


    public partial class LoopType : ILoop
    {
        public override string ToString() => $"LoopType: {xid}-{name}\r\n  {segment.JoinStrings("\n  ")}\r\n{loop.JoinStrings("\n")}";
        IReadOnlyList<ILoop> ILoop.Loops => loopField.OrEmpty();
        IReadOnlyList<ISegment> ILoop.Segments => segmentField.OrEmpty();
    }

    public partial class SegmentType : ISegment
    {
        public override string ToString() => $"SegmentType: {xid}-{name}\r\n{syntax.JoinStrings("\n")}\r\n{element.JoinStrings("\n")}\r\n  {composite.JoinStrings("\n  ")}\r\n/Segment";
        IReadOnlyList<IElement> ISegment.Elements => elementField.OrEmpty();
        string IUsage.Usage => usage.ToString();
    }

    public partial class ElementType : IElement
    {
        public override string ToString() => $"ElementType: {xid}-{seq}-{name} {valid_codes}\r\n{regex}\r\n{repeat}\r\n{data_ele}";
        string IUsage.Usage => usage.ToString();
    }

    public partial class ElementTypeValid_codes
    {
        public override string ToString() => $"(ElementTypeValid_codes:{external}:{code.JoinStrings(",")})";
    }

    public partial class CompositeType
    {
        public override string ToString() => $"CompositeType: {xid}-{name}-{usage}\r\n{syntax.JoinStrings(",")}\r\n{element.JoinStrings(Environment.NewLine)}";
    }
}
