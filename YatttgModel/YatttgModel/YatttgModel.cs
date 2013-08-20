﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YatttgModel
{
    class YatttgModel : IYatttgFacade
    {
        Player p1_, p2_;

        bool p1Turn;
        Constants.GameState currentGameState_;

        public Nort Nort { get; set; }
        public Cross Cross { get; set; }

        public YatttgModel()
        {
            // Initialize default values.
            p1_ = null;
            p2_ = null;

            // Give Nort and Cross default values.
            Nort = new Nort();
            Cross = new Cross();

            // Initial state is to get player information.
            currentGameState_ = Constants.GameState.PlayerInfo;
        }

        Player IYatttgFacade.CreatePlayer(string name, char marker)
        {
            return PlayerFactory.CreatePlayer(this, name, marker);
        }

        void IYatttgFacade.InitGame(Player p1, Player p2)
        {
            p1_ = p1;
            p2_ = p2;

            // Flip a coin on who should start first.
            p1Turn = RandomFirstTurn();

            // Game is now running.
            currentGameState_ = Constants.GameState.InProgress;
        }

        Constants.GameState IYatttgFacade.MakeMove(Player player, int position)
        {
            // TODO: Making a move logic.

            return currentGameState_;
        }

        Player IYatttgFacade.StartNextTurn()
        {
            // Determine who gets to play next.
            p1Turn = !p1Turn;

            if (p1Turn)
                return p1_;
            else
                return p2_;
        }

        private bool RandomFirstTurn()
        {
            // The maxValue argument is exclusive; not inclusive.
            int r = new Random().Next(0, 2);
            if (r == 0)
                return false;
            else
                return true;
        }
    }
}
