grammar ArithmeticGrammar;

/*
 * Parser Rules
 */

expression : component+ EOF;

component 
    : '(' component ')' #Parenthesis
	| component '+' component #Addition
	| component '-' component #Substraction
	| component '*' component #Multiplication
	| component '/' component #Division
	| component '^' component #Power
	| component '%' component #Modulo
	| '+(' component ')' #UnaryPlusParenthesis
	| '-(' component ')' #UnaryMinusParenthesis
	| '+' NUMBER #UnaryPlusNumber
	| '-' NUMBER #UnaryMinusNumber
	| 'max(' (component ',') (component ',')* component ')' #Maximum
	| 'min(' (component ',') (component ',')* component ')' #Minimum
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
