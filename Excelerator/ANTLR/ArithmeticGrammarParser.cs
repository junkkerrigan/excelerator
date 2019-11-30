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

using System;
using System.IO;
using System.Text;
using System.Diagnostics;
using System.Collections.Generic;
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using DFA = Antlr4.Runtime.Dfa.DFA;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.7.2")]
[System.CLSCompliant(false)]
public partial class ArithmeticGrammarParser : Parser {
	protected static DFA[] decisionToDFA;
	protected static PredictionContextCache sharedContextCache = new PredictionContextCache();
	public const int
		T__0=1, T__1=2, T__2=3, T__3=4, T__4=5, T__5=6, T__6=7, T__7=8, T__8=9, 
		T__9=10, T__10=11, T__11=12, T__12=13, CELL=14, NUMBER=15, CHAR=16, WHITESPACE=17;
	public const int
		RULE_expression = 0, RULE_component = 1;
	public static readonly string[] ruleNames = {
		"expression", "component"
	};

	private static readonly string[] _LiteralNames = {
		null, "'('", "')'", "'min('", "','", "'max('", "'^'", "'+'", "'-'", "'*'", 
		"'/'", "'%'", "'+('", "'-('"
	};
	private static readonly string[] _SymbolicNames = {
		null, null, null, null, null, null, null, null, null, null, null, null, 
		null, null, "CELL", "NUMBER", "CHAR", "WHITESPACE"
	};
	public static readonly IVocabulary DefaultVocabulary = new Vocabulary(_LiteralNames, _SymbolicNames);

	[NotNull]
	public override IVocabulary Vocabulary
	{
		get
		{
			return DefaultVocabulary;
		}
	}

	public override string GrammarFileName { get { return "ArithmeticGrammar.g4"; } }

	public override string[] RuleNames { get { return ruleNames; } }

	public override string SerializedAtn { get { return new string(_serializedATN); } }

	static ArithmeticGrammarParser() {
		decisionToDFA = new DFA[_ATN.NumberOfDecisions];
		for (int i = 0; i < _ATN.NumberOfDecisions; i++) {
			decisionToDFA[i] = new DFA(_ATN.GetDecisionState(i), i);
		}
	}

		public ArithmeticGrammarParser(ITokenStream input) : this(input, Console.Out, Console.Error) { }

		public ArithmeticGrammarParser(ITokenStream input, TextWriter output, TextWriter errorOutput)
		: base(input, output, errorOutput)
	{
		Interpreter = new ParserATNSimulator(this, _ATN, decisionToDFA, sharedContextCache);
	}

