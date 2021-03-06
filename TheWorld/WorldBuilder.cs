﻿using System;
using System.Collections.Generic;

namespace TheWorld
{
	/// <summary>
	/// World builder is responsible for all World creation.  
	/// It is a static class because it is only used once at the beginning of the program to construct the world.
    ///
    /// TODO:  Create your own world!
    ///
    /// TODO:  Easy Achievement (1):
    /// Create 4 Areas which are linked together somehow.
    ///
    /// TODO:  Easy Achievement (2):
    /// Populate each of your Areas with at least 2 Objects that the player can interact with.
    ///
    /// TODO:  Easy Achievement (3):
    /// Create an Area which is accessible by a one-way entrance.
    /// (i.e. You fall through a hole and must find another way out)
    ///
    /// TODO:  Easy Achievement (4):
    /// Draw a Map of your World on Paper or in a graphics program.
    /// Doesn't have to be crazy art work, just a visual representation of how
    /// the world is connected together.  Can be completely conceptual. 
    /// This is sometimes called "Story boarding"
    /// 
	/// </summary>
	public static class WorldBuilder
	{
		/// <summary>
		/// Builds the world. This is the method where you design your world.  Create Areas, Populate those Areas, and then link those areas together.
		/// If an area is particularly complicated, you may consider writing a helper method to break that part out.
		/// 
		/// This method returns the starting Area which is linked to the rest of the World.
		/// </summary>
		/// <returns>The starting area linked to the rest of the world.</returns>
		public static Area BuildWorld()
		{
			// This is going to be the area where the player starts.
			Area start = new Area() { Name = "the field", Article = "is", Description = "A wide grassy field with not much to see." };

			// I can create a new Item and add it directly into the Area without having a separate variable for it!  Convenient!
			start.AddItem(new Item()
			{
				Name = "boulder",
				Description = "It's a big granite boulder.  It has a weird glyph carved into it, but you can't make any sense of it.",
				Article = " a"
			},
				"boulder"
			);

			// Doing it again--no separate variable for the new item.  It goes directly into the created area.
			start.AddItem(new Item()
			{
				Name = "grass",
				Description = "Grass... Lots of Grass... Like... Everywhere. Pretty good grass though.",
				Article = ""
			},
				"grass"
			);

			// I can do that with any kind of object that I can create entirely in one command.
			// Don't forget that last word is the Unique Identifier.  So I can't have more than one thing in my area named "bunny"
			start.AddCreature(new Creature()
			{
				Name = "bunny Rabbit",
				Description = "A cute bunny.  Looks pretty tasty actually...",
				Stats = new StatChart() { Level = 1, MaxHPs = 10, HPs = 10, Atk = new Dice(Dice.Type.D4), Def = new Dice(Dice.Type.D4), Exp = 3 },
				Article = " a",
        Inventory = new Dictionary<string, ICarryableItem>() { { "potion", new HealingPotion() } }
			},
				"bunny"
			);

			// Here's a second area.
			Area stream = new Area()
			{
				Name = "stream",
				Description = "A burbling stream.  There are some rocks that look like you could cross them to get to the other side.",
				Article = "is a"
			};

			// I will populate it with items and creatures in the same way...
			stream.AddItem(new Item()
			{
				Name = "lizard",
				Description = "A funny lizard with a black stripe down its back.  It doesn't look intimidated by your presence," +
					" but it doesn't look very interested either. Upon closer inspection, it might not be alive...",
				Article = " a"
			},
				"lizard"
			); 

			stream.AddCreature(new Creature()
			{
				Name = "frog",
				Description = "A crazy big frog!  It looks like it could eat a bird if it caught one.  It also doesn't look happy.",
				Stats = new StatChart() { MaxHPs = 10, HPs = 10, Atk = new Dice(Dice.Type.D6), Def = new Dice(Dice.Type.D4), Level = 1, Exp = 5 },
				Article = " a"
			},
				"frog"
			);
			//a well! this will lead to wonderland
			Area well = new Area()
			{
				Name = "well",
				Description = "It's a well! Round, has a roof, filled with water. Definitely a well.",
				Article = "is a"
			};

			well.AddItem(new Item()
			{
				Name = "bucket",
				Description = "A metal bucket. Some dirty old water inside it. Kind of gross.",
				Article = " a"
			},
				"bucket"
			);


			well.AddCreature(new Creature()
			{
				Name = "fish",
				Description = "A brown and tiny fish. It doesn't look very tasty.",
				Stats = new StatChart() { MaxHPs = 5, HPs = 5, Atk = new Dice(Dice.Type.D6), Def = new Dice(Dice.Type.D4), Level = 1, Exp = 5 },
				Article = " a"
			},
				"fish"
			);

			//the entrance to a great city
			Area cityGates = new Area()
			{
				Name = "city_gates",
				Description = "You approach the entrance to a city. The city's walls stretch to the edge of the horizon, and there is a large iron gate.",
				Article = "are"
				//make it so that you have to kill the lions to get into the city
			};

			cityGates.AddCreature(new Creature()
			{
				Name = "stone_lion",
				Description = "A large stone lion. But it seems almost alive - and dangerous",
				Stats = new StatChart() { MaxHPs = 20, HPs = 20, Atk = new Dice(Dice.Type.D6), Def = new Dice(Dice.Type.D4), Level = 1, Exp = 5 },
				Article = " a"
			},
				"stone_lion"
			);

			Area hospitalRuins = new Area()
			{
				Name = "hospital_ruins",
				Description = "You see the remains of a hospital. Something bad seems to have happened here - no natural wear and tear could cause this",
				Article = "are"
			};

			cityGates.AddItem(new IronGate()
			{
				Name = "iron_gate",
				Description = "This gate blocks access to the interior of the city.",
				Article = " an",
				TargetArea = hospitalRuins
			},
				"iron_gate"
			) ;


			hospitalRuins.AddItem(new Item()
			{
				Name = "broken_stethoscope",
				Description = "A large stone door guards the entrance to the city. You try to open it, but you cannot. There is no key-hole.",
				Article = " a"
			},
				"door"
			);

			// making the one way area (the magical city that you can only get to by falling into the well
			Area wonderland = new Area()
			{
				Name = "wonderland",
				Description = "You fall into a lush field. Everything looks a little more vibrant, unworldly, even",
				Article = "the"
			};

			wonderland.AddCreature(new Creature()
			{
				Name = "gigantic butterflies",
				Description = "Massive, colorful butterflies are floating through the sky, bobbing like balloons",
				Stats = new StatChart() { MaxHPs = 3, HPs = 3, Atk = new Dice(Dice.Type.D6), Def = new Dice(Dice.Type.D4), Level = 1, Exp = 5 },
				Article = ""
			},
                 "gigantic butterflies"
			);
			//I think we should make these creatures only accessible at a higher level but we should make sure that you can only fall into the well at the same level
			wonderland.AddCreature(new Creature()
			{
				Name = "dragons",
				Description = "Three dragons, two adults and one baby. They seem peaceful but powerful.",
				Stats = new StatChart() { MaxHPs = 3, HPs = 3, Atk = new Dice(Dice.Type.D6), Def = new Dice(Dice.Type.D4), Level = 1, Exp = 5 },
				Article = "some"
			},
				"dragons"
			);

			wonderland.AddItem(new Item()
			{
				Name = "scroll",
				Description = "A scroll smothered with dirt. It is faded and you can only make out the words palace and sky",
				Article = "a"
			},
				"scroll"
			);


			// These two lines LINK the two areas together. Don't forget to go both ways or you'll end up with a dead end
			// and no way out!!!
			well.AddNeighbor(stream, "east");
			stream.AddNeighbor(well, "west");
			stream.AddNeighbor(cityGates, "east");
			cityGates.AddNeighbor(stream, "west");
			start.AddNeighbor(stream, "north");
			stream.AddNeighbor(start, "south");
			well.AddNeighbor(wonderland, "inside");

            // Go back to the Main method and tell it where to start the game!
			return start;
		}
	}
}

