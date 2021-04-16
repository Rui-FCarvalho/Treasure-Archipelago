using System.Collections.Generic;

namespace Lexic
{
    //A dictionary containing syllables that will form semi-historical names of kings, along with their lastnames. Fits any "alternate-history" RPG or strategy game.
    public class PirateNames : BaseNames
    {
        private static Dictionary<string, List<string>> syllableSets = new Dictionary<string, List<string>>()
            {
                {
                    "firstnames",    new List<string>(){
                                                    "Winston_", "Bill_", "Jack_",
                                                    "Henry_", "John_", "Louis_",
                                                    "Wallace_", "Edward_", "Vincent_", "Nathaniel_", "George_", 
                                                    "Juan_", "Peter_", "Ali_", "Lawrence_", "Donald_", "Boris_",
                                                    "Zhang_", "Simon_", "Uluj_", "Jambe_", "Moses_", "Shirahama_",
                                                    "Hans_", "Williams_", "Vincenzo_", "Jean_Bart_", "Lancelot_",
                                                    "Gervasio_", "Abacaxi_" , "Giovanni_", "Pierre_", "Bartolomeu_", "Carlos_", "Henrique_", "Polnareff_"
                                                    }
                },
                {
                    "nicknames",   new List<string>(){
                                                    "'Iron Fists'", "'Plank Walker'", "'The Drunk'", "'Scurvy Dog'", "'Sea Rat'", "'Crazy Eyes'", "'Devil's Smile'",
                                                    "'Tide Turner'", "'Fish_Fingers'", "'BlackBeard'","'The Bastard'", "'Hook'", "'Of Arabia'", "'The Priest'","'Lady Lover'",
                                                    "'Snake Eyes'", "'Rabbit'", "'The Kid'", "'Eye of the Storm'", "'The Mariner'", "'Six Fingers'", "'Four Fingers'", "'The Lucky'",
                                                    "'The Portuguese'", "'The Spaniard'", "'Of Wales'","'The French'","'The Dutch'", "'The English'", "'Of Austria'", "'Blue Blood'"
                                                    }
                },
            };

        private static List<string> rules = new List<string>()
            {
                 "%100firstnames%100nicknames", 
            };

        public new static List<string> GetSyllableSet(string key) { return syllableSets[key]; }

        public new static List<string> GetRules() { return rules; }
    }
}
