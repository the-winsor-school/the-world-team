using System;
using System.Collections.Generic;

namespace TheWorld
{
	/// <summary>
	/// A generic item in the world
	/// </summary

    // TODO: Moderate Achievement
    // Build a "Book" class which is an Item that is both Carryable and Useable.
    // The Use method should print a short bit of text which is the "Story" or 
    // maybe some Plot element in your game.


    /// <summary>
    /// A key! It opens the city_gates
    /// 
    /// </summary>
    ///

    public class IronGatesKey : Item, ICarryableItem, IUseableItem
    {
        /// <summary>
        /// How much does this thing weigh?
        /// What does that even mean?
        /// </summary>
        public int Weight { get; set; }

        /// <summary>
        /// Use this key to open the city gates door
        /// </summary>
        /// <param name="target">target must be of type item.</param>
        public void Use(ref object target)
        {
            if (target is IronGate)
            {
                ((IronGate)target).Unlocked = true;
            }
            else
            {
                throw new WorldException(string.Format("You can't open this. It's either a different door or not a door. If it is not a door, why in the gosh darn world would you try to open this? You know better. I'm disapointed in you"), target);
            }
        }
        public void Use()
        {
            throw new WorldException(string.Format("Use on what?"));
        }
    }
    public class IronGate: Item, IUseableItem
    {
        /// <summary>
        /// Is it open?
        /// </summary>

        public bool Unlocked { get; set; }

        public Area TargetArea { get; set; }

        public IronGate() { Unlocked = false; }

        /// <summary>
        /// Use this key to open the city gates door
        /// </summary>
        /// <param name="target">target must be of type item.</param>
        public void Use()
        {
            if (Unlocked)
            {
                TheGame.CurrentArea = TargetArea;
            }
        }

        public void Use(ref object target)
        {
            throw new WorldException(string.Format("You can't use the door on {0}", this.Name), target);
        }
    }
}

