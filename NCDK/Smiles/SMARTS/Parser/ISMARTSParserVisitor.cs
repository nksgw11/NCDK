/* Generated By:JavaCC: Do not edit this line. SMARTSParserVisitor.java Version 5.0 */
namespace NCDK.Smiles.SMARTS.Parser
{
    public interface ISMARTSParserVisitor
    {
        object Visit(SimpleNode node, object data);
        object Visit(ASTStart node, object data);
        object Visit(ASTReaction node, object data);
        object Visit(ASTGroup node, object data);
        object Visit(ASTSmarts node, object data);
        object Visit(ASTAtom node, object data);
        object Visit(ASTLowAndBond node, object data);
        object Visit(ASTOrBond node, object data);
        object Visit(ASTExplicitHighAndBond node, object data);
        object Visit(ASTImplicitHighAndBond node, object data);
        object Visit(ASTNotBond node, object data);
        object Visit(ASTSimpleBond node, object data);
        object Visit(ASTExplicitAtom node, object data);
        object Visit(ASTLowAndExpression node, object data);
        object Visit(ASTOrExpression node, object data);
        object Visit(ASTExplicitHighAndExpression node, object data);
        object Visit(ASTImplicitHighAndExpression node, object data);
        object Visit(ASTNotExpression node, object data);
        object Visit(ASTRecursiveSmartsExpression node, object data);
        object Visit(ASTTotalHCount node, object data);
        object Visit(ASTImplicitHCount node, object data);
        object Visit(ASTExplicitConnectivity node, object data);
        object Visit(ASTAtomicNumber node, object data);
        object Visit(ASTHybrdizationNumber node, object data);
        object Visit(ASTCharge node, object data);
        object Visit(ASTRingConnectivity node, object data);
        object Visit(ASTPeriodicGroupNumber node, object data);
        object Visit(ASTTotalConnectivity node, object data);
        object Visit(ASTValence node, object data);
        object Visit(ASTRingMembership node, object data);
        object Visit(ASTSmallestRingSize node, object data);
        object Visit(ASTAliphatic node, object data);
        object Visit(ASTNonCHHeavyAtom node, object data);
        object Visit(ASTAromatic node, object data);
        object Visit(ASTAnyAtom node, object data);
        object Visit(ASTAtomicMass node, object data);
        object Visit(ASTRingIdentifier node, object data);
        object Visit(ASTChirality node, object data);
        object Visit(ASTElement node, object data);
    }
}