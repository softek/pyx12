namespace X12ResourceTool.Spec.MapV2
{
    public partial class transactionType {
        public override string ToString() => $"transactionType: {this.xid}-{this.name}\r\n{this.loop.ToString()}";
    }
    public partial class LoopType {
        public override string ToString() => $"LoopType: {this.xid}-{this.name}\r\n";
    }
    public partial class SegmentType {
        public override string ToString() => $"SegmentType: {this.xid}-{this.name}";
    }
    public partial class ElementType {
        public override string ToString() => $"ElementType: {this.xid}-{this.name}";
    }
    public partial class ElementTypeValid_codes {
        public override string ToString() => $"ElementTypeValid_codes: {this.xid}-{this.name}";
    }
    public partial class CompositeType {
        public override string ToString() => $"CompositeType: {this.xid}-{this.name}";
    }
}
