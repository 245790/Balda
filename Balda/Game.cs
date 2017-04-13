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
            bool gameEnded = false;
            while (!gameEnded) 
            {
                foreach (Player player in Players) 
                {
                    processPlayer(player);
                    gameEnded = winCondition();
                    if (gameEnded)
                    {
                        break;
                    }
                }
                // highlight the whole move
                // wait 4 secs
            }
            // form a dictionary of players, sorted by their game score
            // return it, not null
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
                player.Strategy.move(State, ref move, Rules);
                switch (move.Action)
                { 
                   
                }
            }
            while (move.Action != ActionType.EndTurn && move.Action != ActionType.PassTurn);
            // if the user chose non-existing word, we should ask him for another word instead of exitting
        }
    }
}
