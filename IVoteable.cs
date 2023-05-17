using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dhondt
{
    internal interface IVoteable
    {
        float Votes();
        string Name();
        void SubmitVote(int amount);
    }
}