	public partial class ExpressionContext : ParserRuleContext {
		public ITerminalNode Eof() { return GetToken(ArithmeticGrammarParser.Eof, 0); }
		public ComponentContext[] component() {
			return GetRuleContexts<ComponentContext>();
		}
		public ComponentContext component(int i) {
			return GetRuleContext<ComponentContext>(i);
		}
		public ExpressionContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_expression; } }
		public override void EnterRule(IParseTreeListener listener) {
			IArithmeticGrammarListener typedListener = listener as IArithmeticGrammarListener;
			if (typedListener != null) typedListener.EnterExpression(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IArithmeticGrammarListener typedListener = listener as IArithmeticGrammarListener;
			if (typedListener != null) typedListener.ExitExpression(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IArithmeticGrammarVisitor<TResult> typedVisitor = visitor as IArithmeticGrammarVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitExpression(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public ExpressionContext expression() {
		ExpressionContext _localctx = new ExpressionContext(Context, State);
		EnterRule(_localctx, 0, RULE_expression);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 5;
			ErrorHandler.Sync(this);
			_la = TokenStream.LA(1);
			do {
				{
				{
				State = 4; component(0);
				}
				}
				State = 7;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
			} while ( (((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << T__0) | (1L << T__2) | (1L << T__4) | (1L << T__6) | (1L << T__7) | (1L << T__11) | (1L << T__12) | (1L << CELL) | (1L << NUMBER))) != 0) );
			State = 9; Match(Eof);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class ComponentContext : ParserRuleContext {
		public ComponentContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_component; } }
	 
		public ComponentContext() { }
		public virtual void CopyFrom(ComponentContext context) {
			base.CopyFrom(context);
		}
	}
	public partial class MinimumContext : ComponentContext {
		public ComponentContext[] component() {
			return GetRuleContexts<ComponentContext>();
		}
		public ComponentContext component(int i) {
			return GetRuleContext<ComponentContext>(i);
		}
		public MinimumContext(ComponentContext context) { CopyFrom(context); }
		public override void EnterRule(IParseTreeListener listener) {
			IArithmeticGrammarListener typedListener = listener as IArithmeticGrammarListener;
			if (typedListener != null) typedListener.EnterMinimum(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IArithmeticGrammarListener typedListener = listener as IArithmeticGrammarListener;
			if (typedListener != null) typedListener.ExitMinimum(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IArithmeticGrammarVisitor<TResult> typedVisitor = visitor as IArithmeticGrammarVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitMinimum(this);
			else return visitor.VisitChildren(this);
		}
	}
	public partial class AdditionContext : ComponentContext {
		public ComponentContext[] component() {
			return GetRuleContexts<ComponentContext>();
		}
		public ComponentContext component(int i) {
			return GetRuleContext<ComponentContext>(i);
		}
		public AdditionContext(ComponentContext context) { CopyFrom(context); }
		public override void EnterRule(IParseTreeListener listener) {
			IArithmeticGrammarListener typedListener = listener as IArithmeticGrammarListener;
			if (typedListener != null) typedListener.EnterAddition(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IArithmeticGrammarListener typedListener = listener as IArithmeticGrammarListener;
			if (typedListener != null) typedListener.ExitAddition(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IArithmeticGrammarVisitor<TResult> typedVisitor = visitor as IArithmeticGrammarVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitAddition(this);
			else return visitor.VisitChildren(this);
		}
	}
	public partial class MultiplicationContext : ComponentContext {
		public ComponentContext[] component() {
			return GetRuleContexts<ComponentContext>();
		}
		public ComponentContext component(int i) {
			return GetRuleContext<ComponentContext>(i);
		}
		public MultiplicationContext(ComponentContext context) { CopyFrom(context); }
		public override void EnterRule(IParseTreeListener listener) {
			IArithmeticGrammarListener typedListener = listener as IArithmeticGrammarListener;
			if (typedListener != null) typedListener.EnterMultiplication(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IArithmeticGrammarListener typedListener = listener as IArithmeticGrammarListener;
			if (typedListener != null) typedListener.ExitMultiplication(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IArithmeticGrammarVisitor<TResult> typedVisitor = visitor as IArithmeticGrammarVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitMultiplication(this);
			else return visitor.VisitChildren(this);
		}
	}
	public partial class ModuloContext : ComponentContext {
		public ComponentContext[] component() {
			return GetRuleContexts<ComponentContext>();
		}
		public ComponentContext component(int i) {
			return GetRuleContext<ComponentContext>(i);
		}
		public ModuloContext(ComponentContext context) { CopyFrom(context); }
		public override void EnterRule(IParseTreeListener listener) {
			IArithmeticGrammarListener typedListener = listener as IArithmeticGrammarListener;
			if (typedListener != null) typedListener.EnterModulo(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IArithmeticGrammarListener typedListener = listener as IArithmeticGrammarListener;
			if (typedListener != null) typedListener.ExitModulo(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IArithmeticGrammarVisitor<TResult> typedVisitor = visitor as IArithmeticGrammarVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitModulo(this);
			else return visitor.VisitChildren(this);
		}
	}
	public partial class UnaryPlusParenthesisContext : ComponentContext {
		public ComponentContext component() {
			return GetRuleContext<ComponentContext>(0);
		}
		public UnaryPlusParenthesisContext(ComponentContext context) { CopyFrom(context); }
		public override void EnterRule(IParseTreeListener listener) {
			IArithmeticGrammarListener typedListener = listener as IArithmeticGrammarListener;
			if (typedListener != null) typedListener.EnterUnaryPlusParenthesis(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IArithmeticGrammarListener typedListener = listener as IArithmeticGrammarListener;
			if (typedListener != null) typedListener.ExitUnaryPlusParenthesis(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IArithmeticGrammarVisitor<TResult> typedVisitor = visitor as IArithmeticGrammarVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitUnaryPlusParenthesis(this);
			else return visitor.VisitChildren(this);
		}
	}
	public partial class SubstractionContext : ComponentContext {
		public ComponentContext[] component() {
			return GetRuleContexts<ComponentContext>();
		}
		public ComponentContext component(int i) {
			return GetRuleContext<ComponentContext>(i);
		}
		public SubstractionContext(ComponentContext context) { CopyFrom(context); }
		public override void EnterRule(IParseTreeListener listener) {
			IArithmeticGrammarListener typedListener = listener as IArithmeticGrammarListener;
			if (typedListener != null) typedListener.EnterSubstraction(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IArithmeticGrammarListener typedListener = listener as IArithmeticGrammarListener;
			if (typedListener != null) typedListener.ExitSubstraction(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IArithmeticGrammarVisitor<TResult> typedVisitor = visitor as IArithmeticGrammarVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitSubstraction(this);
			else return visitor.VisitChildren(this);
		}
	}
	public partial class ParenthesisContext : ComponentContext {
		public ComponentContext component() {
			return GetRuleContext<ComponentContext>(0);
		}
		public ParenthesisContext(ComponentContext context) { CopyFrom(context); }
		public override void EnterRule(IParseTreeListener listener) {
			IArithmeticGrammarListener typedListener = listener as IArithmeticGrammarListener;
			if (typedListener != null) typedListener.EnterParenthesis(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IArithmeticGrammarListener typedListener = listener as IArithmeticGrammarListener;
			if (typedListener != null) typedListener.ExitParenthesis(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IArithmeticGrammarVisitor<TResult> typedVisitor = visitor as IArithmeticGrammarVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitParenthesis(this);
			else return visitor.VisitChildren(this);
		}
	}
	public partial class MaximumContext : ComponentContext {
		public ComponentContext[] component() {
			return GetRuleContexts<ComponentContext>();
		}
		public ComponentContext component(int i) {
			return GetRuleContext<ComponentContext>(i);
		}
		public MaximumContext(ComponentContext context) { CopyFrom(context); }
		public override void EnterRule(IParseTreeListener listener) {
			IArithmeticGrammarListener typedListener = listener as IArithmeticGrammarListener;
			if (typedListener != null) typedListener.EnterMaximum(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IArithmeticGrammarListener typedListener = listener as IArithmeticGrammarListener;
			if (typedListener != null) typedListener.ExitMaximum(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IArithmeticGrammarVisitor<TResult> typedVisitor = visitor as IArithmeticGrammarVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitMaximum(this);
			else return visitor.VisitChildren(this);
		}
	}
	public partial class UnaryPlusNumberContext : ComponentContext {
		public ITerminalNode NUMBER() { return GetToken(ArithmeticGrammarParser.NUMBER, 0); }
		public UnaryPlusNumberContext(ComponentContext context) { CopyFrom(context); }
		public override void EnterRule(IParseTreeListener listener) {
			IArithmeticGrammarListener typedListener = listener as IArithmeticGrammarListener;
			if (typedListener != null) typedListener.EnterUnaryPlusNumber(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IArithmeticGrammarListener typedListener = listener as IArithmeticGrammarListener;
			if (typedListener != null) typedListener.ExitUnaryPlusNumber(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IArithmeticGrammarVisitor<TResult> typedVisitor = visitor as IArithmeticGrammarVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitUnaryPlusNumber(this);
			else return visitor.VisitChildren(this);
		}
	}
	public partial class NumberContext : ComponentContext {
		public ITerminalNode NUMBER() { return GetToken(ArithmeticGrammarParser.NUMBER, 0); }
		public NumberContext(ComponentContext context) { CopyFrom(context); }
		public override void EnterRule(IParseTreeListener listener) {
			IArithmeticGrammarListener typedListener = listener as IArithmeticGrammarListener;
			if (typedListener != null) typedListener.EnterNumber(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IArithmeticGrammarListener typedListener = listener as IArithmeticGrammarListener;
			if (typedListener != null) typedListener.ExitNumber(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IArithmeticGrammarVisitor<TResult> typedVisitor = visitor as IArithmeticGrammarVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitNumber(this);
			else return visitor.VisitChildren(this);
		}
	}
	public partial class UnaryMinusParenthesisContext : ComponentContext {
		public ComponentContext component() {
			return GetRuleContext<ComponentContext>(0);
		}
		public UnaryMinusParenthesisContext(ComponentContext context) { CopyFrom(context); }
		public override void EnterRule(IParseTreeListener listener) {
			IArithmeticGrammarListener typedListener = listener as IArithmeticGrammarListener;
			if (typedListener != null) typedListener.EnterUnaryMinusParenthesis(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IArithmeticGrammarListener typedListener = listener as IArithmeticGrammarListener;
			if (typedListener != null) typedListener.ExitUnaryMinusParenthesis(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IArithmeticGrammarVisitor<TResult> typedVisitor = visitor as IArithmeticGrammarVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitUnaryMinusParenthesis(this);
			else return visitor.VisitChildren(this);
		}
	}
	public partial class DivisionContext : ComponentContext {
		public ComponentContext[] component() {
			return GetRuleContexts<ComponentContext>();
		}
		public ComponentContext component(int i) {
			return GetRuleContext<ComponentContext>(i);
		}
		public DivisionContext(ComponentContext context) { CopyFrom(context); }
		public override void EnterRule(IParseTreeListener listener) {
			IArithmeticGrammarListener typedListener = listener as IArithmeticGrammarListener;
			if (typedListener != null) typedListener.EnterDivision(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IArithmeticGrammarListener typedListener = listener as IArithmeticGrammarListener;
			if (typedListener != null) typedListener.ExitDivision(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IArithmeticGrammarVisitor<TResult> typedVisitor = visitor as IArithmeticGrammarVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitDivision(this);
			else return visitor.VisitChildren(this);
		}
	}
	public partial class CellContext : ComponentContext {
		public ITerminalNode CELL() { return GetToken(ArithmeticGrammarParser.CELL, 0); }
		public CellContext(ComponentContext context) { CopyFrom(context); }
		public override void EnterRule(IParseTreeListener listener) {
			IArithmeticGrammarListener typedListener = listener as IArithmeticGrammarListener;
			if (typedListener != null) typedListener.EnterCell(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IArithmeticGrammarListener typedListener = listener as IArithmeticGrammarListener;
			if (typedListener != null) typedListener.ExitCell(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IArithmeticGrammarVisitor<TResult> typedVisitor = visitor as IArithmeticGrammarVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitCell(this);
			else return visitor.VisitChildren(this);
		}
	}
	public partial class UnaryMinusNumberContext : ComponentContext {
		public ITerminalNode NUMBER() { return GetToken(ArithmeticGrammarParser.NUMBER, 0); }
		public UnaryMinusNumberContext(ComponentContext context) { CopyFrom(context); }
		public override void EnterRule(IParseTreeListener listener) {
			IArithmeticGrammarListener typedListener = listener as IArithmeticGrammarListener;
			if (typedListener != null) typedListener.EnterUnaryMinusNumber(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IArithmeticGrammarListener typedListener = listener as IArithmeticGrammarListener;
			if (typedListener != null) typedListener.ExitUnaryMinusNumber(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IArithmeticGrammarVisitor<TResult> typedVisitor = visitor as IArithmeticGrammarVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitUnaryMinusNumber(this);
			else return visitor.VisitChildren(this);
		}
	}
	public partial class PowerContext : ComponentContext {
		public ComponentContext[] component() {
			return GetRuleContexts<ComponentContext>();
		}
		public ComponentContext component(int i) {
			return GetRuleContext<ComponentContext>(i);
		}
		public PowerContext(ComponentContext context) { CopyFrom(context); }
		public override void EnterRule(IParseTreeListener listener) {
			IArithmeticGrammarListener typedListener = listener as IArithmeticGrammarListener;
			if (typedListener != null) typedListener.EnterPower(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IArithmeticGrammarListener typedListener = listener as IArithmeticGrammarListener;
			if (typedListener != null) typedListener.ExitPower(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IArithmeticGrammarVisitor<TResult> typedVisitor = visitor as IArithmeticGrammarVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitPower(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public ComponentContext component() {
		return component(0);
	}

	private ComponentContext component(int _p) {
		ParserRuleContext _parentctx = Context;
		int _parentState = State;
		ComponentContext _localctx = new ComponentContext(Context, _parentState);
		ComponentContext _prevctx = _localctx;
		int _startState = 2;
		EnterRecursionRule(_localctx, 2, RULE_component, _p);
		try {
			int _alt;
			EnterOuterAlt(_localctx, 1);
			{
			State = 60;
			ErrorHandler.Sync(this);
			switch (TokenStream.LA(1)) {
			case T__0:
				{
				_localctx = new ParenthesisContext(_localctx);
				Context = _localctx;
				_prevctx = _localctx;

				State = 12; Match(T__0);
				State = 13; component(0);
				State = 14; Match(T__1);
				}
				break;
			case T__2:
				{
				_localctx = new MinimumContext(_localctx);
				Context = _localctx;
				_prevctx = _localctx;
				State = 16; Match(T__2);
				{
				State = 17; component(0);
				State = 18; Match(T__3);
				}
				State = 25;
				ErrorHandler.Sync(this);
				_alt = Interpreter.AdaptivePredict(TokenStream,1,Context);
				while ( _alt!=2 && _alt!=global::Antlr4.Runtime.Atn.ATN.INVALID_ALT_NUMBER ) {
					if ( _alt==1 ) {
						{
						{
						State = 20; component(0);
						State = 21; Match(T__3);
						}
						} 
					}
					State = 27;
					ErrorHandler.Sync(this);
					_alt = Interpreter.AdaptivePredict(TokenStream,1,Context);
				}
				State = 28; component(0);
				State = 29; Match(T__1);
				}
				break;
			case T__4:
				{
				_localctx = new MaximumContext(_localctx);
				Context = _localctx;
				_prevctx = _localctx;
				State = 31; Match(T__4);
				{
				State = 32; component(0);
				State = 33; Match(T__3);
				}
				State = 40;
				ErrorHandler.Sync(this);
				_alt = Interpreter.AdaptivePredict(TokenStream,2,Context);
				while ( _alt!=2 && _alt!=global::Antlr4.Runtime.Atn.ATN.INVALID_ALT_NUMBER ) {
					if ( _alt==1 ) {
						{
						{
						State = 35; component(0);
						State = 36; Match(T__3);
						}
						} 
					}
					State = 42;
					ErrorHandler.Sync(this);
					_alt = Interpreter.AdaptivePredict(TokenStream,2,Context);
				}
				State = 43; component(0);
				State = 44; Match(T__1);
				}
				break;
			case T__11:
				{
				_localctx = new UnaryPlusParenthesisContext(_localctx);
				Context = _localctx;
				_prevctx = _localctx;
				State = 46; Match(T__11);
				State = 47; component(0);
				State = 48; Match(T__1);
				}
				break;
			case T__12:
				{
				_localctx = new UnaryMinusParenthesisContext(_localctx);
				Context = _localctx;
				_prevctx = _localctx;
				State = 50; Match(T__12);
				State = 51; component(0);
				State = 52; Match(T__1);
				}
				break;
			case T__6:
				{
				_localctx = new UnaryPlusNumberContext(_localctx);
				Context = _localctx;
				_prevctx = _localctx;
				State = 54; Match(T__6);
				State = 55; Match(NUMBER);
				}
				break;
			case T__7:
				{
				_localctx = new UnaryMinusNumberContext(_localctx);
				Context = _localctx;
				_prevctx = _localctx;
				State = 56; Match(T__7);
				State = 57; Match(NUMBER);
				}
				break;
			case NUMBER:
				{
				_localctx = new NumberContext(_localctx);
				Context = _localctx;
				_prevctx = _localctx;
				State = 58; Match(NUMBER);
				}
				break;
			case CELL:
				{
				_localctx = new CellContext(_localctx);
				Context = _localctx;
				_prevctx = _localctx;
				State = 59; Match(CELL);
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
			Context.Stop = TokenStream.LT(-1);
			State = 82;
			ErrorHandler.Sync(this);
			_alt = Interpreter.AdaptivePredict(TokenStream,5,Context);
			while ( _alt!=2 && _alt!=global::Antlr4.Runtime.Atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					if ( ParseListeners!=null )
						TriggerExitRuleEvent();
					_prevctx = _localctx;
					{
					State = 80;
					ErrorHandler.Sync(this);
					switch ( Interpreter.AdaptivePredict(TokenStream,4,Context) ) {
					case 1:
						{
						_localctx = new PowerContext(new ComponentContext(_parentctx, _parentState));
						PushNewRecursionContext(_localctx, _startState, RULE_component);
						State = 62;
						if (!(Precpred(Context, 12))) throw new FailedPredicateException(this, "Precpred(Context, 12)");
						State = 63; Match(T__5);
						State = 64; component(13);
						}
						break;
					case 2:
						{
						_localctx = new AdditionContext(new ComponentContext(_parentctx, _parentState));
						PushNewRecursionContext(_localctx, _startState, RULE_component);
						State = 65;
						if (!(Precpred(Context, 11))) throw new FailedPredicateException(this, "Precpred(Context, 11)");
						State = 66; Match(T__6);
						State = 67; component(12);
						}
						break;
					case 3:
						{
						_localctx = new SubstractionContext(new ComponentContext(_parentctx, _parentState));
						PushNewRecursionContext(_localctx, _startState, RULE_component);
						State = 68;
						if (!(Precpred(Context, 10))) throw new FailedPredicateException(this, "Precpred(Context, 10)");
						State = 69; Match(T__7);
						State = 70; component(11);
						}
						break;
					case 4:
						{
						_localctx = new MultiplicationContext(new ComponentContext(_parentctx, _parentState));
						PushNewRecursionContext(_localctx, _startState, RULE_component);
						State = 71;
						if (!(Precpred(Context, 9))) throw new FailedPredicateException(this, "Precpred(Context, 9)");
						State = 72; Match(T__8);
						State = 73; component(10);
						}
						break;
					case 5:
						{
						_localctx = new DivisionContext(new ComponentContext(_parentctx, _parentState));
						PushNewRecursionContext(_localctx, _startState, RULE_component);
						State = 74;
						if (!(Precpred(Context, 8))) throw new FailedPredicateException(this, "Precpred(Context, 8)");
						State = 75; Match(T__9);
						State = 76; component(9);
						}
						break;
					case 6:
						{
						_localctx = new ModuloContext(new ComponentContext(_parentctx, _parentState));
						PushNewRecursionContext(_localctx, _startState, RULE_component);
						State = 77;
						if (!(Precpred(Context, 7))) throw new FailedPredicateException(this, "Precpred(Context, 7)");
						State = 78; Match(T__10);
						State = 79; component(8);
						}
						break;
					}
					} 
				}
				State = 84;
				ErrorHandler.Sync(this);
				_alt = Interpreter.AdaptivePredict(TokenStream,5,Context);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			UnrollRecursionContexts(_parentctx);
		}
		return _localctx;
	}

	public override bool Sempred(RuleContext _localctx, int ruleIndex, int predIndex) {
		switch (ruleIndex) {
		case 1: return component_sempred((ComponentContext)_localctx, predIndex);
		}
		return true;
	}
	private bool component_sempred(ComponentContext _localctx, int predIndex) {
		switch (predIndex) {
		case 0: return Precpred(Context, 12);
		case 1: return Precpred(Context, 11);
		case 2: return Precpred(Context, 10);
		case 3: return Precpred(Context, 9);
		case 4: return Precpred(Context, 8);
		case 5: return Precpred(Context, 7);
		}
		return true;
	}

	private static char[] _serializedATN = {
		'\x3', '\x608B', '\xA72A', '\x8133', '\xB9ED', '\x417C', '\x3BE7', '\x7786', 
		'\x5964', '\x3', '\x13', 'X', '\x4', '\x2', '\t', '\x2', '\x4', '\x3', 
		'\t', '\x3', '\x3', '\x2', '\x6', '\x2', '\b', '\n', '\x2', '\r', '\x2', 
		'\xE', '\x2', '\t', '\x3', '\x2', '\x3', '\x2', '\x3', '\x3', '\x3', '\x3', 
		'\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', 
		'\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', 
		'\a', '\x3', '\x1A', '\n', '\x3', '\f', '\x3', '\xE', '\x3', '\x1D', '\v', 
		'\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', 
		'\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', 
		'\x3', '\a', '\x3', ')', '\n', '\x3', '\f', '\x3', '\xE', '\x3', ',', 
		'\v', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', 
		'\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', 
		'\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', 
		'\x3', '\x3', '\x3', '\x3', '\x3', '\x5', '\x3', '?', '\n', '\x3', '\x3', 
		'\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', 
		'\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', 
		'\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', 
		'\x3', '\x3', '\x3', '\x3', '\x3', '\a', '\x3', 'S', '\n', '\x3', '\f', 
		'\x3', '\xE', '\x3', 'V', '\v', '\x3', '\x3', '\x3', '\x2', '\x3', '\x4', 
		'\x4', '\x2', '\x4', '\x2', '\x2', '\x2', '\x66', '\x2', '\a', '\x3', 
		'\x2', '\x2', '\x2', '\x4', '>', '\x3', '\x2', '\x2', '\x2', '\x6', '\b', 
		'\x5', '\x4', '\x3', '\x2', '\a', '\x6', '\x3', '\x2', '\x2', '\x2', '\b', 
		'\t', '\x3', '\x2', '\x2', '\x2', '\t', '\a', '\x3', '\x2', '\x2', '\x2', 
		'\t', '\n', '\x3', '\x2', '\x2', '\x2', '\n', '\v', '\x3', '\x2', '\x2', 
		'\x2', '\v', '\f', '\a', '\x2', '\x2', '\x3', '\f', '\x3', '\x3', '\x2', 
		'\x2', '\x2', '\r', '\xE', '\b', '\x3', '\x1', '\x2', '\xE', '\xF', '\a', 
		'\x3', '\x2', '\x2', '\xF', '\x10', '\x5', '\x4', '\x3', '\x2', '\x10', 
		'\x11', '\a', '\x4', '\x2', '\x2', '\x11', '?', '\x3', '\x2', '\x2', '\x2', 
		'\x12', '\x13', '\a', '\x5', '\x2', '\x2', '\x13', '\x14', '\x5', '\x4', 
		'\x3', '\x2', '\x14', '\x15', '\a', '\x6', '\x2', '\x2', '\x15', '\x1B', 
		'\x3', '\x2', '\x2', '\x2', '\x16', '\x17', '\x5', '\x4', '\x3', '\x2', 
		'\x17', '\x18', '\a', '\x6', '\x2', '\x2', '\x18', '\x1A', '\x3', '\x2', 
		'\x2', '\x2', '\x19', '\x16', '\x3', '\x2', '\x2', '\x2', '\x1A', '\x1D', 
		'\x3', '\x2', '\x2', '\x2', '\x1B', '\x19', '\x3', '\x2', '\x2', '\x2', 
		'\x1B', '\x1C', '\x3', '\x2', '\x2', '\x2', '\x1C', '\x1E', '\x3', '\x2', 
		'\x2', '\x2', '\x1D', '\x1B', '\x3', '\x2', '\x2', '\x2', '\x1E', '\x1F', 
		'\x5', '\x4', '\x3', '\x2', '\x1F', ' ', '\a', '\x4', '\x2', '\x2', ' ', 
		'?', '\x3', '\x2', '\x2', '\x2', '!', '\"', '\a', '\a', '\x2', '\x2', 
		'\"', '#', '\x5', '\x4', '\x3', '\x2', '#', '$', '\a', '\x6', '\x2', '\x2', 
		'$', '*', '\x3', '\x2', '\x2', '\x2', '%', '&', '\x5', '\x4', '\x3', '\x2', 
		'&', '\'', '\a', '\x6', '\x2', '\x2', '\'', ')', '\x3', '\x2', '\x2', 
		'\x2', '(', '%', '\x3', '\x2', '\x2', '\x2', ')', ',', '\x3', '\x2', '\x2', 
		'\x2', '*', '(', '\x3', '\x2', '\x2', '\x2', '*', '+', '\x3', '\x2', '\x2', 
		'\x2', '+', '-', '\x3', '\x2', '\x2', '\x2', ',', '*', '\x3', '\x2', '\x2', 
		'\x2', '-', '.', '\x5', '\x4', '\x3', '\x2', '.', '/', '\a', '\x4', '\x2', 
		'\x2', '/', '?', '\x3', '\x2', '\x2', '\x2', '\x30', '\x31', '\a', '\xE', 
		'\x2', '\x2', '\x31', '\x32', '\x5', '\x4', '\x3', '\x2', '\x32', '\x33', 
		'\a', '\x4', '\x2', '\x2', '\x33', '?', '\x3', '\x2', '\x2', '\x2', '\x34', 
		'\x35', '\a', '\xF', '\x2', '\x2', '\x35', '\x36', '\x5', '\x4', '\x3', 
		'\x2', '\x36', '\x37', '\a', '\x4', '\x2', '\x2', '\x37', '?', '\x3', 
		'\x2', '\x2', '\x2', '\x38', '\x39', '\a', '\t', '\x2', '\x2', '\x39', 
		'?', '\a', '\x11', '\x2', '\x2', ':', ';', '\a', '\n', '\x2', '\x2', ';', 
		'?', '\a', '\x11', '\x2', '\x2', '<', '?', '\a', '\x11', '\x2', '\x2', 
		'=', '?', '\a', '\x10', '\x2', '\x2', '>', '\r', '\x3', '\x2', '\x2', 
		'\x2', '>', '\x12', '\x3', '\x2', '\x2', '\x2', '>', '!', '\x3', '\x2', 
		'\x2', '\x2', '>', '\x30', '\x3', '\x2', '\x2', '\x2', '>', '\x34', '\x3', 
		'\x2', '\x2', '\x2', '>', '\x38', '\x3', '\x2', '\x2', '\x2', '>', ':', 
		'\x3', '\x2', '\x2', '\x2', '>', '<', '\x3', '\x2', '\x2', '\x2', '>', 
		'=', '\x3', '\x2', '\x2', '\x2', '?', 'T', '\x3', '\x2', '\x2', '\x2', 
		'@', '\x41', '\f', '\xE', '\x2', '\x2', '\x41', '\x42', '\a', '\b', '\x2', 
		'\x2', '\x42', 'S', '\x5', '\x4', '\x3', '\xF', '\x43', '\x44', '\f', 
		'\r', '\x2', '\x2', '\x44', '\x45', '\a', '\t', '\x2', '\x2', '\x45', 
		'S', '\x5', '\x4', '\x3', '\xE', '\x46', 'G', '\f', '\f', '\x2', '\x2', 
		'G', 'H', '\a', '\n', '\x2', '\x2', 'H', 'S', '\x5', '\x4', '\x3', '\r', 
		'I', 'J', '\f', '\v', '\x2', '\x2', 'J', 'K', '\a', '\v', '\x2', '\x2', 
		'K', 'S', '\x5', '\x4', '\x3', '\f', 'L', 'M', '\f', '\n', '\x2', '\x2', 
		'M', 'N', '\a', '\f', '\x2', '\x2', 'N', 'S', '\x5', '\x4', '\x3', '\v', 
		'O', 'P', '\f', '\t', '\x2', '\x2', 'P', 'Q', '\a', '\r', '\x2', '\x2', 
		'Q', 'S', '\x5', '\x4', '\x3', '\n', 'R', '@', '\x3', '\x2', '\x2', '\x2', 
		'R', '\x43', '\x3', '\x2', '\x2', '\x2', 'R', '\x46', '\x3', '\x2', '\x2', 
		'\x2', 'R', 'I', '\x3', '\x2', '\x2', '\x2', 'R', 'L', '\x3', '\x2', '\x2', 
		'\x2', 'R', 'O', '\x3', '\x2', '\x2', '\x2', 'S', 'V', '\x3', '\x2', '\x2', 
		'\x2', 'T', 'R', '\x3', '\x2', '\x2', '\x2', 'T', 'U', '\x3', '\x2', '\x2', 
		'\x2', 'U', '\x5', '\x3', '\x2', '\x2', '\x2', 'V', 'T', '\x3', '\x2', 
		'\x2', '\x2', '\b', '\t', '\x1B', '*', '>', 'R', 'T',
	};

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN);


}
