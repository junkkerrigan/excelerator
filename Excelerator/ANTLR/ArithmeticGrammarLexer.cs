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
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using DFA = Antlr4.Runtime.Dfa.DFA;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.7.2")]
[System.CLSCompliant(false)]
public partial class ArithmeticGrammarLexer : Lexer {
	protected static DFA[] decisionToDFA;
	protected static PredictionContextCache sharedContextCache = new PredictionContextCache();
	public const int
		T__0=1, T__1=2, T__2=3, T__3=4, T__4=5, POW=6, MULT=7, DIV=8, PLUS=9, 
		MINUS=10, MOD=11, CELL=12, NUMBER=13, COLTITLE=14, WS=15;
	public static string[] channelNames = {
		"DEFAULT_TOKEN_CHANNEL", "HIDDEN"
	};

	public static string[] modeNames = {
		"DEFAULT_MODE"
	};

	public static readonly string[] ruleNames = {
		"T__0", "T__1", "T__2", "T__3", "T__4", "POW", "MULT", "DIV", "PLUS", 
		"MINUS", "MOD", "CELL", "NUMBER", "COLTITLE", "WS"
	};


	public ArithmeticGrammarLexer(ICharStream input)
	: this(input, Console.Out, Console.Error) { }

	public ArithmeticGrammarLexer(ICharStream input, TextWriter output, TextWriter errorOutput)
	: base(input, output, errorOutput)
	{
		Interpreter = new LexerATNSimulator(this, _ATN, decisionToDFA, sharedContextCache);
	}

