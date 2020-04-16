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
    public class city_gates_key : Item, ICarryableItem, IUseableItem
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
            if (target is iron_gate)
            {
                Item item = (Item)target;
                item.Open = true;
            }
            else
            {
                throw new WorldException(string.Format("You can't open this. It's either a different door or not a door. If it is not a door, why in the gosh darn world would you try to open this? You know better. I'm disapointed in you"), target);
            }
        }
    }
    public class iron_gate: Item, IUseableItem
    {
        /// <summary>
        /// How much does this thing weigh?
        /// What does that even mean?
        /// </summary>

        public bool Open { get; set; }

        /// <summary>
        /// Use this key to open the city gates door
        /// </summary>
        /// <param name="target">target must be of type item.</param>
        public void Use()
        {
            //hnnng fix this
        }
    }
}

