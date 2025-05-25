using System.Windows.Forms;
using System;
using System.IO;
using System.Runtime.Serialization;
using com.calitha.goldparser.lalr;
using com.calitha.commons;

namespace com.calitha.goldparser
{

    [Serializable()]
    public class SymbolException : System.Exception
    {
        public SymbolException(string message) : base(message)
        {
        }

        public SymbolException(string message,
            Exception inner) : base(message, inner)
        {
        }

        protected SymbolException(SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }

    }

    [Serializable()]
    public class RuleException : System.Exception
    {

        public RuleException(string message) : base(message)
        {
        }

        public RuleException(string message,
                             Exception inner) : base(message, inner)
        {
        }

        protected RuleException(SerializationInfo info,
                                StreamingContext context) : base(info, context)
        {
        }

    }

    enum SymbolConstants : int
    {
        SYMBOL_EOF = 0, // (EOF)
        SYMBOL_ERROR = 1, // (Error)
        SYMBOL_WHITESPACE = 2, // Whitespace
        SYMBOL_LPAREN = 3, // '('
        SYMBOL_RPAREN = 4, // ')'
        SYMBOL_SEMI = 5, // ';'
        SYMBOL_LBRACE = 6, // '{'
        SYMBOL_RBRACE = 7, // '}'
        SYMBOL_LTTILDE = 8, // '<~'
        SYMBOL_AND = 9, // and
        SYMBOL_AS = 10, // as
        SYMBOL_BE = 11, // be
        SYMBOL_BOOLEAN = 12, // Boolean
        SYMBOL_CYCLE = 13, // cycle
        SYMBOL_FLAG = 14, // flag
        SYMBOL_FROM = 15, // from
        SYMBOL_GREATER = 16, // greater
        SYMBOL_IDENTIFIER = 17, // Identifier
        SYMBOL_INTEGER = 18, // Integer
        SYMBOL_IS = 19, // is
        SYMBOL_LESS = 20, // less
        SYMBOL_LET = 21, // let
        SYMBOL_MINUS = 22, // minus
        SYMBOL_NEGATIVE = 23, // negative
        SYMBOL_NOT_SAME = 24, // 'not_same'
        SYMBOL_NUMBER = 25, // number
        SYMBOL_OR = 26, // or
        SYMBOL_OTHERWISE = 27, // otherwise
        SYMBOL_OVER = 28, // over
        SYMBOL_PLUS = 29, // plus
        SYMBOL_REPEAT = 30, // repeat
        SYMBOL_SAME = 31, // same
        SYMBOL_SHOW = 32, // show
        SYMBOL_STRINGLITERAL = 33, // StringLiteral
        SYMBOL_TEXT = 34, // text
        SYMBOL_THEN = 35, // then
        SYMBOL_TIMES = 36, // times
        SYMBOL_TO = 37, // to
        SYMBOL_UNTIL = 38, // until
        SYMBOL_WHEN = 39, // when
        SYMBOL_ADDEXP = 40, // <AddExp>
        SYMBOL_ASSIGNMENT = 41, // <Assignment>
        SYMBOL_COMPAREEXP = 42, // <CompareExp>
        SYMBOL_CONDITION = 43, // <Condition>
        SYMBOL_DECLARATION = 44, // <Declaration>
        SYMBOL_EXPRESSION = 45, // <Expression>
        SYMBOL_LOGICALEXP = 46, // <LogicalExp>
        SYMBOL_LOGICALEXPTAIL = 47, // <LogicalExpTail>
        SYMBOL_LOOP = 48, // <Loop>
        SYMBOL_MULTEXP = 49, // <MultExp>
        SYMBOL_NEGATEEXP = 50, // <NegateExp>
        SYMBOL_OUTPUT = 51, // <Output>
        SYMBOL_PROGRAM = 52, // <Program>
        SYMBOL_RELATION = 53, // <Relation>
        SYMBOL_STATEMENT = 54, // <Statement>
        SYMBOL_STATEMENTLIST = 55, // <StatementList>
        SYMBOL_TYPE = 56, // <Type>
        SYMBOL_VALUE = 57  // <Value>
    };