	private static readonly string[] _LiteralNames = {
		null, "'('", "')'", "'min('", "','", "'max('", "'^'", "'*'", "'/'", "'+'", 
		"'-'", "'%'"
	};
	private static readonly string[] _SymbolicNames = {
		null, null, null, null, null, null, "POW", "MULT", "DIV", "PLUS", "MINUS", 
		"MOD", "CELL", "NUMBER", "COLTITLE", "WS"
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

	public override string[] ChannelNames { get { return channelNames; } }

	public override string[] ModeNames { get { return modeNames; } }

	public override string SerializedAtn { get { return new string(_serializedATN); } }

	static ArithmeticGrammarLexer() {
		decisionToDFA = new DFA[_ATN.NumberOfDecisions];
		for (int i = 0; i < _ATN.NumberOfDecisions; i++) {
			decisionToDFA[i] = new DFA(_ATN.GetDecisionState(i), i);
		}
	}
	private static char[] _serializedATN = {
		'\x3', '\x608B', '\xA72A', '\x8133', '\xB9ED', '\x417C', '\x3BE7', '\x7786', 
		'\x5964', '\x2', '\x11', 'Q', '\b', '\x1', '\x4', '\x2', '\t', '\x2', 
		'\x4', '\x3', '\t', '\x3', '\x4', '\x4', '\t', '\x4', '\x4', '\x5', '\t', 
		'\x5', '\x4', '\x6', '\t', '\x6', '\x4', '\a', '\t', '\a', '\x4', '\b', 
		'\t', '\b', '\x4', '\t', '\t', '\t', '\x4', '\n', '\t', '\n', '\x4', '\v', 
		'\t', '\v', '\x4', '\f', '\t', '\f', '\x4', '\r', '\t', '\r', '\x4', '\xE', 
		'\t', '\xE', '\x4', '\xF', '\t', '\xF', '\x4', '\x10', '\t', '\x10', '\x3', 
		'\x2', '\x3', '\x2', '\x3', '\x3', '\x3', '\x3', '\x3', '\x4', '\x3', 
		'\x4', '\x3', '\x4', '\x3', '\x4', '\x3', '\x4', '\x3', '\x5', '\x3', 
		'\x5', '\x3', '\x6', '\x3', '\x6', '\x3', '\x6', '\x3', '\x6', '\x3', 
		'\x6', '\x3', '\a', '\x3', '\a', '\x3', '\b', '\x3', '\b', '\x3', '\t', 
		'\x3', '\t', '\x3', '\n', '\x3', '\n', '\x3', '\v', '\x3', '\v', '\x3', 
		'\f', '\x3', '\f', '\x3', '\r', '\x3', '\r', '\x3', '\r', '\x3', '\xE', 
		'\x6', '\xE', '\x42', '\n', '\xE', '\r', '\xE', '\xE', '\xE', '\x43', 
		'\x3', '\xF', '\x6', '\xF', 'G', '\n', '\xF', '\r', '\xF', '\xE', '\xF', 
		'H', '\x3', '\x10', '\x6', '\x10', 'L', '\n', '\x10', '\r', '\x10', '\xE', 
		'\x10', 'M', '\x3', '\x10', '\x3', '\x10', '\x2', '\x2', '\x11', '\x3', 
		'\x3', '\x5', '\x4', '\a', '\x5', '\t', '\x6', '\v', '\a', '\r', '\b', 
		'\xF', '\t', '\x11', '\n', '\x13', '\v', '\x15', '\f', '\x17', '\r', '\x19', 
		'\xE', '\x1B', '\xF', '\x1D', '\x10', '\x1F', '\x11', '\x3', '\x2', '\x3', 
		'\x4', '\x2', '\v', '\v', '\"', '\"', '\x2', 'S', '\x2', '\x3', '\x3', 
		'\x2', '\x2', '\x2', '\x2', '\x5', '\x3', '\x2', '\x2', '\x2', '\x2', 
		'\a', '\x3', '\x2', '\x2', '\x2', '\x2', '\t', '\x3', '\x2', '\x2', '\x2', 
		'\x2', '\v', '\x3', '\x2', '\x2', '\x2', '\x2', '\r', '\x3', '\x2', '\x2', 
		'\x2', '\x2', '\xF', '\x3', '\x2', '\x2', '\x2', '\x2', '\x11', '\x3', 
		'\x2', '\x2', '\x2', '\x2', '\x13', '\x3', '\x2', '\x2', '\x2', '\x2', 
		'\x15', '\x3', '\x2', '\x2', '\x2', '\x2', '\x17', '\x3', '\x2', '\x2', 
		'\x2', '\x2', '\x19', '\x3', '\x2', '\x2', '\x2', '\x2', '\x1B', '\x3', 
		'\x2', '\x2', '\x2', '\x2', '\x1D', '\x3', '\x2', '\x2', '\x2', '\x2', 
		'\x1F', '\x3', '\x2', '\x2', '\x2', '\x3', '!', '\x3', '\x2', '\x2', '\x2', 
		'\x5', '#', '\x3', '\x2', '\x2', '\x2', '\a', '%', '\x3', '\x2', '\x2', 
		'\x2', '\t', '*', '\x3', '\x2', '\x2', '\x2', '\v', ',', '\x3', '\x2', 
		'\x2', '\x2', '\r', '\x31', '\x3', '\x2', '\x2', '\x2', '\xF', '\x33', 
		'\x3', '\x2', '\x2', '\x2', '\x11', '\x35', '\x3', '\x2', '\x2', '\x2', 
		'\x13', '\x37', '\x3', '\x2', '\x2', '\x2', '\x15', '\x39', '\x3', '\x2', 
		'\x2', '\x2', '\x17', ';', '\x3', '\x2', '\x2', '\x2', '\x19', '=', '\x3', 
		'\x2', '\x2', '\x2', '\x1B', '\x41', '\x3', '\x2', '\x2', '\x2', '\x1D', 
		'\x46', '\x3', '\x2', '\x2', '\x2', '\x1F', 'K', '\x3', '\x2', '\x2', 
		'\x2', '!', '\"', '\a', '*', '\x2', '\x2', '\"', '\x4', '\x3', '\x2', 
		'\x2', '\x2', '#', '$', '\a', '+', '\x2', '\x2', '$', '\x6', '\x3', '\x2', 
		'\x2', '\x2', '%', '&', '\a', 'o', '\x2', '\x2', '&', '\'', '\a', 'k', 
		'\x2', '\x2', '\'', '(', '\a', 'p', '\x2', '\x2', '(', ')', '\a', '*', 
		'\x2', '\x2', ')', '\b', '\x3', '\x2', '\x2', '\x2', '*', '+', '\a', '.', 
		'\x2', '\x2', '+', '\n', '\x3', '\x2', '\x2', '\x2', ',', '-', '\a', 'o', 
		'\x2', '\x2', '-', '.', '\a', '\x63', '\x2', '\x2', '.', '/', '\a', 'z', 
		'\x2', '\x2', '/', '\x30', '\a', '*', '\x2', '\x2', '\x30', '\f', '\x3', 
		'\x2', '\x2', '\x2', '\x31', '\x32', '\a', '`', '\x2', '\x2', '\x32', 
		'\xE', '\x3', '\x2', '\x2', '\x2', '\x33', '\x34', '\a', ',', '\x2', '\x2', 
		'\x34', '\x10', '\x3', '\x2', '\x2', '\x2', '\x35', '\x36', '\a', '\x31', 
		'\x2', '\x2', '\x36', '\x12', '\x3', '\x2', '\x2', '\x2', '\x37', '\x38', 
		'\a', '-', '\x2', '\x2', '\x38', '\x14', '\x3', '\x2', '\x2', '\x2', '\x39', 
		':', '\a', '/', '\x2', '\x2', ':', '\x16', '\x3', '\x2', '\x2', '\x2', 
		';', '<', '\a', '\'', '\x2', '\x2', '<', '\x18', '\x3', '\x2', '\x2', 
		'\x2', '=', '>', '\x5', '\x1D', '\xF', '\x2', '>', '?', '\x5', '\x1B', 
		'\xE', '\x2', '?', '\x1A', '\x3', '\x2', '\x2', '\x2', '@', '\x42', '\x4', 
		'\x32', ';', '\x2', '\x41', '@', '\x3', '\x2', '\x2', '\x2', '\x42', '\x43', 
		'\x3', '\x2', '\x2', '\x2', '\x43', '\x41', '\x3', '\x2', '\x2', '\x2', 
		'\x43', '\x44', '\x3', '\x2', '\x2', '\x2', '\x44', '\x1C', '\x3', '\x2', 
		'\x2', '\x2', '\x45', 'G', '\x4', '\x43', '\\', '\x2', '\x46', '\x45', 
		'\x3', '\x2', '\x2', '\x2', 'G', 'H', '\x3', '\x2', '\x2', '\x2', 'H', 
		'\x46', '\x3', '\x2', '\x2', '\x2', 'H', 'I', '\x3', '\x2', '\x2', '\x2', 
		'I', '\x1E', '\x3', '\x2', '\x2', '\x2', 'J', 'L', '\t', '\x2', '\x2', 
		'\x2', 'K', 'J', '\x3', '\x2', '\x2', '\x2', 'L', 'M', '\x3', '\x2', '\x2', 
		'\x2', 'M', 'K', '\x3', '\x2', '\x2', '\x2', 'M', 'N', '\x3', '\x2', '\x2', 
		'\x2', 'N', 'O', '\x3', '\x2', '\x2', '\x2', 'O', 'P', '\b', '\x10', '\x2', 
		'\x2', 'P', ' ', '\x3', '\x2', '\x2', '\x2', '\x6', '\x2', '\x43', 'H', 
		'M', '\x3', '\b', '\x2', '\x2',
	};

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN);


}
