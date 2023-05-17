using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dhondt.Local
{
    public class State : VoteEssentials, IVoteable
    {
        public Party[] parties = new Party[4];
        public int slot = 5;
        public string Name()
        {
            return name + " State";
        }

        public void SubmitVote(int amount)
        {
            vote = amount;
        }

        public float Votes()
        {
            return vote;
        }

        public void ResetAllPartyData()
        {
            foreach (var item in parties)
            {
                item.ResetPartyData();
            }
        }

        public void InsertParties(Party[] parties)
        {
            this.parties = parties;
        }
    }
}