    enum RuleConstants : int
    {
        RULE_PROGRAM = 0, // <Program> ::= <StatementList>
        RULE_STATEMENTLIST = 1, // <StatementList> ::= <Statement>
        RULE_STATEMENTLIST2 = 2, // <StatementList> ::= <StatementList> <Statement>
        RULE_STATEMENT = 3, // <Statement> ::= <Declaration>
        RULE_STATEMENT2 = 4, // <Statement> ::= <Assignment>
        RULE_STATEMENT3 = 5, // <Statement> ::= <Condition>
        RULE_STATEMENT4 = 6, // <Statement> ::= <Loop>
        RULE_STATEMENT5 = 7, // <Statement> ::= <Output>
        RULE_DECLARATION_LET_IDENTIFIER_BE_AS_SEMI = 8, // <Declaration> ::= let Identifier be <Type> as <Expression> ';'
        RULE_DECLARATION_LET_IDENTIFIER_BE_SEMI = 9, // <Declaration> ::= let Identifier be <Type> ';'
        RULE_TYPE_NUMBER = 10, // <Type> ::= number
        RULE_TYPE_TEXT = 11, // <Type> ::= text
        RULE_TYPE_FLAG = 12, // <Type> ::= flag
        RULE_ASSIGNMENT_IDENTIFIER_LTTILDE_SEMI = 13, // <Assignment> ::= Identifier '<~' <Expression> ';'
        RULE_CONDITION_WHEN_THEN_LBRACE_RBRACE = 14, // <Condition> ::= when <Expression> then '{' <StatementList> '}'
        RULE_CONDITION_WHEN_THEN_LBRACE_RBRACE_OTHERWISE_LBRACE_RBRACE = 15, // <Condition> ::= when <Expression> then '{' <StatementList> '}' otherwise '{' <StatementList> '}'
        RULE_LOOP_CYCLE_IDENTIFIER_FROM_TO_LBRACE_RBRACE = 16, // <Loop> ::= cycle Identifier from <Expression> to <Expression> '{' <StatementList> '}'
        RULE_LOOP_REPEAT_UNTIL_LBRACE_RBRACE = 17, // <Loop> ::= repeat until <Expression> '{' <StatementList> '}'
        RULE_EXPRESSION = 18, // <Expression> ::= <LogicalExp>
        RULE_LOGICALEXP = 19, // <LogicalExp> ::= <CompareExp> <LogicalExpTail>
        RULE_LOGICALEXPTAIL_AND = 20, // <LogicalExpTail> ::= and <CompareExp> <LogicalExpTail>
        RULE_LOGICALEXPTAIL_OR = 21, // <LogicalExpTail> ::= or <CompareExp> <LogicalExpTail>
        RULE_COMPAREEXP_IS = 22, // <CompareExp> ::= <AddExp> is <Relation> <AddExp>
        RULE_COMPAREEXP = 23, // <CompareExp> ::= <AddExp>
        RULE_RELATION_GREATER = 24, // <Relation> ::= greater
        RULE_RELATION_LESS = 25, // <Relation> ::= less
        RULE_RELATION_SAME = 26, // <Relation> ::= same
        RULE_RELATION_NOT_SAME = 27, // <Relation> ::= 'not_same'
        RULE_ADDEXP_PLUS = 28, // <AddExp> ::= <AddExp> plus <MultExp>
        RULE_ADDEXP_MINUS = 29, // <AddExp> ::= <AddExp> minus <MultExp>
        RULE_ADDEXP = 30, // <AddExp> ::= <MultExp>
        RULE_MULTEXP_TIMES = 31, // <MultExp> ::= <MultExp> times <NegateExp>
        RULE_MULTEXP_OVER = 32, // <MultExp> ::= <MultExp> over <NegateExp>
        RULE_MULTEXP = 33, // <MultExp> ::= <NegateExp>
        RULE_NEGATEEXP_NEGATIVE = 34, // <NegateExp> ::= negative <Value>
        RULE_NEGATEEXP = 35, // <NegateExp> ::= <Value>
        RULE_VALUE_IDENTIFIER = 36, // <Value> ::= Identifier
        RULE_VALUE_INTEGER = 37, // <Value> ::= Integer
        RULE_VALUE_STRINGLITERAL = 38, // <Value> ::= StringLiteral
        RULE_VALUE_BOOLEAN = 39, // <Value> ::= Boolean
        RULE_VALUE_LPAREN_RPAREN = 40, // <Value> ::= '(' <Expression> ')'
        RULE_OUTPUT_SHOW_SEMI = 41  // <Output> ::= show <Expression> ';'
    };

    public class MyParser
    {
        private LALRParser parser;

        ListBox errorListBox;
        ListBox lexListBox;

        public MyParser(string filename, ListBox error, ListBox lex)
        {
            FileStream stream = new FileStream(filename,
                                            FileMode.Open,
                                            FileAccess.Read,
                                            FileShare.Read);

            errorListBox = error;
            lexListBox = lex;

            Init(stream);
            stream.Close();
        }

        public MyParser(string baseName, string resourceName)
        {
            byte[] buffer = ResourceUtil.GetByteArrayResource(
                System.Reflection.Assembly.GetExecutingAssembly(),
                baseName,
                resourceName);
            MemoryStream stream = new MemoryStream(buffer);
            Init(stream);
            stream.Close();
        }

