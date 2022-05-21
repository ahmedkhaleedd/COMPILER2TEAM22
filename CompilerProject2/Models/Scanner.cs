using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompilerProject2.Models
{
    public class Scanner
    {
        public string Code { get; set; }
        public int[,] TransitionTable { get; set; }
        public char[] TransitionTableHeader { get; set; }
        public Dictionary<string, string> dict { get; set; }


        List<Token> scannerOutPut = new List<Token>();
        char[] numbers = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        char[] letters = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };


        public List<Token> GetTokens()
        {


            int line = 1; //LineNumber
            int currentState = 0;
            int nextState = 0;
            string lexem = "";

            for (int i = 0; i < Code.Length; i++)
            {

                char z = Code[i]; // character hnmshy beh 3la l code kolo one by one
                char c = z; // character tany feh copy mn z
                if (z == (char)13)
                {
                    line += 1;
                }
                if (numbers.Contains(c))
                {
                    c = '%';
                }
                for (int x = 0; x < TransitionTableHeader.Length; x++)
                {
                    if (c == TransitionTableHeader[x])
                    {
                        int index = x;
                        nextState = TransitionTable[currentState, index];
                        break;
                    }

                }

                currentState = nextState;
                if (z != ' ')
                {
                    lexem += z;
                }

                if (TransitionTable[currentState, 0] == -1)
                {
                    bool isNumber = false;
                    for (int j = 0; j < lexem.Length; j++)
                    {
                        if (numbers.Contains(lexem[j])) // bn-check lw l token deh number 
                        {
                            isNumber = true;
                        }
                        else
                        {
                            isNumber = false;
                            break;
                        }

                    }

                    if (isNumber)
                    {
                        Token token = new Token
                        {
                            Line = line,
                            Type = "Constant", //lw l token deh number hnkhly l type bta3ha constant
                            Name = lexem
                        };

                        scannerOutPut.Add(token); //hn-add l token ll list scannerOutPut ely hn3mlha return fl akher
                        lexem = "";
                        currentState = 0; // reset ll current state
                    }
                    else if (dict.ContainsKey(lexem))
                    {

                        Token token = new Token
                        {
                            Line = line,
                            Type = dict[lexem],
                            Name = lexem
                        };

                        scannerOutPut.Add(token);
                        lexem = "";
                        currentState = 0;
                    }
                    //lw l token btbd2 b  letter aw _ f tb2a identfire
                    else if (letters.Contains(lexem[0]) || lexem[0] == '_')
                    {
                        Token token = new Token
                        {
                            Line = line,
                            Type = "Identifire", //hnkhly l type bta3 l token Identifire
                            Name = lexem
                        };
                        //add token to scannerOutput list
                        scannerOutPut.Add(token);
                        lexem = "";
                        currentState = 0;
                    }
                    else //lw mtl3tsh haga m
                    {
                        Token token = new Token
                        {
                            Line = line,
                            Type = "Error",
                            Name = lexem
                        };
                        scannerOutPut.Add(token);
                        lexem = "";
                        currentState = 0;

                    }
                }

                if (c == '\n')
                {
                    lexem = "";
                }
                if (TransitionTable[currentState, 0] != -1 && lexem != "" && (c == ' ' || c == '\n' || c == '\t'))
                {

                    Token token = new Token
                    {
                        Line = line,
                        Type = "Error",
                        Name = lexem
                    };

                    scannerOutPut.Add(token);
                    lexem = "";
                    currentState = 0;

                }

            }
            return scannerOutPut;
        }
    }
}

