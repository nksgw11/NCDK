/* Generated By:JJTree: Do not edit this line. ASTSmallestRingSize.java Version 4.3 */
/* JavaCCOptions:MULTI=true,NODE_USES_PARSER=false,VISITOR=true,TRACK_TOKENS=false,NODE_PREFIX=AST,NODE_EXTENDS=,NODE_FACTORY=,SUPPORT_CLASS_VISIBILITY_PUBLIC=true */
namespace NCDK.Smiles.SMARTS.Parser
{
    [System.Obsolete]
    internal class ASTSmallestRingSize : SimpleNode
    {
        public ASTSmallestRingSize(int id)
          : base(id)
        {
        }

        public ASTSmallestRingSize(SMARTSParser p, int id)
          : base(p, id)
        {
        }

        /// <summary>
        /// The smallest SSSR size.
        /// </summary>
        public int Size { get; set; }

        /// <summary>Accept the visitor. </summary>
        public override object JjtAccept(ISMARTSParserVisitor visitor, object data)
        {
            return visitor.Visit(this, data);
        }
    }
}