        public MyParser(Stream stream)
        {
            Init(stream);
        }

        private void Init(Stream stream)
        {
            CGTReader reader = new CGTReader(stream);
            parser = reader.CreateNewParser();
            parser.TrimReductions = false;
            parser.StoreTokens = LALRParser.StoreTokensMode.NoUserObject;

            parser.OnTokenError += new LALRParser.TokenErrorHandler(TokenErrorEvent);
            parser.OnParseError += new LALRParser.ParseErrorHandler(ParseErrorEvent);
            parser.OnTokenRead += new LALRParser.TokenReadHandler(TokenReadEvent);
        }

        public void Parse(string source)
        {
            NonterminalToken token = parser.Parse(source);
            if (token != null)
            {
                Object obj = CreateObject(token);
                //todo: Use your object any way you like
            }
        }

        private Object CreateObject(Token token)
        {
            if (token is TerminalToken)
                return CreateObjectFromTerminal((TerminalToken)token);
            else
                return CreateObjectFromNonterminal((NonterminalToken)token);
        }

        private Object CreateObjectFromTerminal(TerminalToken token)
        {
            switch (token.Symbol.Id)
            {
                case (int)SymbolConstants.SYMBOL_EOF:
                    //(EOF)
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_ERROR:
                    //(Error)
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_WHITESPACE:
                    //Whitespace
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_LPAREN:
                    //'('
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_RPAREN:
                    //')'
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_SEMI:
                    //';'
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_LBRACE:
                    //'{'
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_RBRACE:
                    //'}'
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_LTTILDE:
                    //'<~'
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_AND:
                    //and
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_AS:
                    //as
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_BE:
                    //be
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_BOOLEAN:
                    //Boolean
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_CYCLE:
                    //cycle
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_FLAG:
                    //flag
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_FROM:
                    //from
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_GREATER:
                    //greater
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_IDENTIFIER:
                    //Identifier
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_INTEGER:
                    //Integer
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_IS:
                    //is
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_LESS:
                    //less
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_LET:
                    //let
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_MINUS:
                    //minus
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_NEGATIVE:
                    //negative
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_NOT_SAME:
                    //'not_same'
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_NUMBER:
                    //number
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_OR:
                    //or
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_OTHERWISE:
                    //otherwise
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_OVER:
                    //over
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_PLUS:
                    //plus
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_REPEAT:
                    //repeat
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_SAME:
                    //same
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_SHOW:
                    //show
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_STRINGLITERAL:
                    //StringLiteral
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_TEXT:
                    //text
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_THEN:
                    //then
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_TIMES:
                    //times
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_TO:
                    //to
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_UNTIL:
                    //until
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_WHEN:
                    //when
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_ADDEXP:
                    //<AddExp>
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_ASSIGNMENT:
                    //<Assignment>
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_COMPAREEXP:
                    //<CompareExp>
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_CONDITION:
                    //<Condition>
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_DECLARATION:
                    //<Declaration>
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_EXPRESSION:
                    //<Expression>
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_LOGICALEXP:
                    //<LogicalExp>
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_LOGICALEXPTAIL:
                    //<LogicalExpTail>
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_LOOP:
                    //<Loop>
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_MULTEXP:
                    //<MultExp>
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_NEGATEEXP:
                    //<NegateExp>
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_OUTPUT:
                    //<Output>
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_PROGRAM:
                    //<Program>
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_RELATION:
                    //<Relation>
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_STATEMENT:
                    //<Statement>
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_STATEMENTLIST:
                    //<StatementList>
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_TYPE:
                    //<Type>
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_VALUE:
                    //<Value>
                    //todo: Create a new object that corresponds to the symbol
                    return null;

            }
            throw new SymbolException("Unknown symbol");
        }

