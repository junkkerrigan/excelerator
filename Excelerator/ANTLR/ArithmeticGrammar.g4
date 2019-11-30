grammar ArithmeticGrammar;

/*
 * Parser Rules
 */

expression : component EOF;

component 
	: '(' component ')' #Parenthesis
	| component POW component #Power
	| component operatorToken=(DIV|MULT) component #Multiplication
	| component operatorToken=(PLUS|MINUS) component #Addition
	| component MOD component #Modulo
	| '-' NUMBER #NegativeNumber 
	/*| '+(' component ')' #UnaryPlus */ 
	| MINUS component #UnaryMinus 
	| 'min(' (component ',') (component ',')* component ')' #Minimum
	| 'max(' (component ',') (component ',')* component ')' #Maximum
	| NUMBER #Number
	| CELL #Cell
	| SYMBOL #Rest
	;

/*
 * Lexer Rules
 */

POW : '^';
MULT : '*';
DIV : '/';
PLUS : '+';
MINUS : '-';
MOD : '%';
CELL : COLTITLE NUMBER;
NUMBER : ('0'..'9')+;
COLTITLE : ('A'..'Z')+;
WS : (' ' | '\t')+ -> skip;
SYMBOL : .;
