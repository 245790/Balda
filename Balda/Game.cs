using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Balda
{
    class Game
    {
        public FieldState State { get; private set; }
        public Rules Rules { get; private set; }
        public List<Player> Players { get; private set; }
        public Game(string startWord, List<Player> players, Rules rules)
        {
            State = new FieldState(startWord);
            Rules = rules;
            Players = players;
        }
        public SortedDictionary<int, Player> play() 
        {
            while (winCondition()) 
            {
                foreach (Player player in Players) 
                {
                    processPlayer(player);
                }
            }
            return null;        
        }
        private bool winCondition()
        {
            return true;            
        }
        private void processPlayer(Player player)
        {
            Move move = new Move();
            do
            {

            }
            while (move.Action != ActionType.EndTurn && move.Action != ActionType.PassTurn);
        }
    }
}