        public Object CreateObjectFromNonterminal(NonterminalToken token)
        {
            switch (token.Rule.Id)
            {
                case (int)RuleConstants.RULE_PROGRAM:
                    //<Program> ::= <StatementList>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_STATEMENTLIST:
                    //<StatementList> ::= <Statement>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_STATEMENTLIST2:
                    //<StatementList> ::= <StatementList> <Statement>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_STATEMENT:
                    //<Statement> ::= <Declaration>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_STATEMENT2:
                    //<Statement> ::= <Assignment>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_STATEMENT3:
                    //<Statement> ::= <Condition>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_STATEMENT4:
                    //<Statement> ::= <Loop>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_STATEMENT5:
                    //<Statement> ::= <Output>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_DECLARATION_LET_IDENTIFIER_BE_AS_SEMI:
                    //<Declaration> ::= let Identifier be <Type> as <Expression> ';'
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_DECLARATION_LET_IDENTIFIER_BE_SEMI:
                    //<Declaration> ::= let Identifier be <Type> ';'
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_TYPE_NUMBER:
                    //<Type> ::= number
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_TYPE_TEXT:
                    //<Type> ::= text
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_TYPE_FLAG:
                    //<Type> ::= flag
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_ASSIGNMENT_IDENTIFIER_LTTILDE_SEMI:
                    //<Assignment> ::= Identifier '<~' <Expression> ';'
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_CONDITION_WHEN_THEN_LBRACE_RBRACE:
                    //<Condition> ::= when <Expression> then '{' <StatementList> '}'
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_CONDITION_WHEN_THEN_LBRACE_RBRACE_OTHERWISE_LBRACE_RBRACE:
                    //<Condition> ::= when <Expression> then '{' <StatementList> '}' otherwise '{' <StatementList> '}'
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_LOOP_CYCLE_IDENTIFIER_FROM_TO_LBRACE_RBRACE:
                    //<Loop> ::= cycle Identifier from <Expression> to <Expression> '{' <StatementList> '}'
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_LOOP_REPEAT_UNTIL_LBRACE_RBRACE:
                    //<Loop> ::= repeat until <Expression> '{' <StatementList> '}'
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_EXPRESSION:
                    //<Expression> ::= <LogicalExp>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_LOGICALEXP:
                    //<LogicalExp> ::= <CompareExp> <LogicalExpTail>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_LOGICALEXPTAIL_AND:
                    //<LogicalExpTail> ::= and <CompareExp> <LogicalExpTail>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_LOGICALEXPTAIL_OR:
                    //<LogicalExpTail> ::= or <CompareExp> <LogicalExpTail>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_COMPAREEXP_IS:
                    //<CompareExp> ::= <AddExp> is <Relation> <AddExp>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_COMPAREEXP:
                    //<CompareExp> ::= <AddExp>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_RELATION_GREATER:
                    //<Relation> ::= greater
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_RELATION_LESS:
                    //<Relation> ::= less
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_RELATION_SAME:
                    //<Relation> ::= same
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_RELATION_NOT_SAME:
                    //<Relation> ::= 'not_same'
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_ADDEXP_PLUS:
                    //<AddExp> ::= <AddExp> plus <MultExp>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_ADDEXP_MINUS:
                    //<AddExp> ::= <AddExp> minus <MultExp>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_ADDEXP:
                    //<AddExp> ::= <MultExp>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_MULTEXP_TIMES:
                    //<MultExp> ::= <MultExp> times <NegateExp>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_MULTEXP_OVER:
                    //<MultExp> ::= <MultExp> over <NegateExp>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_MULTEXP:
                    //<MultExp> ::= <NegateExp>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_NEGATEEXP_NEGATIVE:
                    //<NegateExp> ::= negative <Value>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_NEGATEEXP:
                    //<NegateExp> ::= <Value>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_VALUE_IDENTIFIER:
                    //<Value> ::= Identifier
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_VALUE_INTEGER:
                    //<Value> ::= Integer
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_VALUE_STRINGLITERAL:
                    //<Value> ::= StringLiteral
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_VALUE_BOOLEAN:
                    //<Value> ::= Boolean
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_VALUE_LPAREN_RPAREN:
                    //<Value> ::= '(' <Expression> ')'
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_OUTPUT_SHOW_SEMI:
                    //<Output> ::= show <Expression> ';'
                    //todo: Create a new object using the stored tokens.
                    return null;

            }
            throw new RuleException("Unknown rule");
        }

        private void TokenErrorEvent(LALRParser parser, TokenErrorEventArgs args)
        {
            string message = "Token error with input: '" + args.Token.ToString() + "'";
            //todo: Report message to UI?
        }

        private void ParseErrorEvent(LALRParser parser, ParseErrorEventArgs args)
        {
            string message = "Parse error caused by token: '" + args.UnexpectedToken.ToString() + "In line: " + args.UnexpectedToken.Location.LineNr;
            errorListBox.Items.Add(message);
            string ExTokMessage = "Expexted Token: " + args.ExpectedTokens.ToString();
            errorListBox.Items.Add(ExTokMessage);

            lexListBox.Items.Add(args.UnexpectedToken.ToString());
            //todo: Report message to UI?
        }

        private void TokenReadEvent(LALRParser parser, TokenReadEventArgs args)
        {
            string info = args.Token.Text + "   --->    " + (SymbolConstants)args.Token.Symbol.Id;
            lexListBox.Items.Add(info);
        }
    }
}
