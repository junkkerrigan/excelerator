grammar ArithmeticGrammar;

/*
 * Parser Rules
 */

expression : component+ EOF;

component 
    : '(' component ')' #Parenthesis
	| 'min(' (component ',') (component ',')* component ')' #Minimum
	| 'max(' (component ',') (component ',')* component ')' #Maximum
	| component '^' component #Power
	| component '+' component #Addition
	| component '-' component #Substraction
	| component '*' component #Multiplication
	| component '/' component #Division
	| component '%' component #Modulo
	| '+(' component ')' #UnaryPlusParenthesis
	| '-(' component ')' #UnaryMinusParenthesis
	| '+' NUMBER #UnaryPlusNumber
	| '-' NUMBER #UnaryMinusNumber
	| NUMBER #Number
	| CELL #Cell
	;

/*
 * Lexer Rules
 */

CELL : (CHAR)+ NUMBER;
NUMBER : ('0'..'9')+;
CHAR : ('A'..'Z');

WHITESPACE : (' '|'\t') -> skip;
