using System;
using System.Collections.Generic;

namespace X12ResourceTool.Spec.MapV1
{
    public partial class transactionType : ITransaction<LoopType,SegmentType,ElementType>{
        public override string ToString() => $"transactionType: {this.xid}-{this.name}\r\n{this.loop.ToString()}";
        ILoop ITransaction.loop => loopField;
    }


    public partial class LoopType : ILoop<SegmentType,ElementType> {
        public override string ToString() => $"LoopType: {this.xid}-{this.name}\r\n  {segment.JoinStrings("\n  ")}\r\n{loop.JoinStrings("\n")}";
        IReadOnlyList<ISegment> ILoop.Segments => segmentField;
    }

    public partial class SegmentType : ISegment<ElementType> {
        public override string ToString() => $"SegmentType: {this.xid}-{this.name}\r\n{syntax.JoinStrings("\n")}\r\n{element.JoinStrings("\n")}\r\n  {composite.JoinStrings("\n  ")}\r\n/Segment";
        IReadOnlyList<IElement> ISegment.Elements => elementField;
        string IUsage.Usage => usage.ToString();
    }
    public partial class ElementType : IElement{
        public override string ToString() => $"ElementType: {this.xid}-{this.seq}-{this.name} {this.valid_codes}\r\n{this.regex}\r\n{this.repeat}\r\n{this.data_ele}";
        string IUsage.Usage => usage.ToString();
    }
    public partial class ElementTypeValid_codes {
        public override string ToString() => $"(ElementTypeValid_codes:{this.external}:{this.code.JoinStrings(",")})";
    }
    public partial class CompositeType {
        public override string ToString() => $"CompositeType: {this.xid}-{this.name}-{usage}\r\n{this.syntax.JoinStrings(",")}\r\n{this.element.JoinStrings(Environment.NewLine)}";
    }
}
