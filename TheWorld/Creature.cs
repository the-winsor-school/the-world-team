using System;
using System.Collections.Generic;

namespace TheWorld
{
	/// <summary>
	/// A Creature that lives in the World.
	/// </summary>
	public class Creature
	{
        /// <summary>
        /// Creature's name
        /// </summary>
		public string Name
		{
			get;
			set;
		}

        /// <summary>
        /// Creature's description.
        /// </summary>
		public string Description
		{
			get;
			set;
		}

		/// <summary>
		/// Article (and sometimes verb) used before area
		/// </summary>
		public string Article
		{
			get;
			set;
		}

		/// <summary>
		/// Stats of the creature.
		/// </summary>
		public StatChart Stats
		{
			get;
			set;
		}

		// TODO:  Moderate Achievement
		// Give Creatures an Inventory (much like the Player's Backpack)
		// When the Creature is defeated, these Items should then drop into the
		// CurrentArea for the Player to be able to PickUp.
		// (That logic will be added to the ProcessFightCommand method in the Win case.)
		public Dictionary<string, ICarryableItem> Inventory {
			get;
			set;
		}
        public void creatureDefeated()
        {
            foreach (string itemName in this.Inventory.Keys)
			{
				ICarryableItem item = this.Inventory[itemName];
				TheGame.CurrentArea.AddItem((Item)item, itemName);
			}

		}
	}
}

