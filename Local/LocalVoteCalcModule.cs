using Dhondt.Local;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dhondt
{
    public class LocalVoteCalcModule
    {
        public LocalVoteCalcModule() {
            int chapter = 1;
            while (true)
            {
                Console.WriteLine("----------------------------Chapter " + chapter);

                State state1 = new State();
                Console.Write("Amount of seats:");
                state1.slot = int.Parse(Console.ReadLine());
                Console.Write("Amount of parties:");
                int amount = int.Parse(Console.ReadLine());

                List<Party> parties = new List<Party>();
                for(int i = 0; i < amount; i++)
                {
                    parties.Add(CreateParty());
                }

                state1.InsertParties(parties.ToArray());
                CalculateLocal(state1);
                chapter++;
            }
        } 

        public Party CreateParty()
        {
            Console.WriteLine("--Making a new party--");
            Console.Write("Insert the name of the party:");
            string name = Console.ReadLine();

            Console.Write("Insert vote amount:");
            int vote = int.Parse(Console.ReadLine());

            Party party = new Party(vote, name);
            return party;
        }

        public State[] CalculateParlamentarian(State[] states)
        {
            foreach (var item in states)
            {
                CalculateLocal(item);
            }

            return states;
        } 

        public void CalculateLocal(State state)
        {
            state.ResetAllPartyData();
            OnStart(state, state.slot);

            for (int i = 0; i < state.slot; i++)
            {
                Party ps = GetHighest(state.parties);
                ps.parlamentarian++;
                OnParlamentarianInsert(ps, state, i+1);
            }

            foreach (var party in state.parties)
            {

                if (party.parlamentarian > 0) Console.WriteLine("-" + party.Name() + " has " + party.parlamentarian + " amount of parlamentarian, and the percentage is " + YuzdeKarsilastir(state.slot, party.parlamentarian) + "%");
            }
        }

        public void OnStart(State state, int totalParlamentarian)
        {
            foreach (var party in state.parties)
            {
                Console.WriteLine("-" + party.Name() + " has " + party.Votes()+" amount of vote");
            }

            Console.WriteLine("\n");
            Console.WriteLine("*Total amount of seats is " + totalParlamentarian);
            Console.WriteLine("\n");
        }
        public void OnParlamentarianInsert(Party ps, State state, int currentParlamentarian)
        {
            //Console.WriteLine(ps.Name() + " got a new parlamentarian by " + ps.Votes() + " votes");
            //Console.WriteLine("\n");
        }
        static float YuzdeKarsilastir(int a, int b)
        {
            //Console.WriteLine("DBG = " + a + " " + b);
            if (a == 0)
            {
                //Console.Write("Zero");
                return 0;
            }

            float oran = (((float)b / (float)a))*100;
            //Console.WriteLine(oran);
            return float.Round(oran, 2);
        }

        public Party GetHighest(Party[] parties)
        {
            Party highest = null;
            foreach (var item in parties)
            {
                if (highest == null)
                {
                    highest = item;
                    continue;
                }

                float highestVotePoint = highest.vote / (highest.parlamentarian + 1);
                float votePoint = item.vote / (item.parlamentarian + 1);

                if(votePoint > highestVotePoint)
                {
                    highest = item;
                    continue;
                }
            }

            return highest;
        }

    }
}
