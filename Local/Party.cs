using Dhondt.Local;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dhondt
{
    public class Party : VoteEssentials, IVoteable
    {
        public Party(int voteAmount, string name)
        {
            this.vote = voteAmount;
            this.name = name;
        }

        public string Name()
        {
            return name + " Party";
        }

        public void SubmitVote(int amount)
        {
            vote += amount;
        }

        public float Votes()
        {
            return vote / (parlamentarian + 1);
        }

        public void ResetPartyData()
        {
            parlamentarian = 0;
        }
    }
}
