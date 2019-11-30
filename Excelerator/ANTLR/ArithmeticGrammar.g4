grammar ArithmeticGrammar;

/*
 * Parser Rules
 */

expression : component EOF;

component 
	: 'min(' (component ',') (component ',')* component ')' #Minimum
	| 'max(' (component ',') (component ',')* component ')' #Maximum
	| component '^' component #Power
	| component '%' component #Modulo
	| component '+' component #Addition
	| component '-' component #Substraction
	| component '*' component #Multiplication
	| component '/' component #Division
	| '+(' component ')' #UnaryPlusParenthesis
	| '-(' component ')' #UnaryMinusParenthesis
	| '+' NUMBER #UnaryPlusNumber
	| '-' NUMBER #UnaryMinusNumber
    | '(' component ')' #Parenthesis
	| NUMBER #Number
	| CELL #Cell
	;

CELL : COLTITLE NUMBER;
NUMBER : ('0'..'9')+;
COLTITLE : ('A'..'Z')+;
/*
 * Lexer Rules
 */

WHITESPACE : (' '|'\t') -> skip;
