using BoardGraph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NemesisLibrary
{


    public class IntruderAttackCard : AttackCard
    {

        public IntruderAttackCard(string name, int life, Type[] types, Action<AttackCard, Board> attack) : base(name, life, types.TypeToString(), attack)
        {

        }

        public override bool Hits()
        {
            if (name == Type.larvae.ToString())
            {
                attack = (card, board) => 
                {
                    board.targets.Remove(card.enemy);
                    if(player.infested)
                    {
                        //todo
                        throw new Exception("IntruderAttackCard: game crash because player died from a chest-burster and we can't handle that yet");
                    }
                    else
                    {
                        card.player.infested = true;
                        var contaminationCard = board.contaminations.Pick();
                        card.player.deck.Discards.Add(contaminationCard);
                    }
                };
                return true;
            }
            else
                return base.Hits();
        }
    }

    public static class IntruderAttackCardDeck
    {

        public static Queue<AttackCard> GenerateCards(Queue<AttackCard> cards)
        {
            cards.Enqueue(new IntruderAttackCard("Summoning", 3, IntruderGroups.Get(Type.creeper, Type.queen), AttackCardEffects.Summoning));
            cards.Enqueue(new IntruderAttackCard("Transformation", 4, IntruderGroups.Get(Type.creeper), AttackCardEffects.Transformation));
            cards.Enqueue(new IntruderAttackCard("Transformation", 5, IntruderGroups.Get(Type.creeper), AttackCardEffects.Transformation));
            cards.Enqueue(new IntruderAttackCard("Scratch", 2, IntruderGroups.All(), AttackCardEffects.Scratch));
            cards.Enqueue(new IntruderAttackCard("Scratch", 3, IntruderGroups.All(), AttackCardEffects.Scratch));
            cards.Enqueue(new IntruderAttackCard("Scratch", 5, IntruderGroups.All(), AttackCardEffects.Scratch));
            cards.Enqueue(new IntruderAttackCard("Scratch", 6, IntruderGroups.All(), AttackCardEffects.Scratch));
            cards.Enqueue(new IntruderAttackCard("Frenzy", 3, IntruderGroups.Get(Type.breeder, Type.queen), AttackCardEffects.Frenzy));
            cards.Enqueue(new IntruderAttackCard("Frenzy", 4, IntruderGroups.Get(Type.breeder, Type.queen), AttackCardEffects.Frenzy));
            cards.Enqueue(new IntruderAttackCard("Bite", 4, IntruderGroups.AdultUp(), AttackCardEffects.Bite));
            cards.Enqueue(new IntruderAttackCard("Bite", 4, IntruderGroups.AdultUp(), AttackCardEffects.Bite));
            cards.Enqueue(new IntruderAttackCard("Bite", 6, IntruderGroups.AdultUp(), AttackCardEffects.Bite));
            cards.Enqueue(new IntruderAttackCard("Bite", 0, IntruderGroups.AdultUp(), AttackCardEffects.Bite));
            cards.Enqueue(new IntruderAttackCard("TailAttack", 2, IntruderGroups.Queen(), AttackCardEffects.TailAttack));
            cards.Enqueue(new IntruderAttackCard("TailAttack", 5, IntruderGroups.Queen(), AttackCardEffects.TailAttack));
            cards.Enqueue(new IntruderAttackCard("Slime", 5, IntruderGroups.All(), AttackCardEffects.Slime));
            cards.Enqueue(new IntruderAttackCard("ClawAttack", 3, IntruderGroups.AdultUp(), AttackCardEffects.ClawAttack));
            cards.Enqueue(new IntruderAttackCard("ClawAttack", 4, IntruderGroups.AdultUp(), AttackCardEffects.ClawAttack));
            cards.Enqueue(new IntruderAttackCard("ClawAttack", 5, IntruderGroups.AdultUp(), AttackCardEffects.ClawAttack));
            cards.Enqueue(new IntruderAttackCard("ClawAttack", 0, IntruderGroups.AdultUp(), AttackCardEffects.ClawAttack));

            cards.ShuffleQue();
            return cards;
        }
    }

    public class IntruderGroups
    {
        public static Type[] Get(params Type[] types)
        {
            return types;
        }

        public static Type[] All()
        {
            return Get(Type.creeper, Type.adult, Type.breeder, Type.queen);
        }

        public static Type[] Queen()
        {
            return Get(Type.queen);
        }

        public static Type[] AdultUp()
        {
            return Get(Type.adult, Type.breeder, Type.queen);
        }
    }

    public static class AttackCardEffects
    {

        public static Action<AttackCard, Board> Summoning = (card, board) => { };
        public static Action<AttackCard, Board> Transformation = (card, board) => { };
        public static Action<AttackCard, Board> Scratch = (card, board) => { };
        public static Action<AttackCard, Board> Frenzy = (card, board) => { };
        public static Action<AttackCard, Board> Bite = (card, board) => { };
        public static Action<AttackCard, Board> TailAttack = (card, board) => { };
        public static Action<AttackCard, Board> Slime = (card, board) => { };
        public static Action<AttackCard, Board> ClawAttack = (card, board) => { };

    }





}
