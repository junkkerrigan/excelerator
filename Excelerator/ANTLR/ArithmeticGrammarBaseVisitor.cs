//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.7.2
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from .\ArithmeticGrammar.g4 by ANTLR 4.7.2

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using IToken = Antlr4.Runtime.IToken;
using ParserRuleContext = Antlr4.Runtime.ParserRuleContext;

/// <summary>
/// This class provides an empty implementation of <see cref="IArithmeticGrammarVisitor{Result}"/>,
/// which can be extended to create a visitor which only needs to handle a subset
/// of the available methods.
/// </summary>
/// <typeparam name="Result">The return type of the visit operation.</typeparam>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.7.2")]
[System.CLSCompliant(false)]
public partial class ArithmeticGrammarBaseVisitor<Result> : AbstractParseTreeVisitor<Result>, IArithmeticGrammarVisitor<Result> {
	/// <summary>
	/// Visit a parse tree produced by <see cref="ArithmeticGrammarParser.expression"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitExpression([NotNull] ArithmeticGrammarParser.ExpressionContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by the <c>NegativeNumber</c>
	/// labeled alternative in <see cref="ArithmeticGrammarParser.component"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitNegativeNumber([NotNull] ArithmeticGrammarParser.NegativeNumberContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by the <c>Parenthesis</c>
	/// labeled alternative in <see cref="ArithmeticGrammarParser.component"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitParenthesis([NotNull] ArithmeticGrammarParser.ParenthesisContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by the <c>Minimum</c>
	/// labeled alternative in <see cref="ArithmeticGrammarParser.component"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitMinimum([NotNull] ArithmeticGrammarParser.MinimumContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by the <c>Maximum</c>
	/// labeled alternative in <see cref="ArithmeticGrammarParser.component"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitMaximum([NotNull] ArithmeticGrammarParser.MaximumContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by the <c>Rest</c>
	/// labeled alternative in <see cref="ArithmeticGrammarParser.component"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitRest([NotNull] ArithmeticGrammarParser.RestContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by the <c>Multiplication</c>
	/// labeled alternative in <see cref="ArithmeticGrammarParser.component"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitMultiplication([NotNull] ArithmeticGrammarParser.MultiplicationContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by the <c>Addition</c>
	/// labeled alternative in <see cref="ArithmeticGrammarParser.component"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitAddition([NotNull] ArithmeticGrammarParser.AdditionContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by the <c>Number</c>
	/// labeled alternative in <see cref="ArithmeticGrammarParser.component"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitNumber([NotNull] ArithmeticGrammarParser.NumberContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by the <c>Modulo</c>
	/// labeled alternative in <see cref="ArithmeticGrammarParser.component"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitModulo([NotNull] ArithmeticGrammarParser.ModuloContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by the <c>UnaryMinus</c>
	/// labeled alternative in <see cref="ArithmeticGrammarParser.component"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitUnaryMinus([NotNull] ArithmeticGrammarParser.UnaryMinusContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by the <c>Cell</c>
	/// labeled alternative in <see cref="ArithmeticGrammarParser.component"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitCell([NotNull] ArithmeticGrammarParser.CellContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by the <c>Power</c>
	/// labeled alternative in <see cref="ArithmeticGrammarParser.component"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitPower([NotNull] ArithmeticGrammarParser.PowerContext context) { return VisitChildren(context); }
}
