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
				Inventory = new Dictionary<string, ICarryableItem>() { { "potion", new HealingPotion() } },
			},
				"bunny"
			);

			// Here's a second area.
			Area stream = new Area()
			{
				Name = "stream",
				Description = "A burbling stream. There are some rocks that look like you could cross them to get to the other side.",
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
				Stats = new StatChart() { MaxHPs = 8, HPs = 8, Atk = new Dice(Dice.Type.D6), Def = new Dice(Dice.Type.D4), Level = 1, Exp = 5 },
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
				Description = "A metal bucket. Some dirty old water inside it. Kind of gross, like your face.",
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

			Area wide_street = new Area()
			{
				Name = "wide_street",
				Description = "You see a wide, yet abandoned street. Many vehicles must have passed here once, but the street is stark empty now.",
				Article = "a"
			};

			Area hospital_ruins = new Area()
			{
				Name = "hospital_ruins",
				Description = "You see the remains of a hospital. Something bad seems to have happened here - no natural wear and tear could cause this. Your mom could though.",
				Article = "are"
			};

			hospital_ruins.AddItem(new Item()
			{
				Name = "broken_stethoscope",
				Description = "A large stone door guards the entrance to the city. You try to open it, but you cannot. There is no key-hole. You're a faiilure.",
				Article = " a"
			},
				"broken_stethoscope"
			);

			hospital_ruins.AddItem(new Item()
			{
				Name = "broken_stethoscope",
				Description = "A large stone door guards the entrance to the city. You try to open it, but you cannot. There is no key-hole.",
				Article = " a"
			},
				"door"
			);
			cityGates.AddCreature(new Creature()
			{
				Name = "stone_lion",
				Description = "A large stone lion. But it seems almost alive - and dangerous",
				Stats = new StatChart() { MaxHPs = 15, HPs = 15, Atk = new Dice(Dice.Type.D6), Def = new Dice(Dice.Type.D4), Level = 1, Exp = 5 },
				Article = " a"
			},
				"stone_lion"
			);

			cityGates.AddItem(new IronGate()
			{
				Name = "iron_gate",
				Description = "This gate blocks access to the interior of the city.",
				Article = " an",
				TargetArea = wide_street
			},
				"iron_gate"
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
				Stats = new StatChart() { MaxHPs = 20, HPs = 20, Atk = new Dice(Dice.Type.D6), Def = new Dice(Dice.Type.D4), Level = 1, Exp = 5 },
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

			Area alley = new Area()
			{
				Name = "alley",
				Description = "You see a dirty, run down allyway in between two large buildings. The floor is covered with trash and you hear squeaking sounds.",
				Article = " is a"
			};

            alley.AddItem(new Item()
			{
				Name = "broken_glass",
				Description = "There is a lot of broken glass on the ground. Don't step on it.",
				Article = " "
			},
				"broken_glass"
			);

			alley.AddCreature(new Creature()
			{
				Name = "rat",
				Description = "Of all the rats, this is one of the ugliest. It's big, fat, and looks remarkably like your alcoholic uncle.",
				Stats = new StatChart() { MaxHPs = 7, HPs = 7, Atk = new Dice(Dice.Type.D6), Def = new Dice(Dice.Type.D4), Level = 1, Exp = 5 },
				Article = " a"
			},
				"rat"
			);

			alley.AddCreature(new Creature()
			{
				Name = "racoon",
				Description = "He looks like you when you try to put on eyeshadow. Kind of hot.",
				Stats = new StatChart() { MaxHPs = 10, HPs = 10, Atk = new Dice(Dice.Type.D6), Def = new Dice(Dice.Type.D4), Level = 1, Exp = 5 },
				Article = " a"
			},
				"racoon"
			);

			alley.AddItem(new Item()
			{
				Name = "old_candy_wrapper",
				Description = "It's just an old candy wrapper. It doens't even look like it was good candy.",
				Article = " an"
			},
				"old_candy_wrapper"
			);

			Area abandoned_supermarket = new Area()
			{
				Name = "abandoned_supermarket",
				Description = "You see a supermarket with next to no food on the shelves. The shelves are upended and trash is spread all over, as if the supermarket had been raided.",
				Article = " is an"
			};

			abandoned_supermarket.AddItem(new Item()
			{
				Name = "can_of_spam",
				Description = "One of the only food items left in the supermarket is an unopened can of spam underneath an upterned shelf. You can open it if you want, but it seems like it's been here a long time.",
				Article = " "
			},
				"can_of_spam"
			);

			Area abandoned_coffee_shop = new Area()
			{
				Name = "abandoned_coffee_shop",
				Description = "When you look closely at this quaint little coffee shop, a feeling of unease washes over you.",
				Article = " is an"
			};

			abandoned_coffee_shop.AddItem(new Item()
			{
				Name = "packet_of_sugar",
				Description = "Wow, it's not even real sugar. This place SUCKS.",
				Article = " "
			},
				"packet_of_sugar"
			);

			abandoned_coffee_shop.AddCreature(new Creature()
			{
				Name = "rat",
				Description = "It's a rat. What more can I say.",
				Stats = new StatChart() { MaxHPs = 7, HPs = 7, Atk = new Dice(Dice.Type.D6), Def = new Dice(Dice.Type.D4), Level = 1, Exp = 5 },
				Article = " a"
			},
				"rat"
			);

			Area pothole = new Area()
			{
				Name = "pothole",
				Description = "This is a gosh-darn large pothole.",
				Article = " is an"
			};

			pothole.AddCreature(new Creature()
			{
				Name = "worm",
				Description = "It's a worm! I'm going to name him wormy. You can name it whatever you want, but just know that you're a failure to your parents.",
				Stats = new StatChart() { MaxHPs = 100, HPs = 100, Atk = new Dice(Dice.Type.D6), Def = new Dice(Dice.Type.D4), Level = 1, Exp = 5 },
				Article = " a"
			},
				"worm"
			);

			Area abandoned_bank = new Area()
			{
				Name = "abandoned_bank",
				Description = "mmmmm. the stench of emptiness and capitalism",
				Article = " is an"
			};

			abandoned_bank.AddItem(new Item()
			{
				Name = "bag_of_money",
				Description = "Is money even worth anything anymore? You're greedy anyway, even if you don't know if there's anybody you can compare your wealth to anymore.",
				Article = " "
			},
				"packet_of_sugar"
			);




			// These two lines LINK the two areas together. Don't forget to go both ways or you'll end up with a dead end
			// and no way out!!!
			well.AddNeighbor(stream, "east");
			stream.AddNeighbor(well, "west");
			stream.AddNeighbor(cityGates, "east");
			cityGates.AddNeighbor(stream, "west");
			cityGates.AddNeighbor(wide_street, "east");
			start.AddNeighbor(stream, "north");
			stream.AddNeighbor(start, "south");
			well.AddNeighbor(wonderland, "inside");
			wide_street.AddNeighbor(abandoned_supermarket, "northwest");
			wide_street.AddNeighbor(abandoned_coffee_shop, "northeast");
			wide_street.AddNeighbor(hospital_ruins, "southwest");
			wide_street.AddNeighbor(abandoned_bank, "southeast");
			abandoned_supermarket.AddNeighbor(alley, "right");
			abandoned_coffee_shop.AddNeighbor(alley, "left");
			wide_street.AddNeighbor(pothole, "forward");
			// Go back to the Main method and tell it where to start the game!
			return start;
		}
	}
}

