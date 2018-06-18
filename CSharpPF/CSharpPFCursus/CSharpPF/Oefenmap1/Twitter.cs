using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma
{
   
    [Serializable]
    public class Twitter
    {
        const string twitterbestand = @"C:\Data\Twitter.obj";

        //Alle tweets in omgekeerde chronologische volgorde
        public List<Tweet> AlleTweets()
        {

            if (File.Exists(twitterbestand))
            {
                var tweets = LeesTweets();

                //Return tweets.AlleTweets een Lijst van tweet objecten en order ze van nieuw naar oud op tijdstip "t" staat voor elke tweet in de collectie .ToList() returnt een nieuwe lijst
                return tweets.AlleTweets().OrderByDescending(t => t.Tijdstip).ToList();
            }
            else
            {
                throw new Exception("Het bestand " + twitterbestand + " is niet gevonden");
            }
        }

        public List<Tweet> TweetsVan(string naam)
        {
            //Return tweets.AlleTweets een Lijst van tweet objecten en selecteer degene "t" dewelke overeen komen met de opgegeven naam als parameter in de methode .ToList() returnt een nieuwe lijst
            return AlleTweets().Where(t => t.Naam.ToUpper() == naam.ToUpper()).ToList();
        }

        public void schrijfTweet(Tweet tweet)
        {
            Tweets tweets;
            if (File.Exists(twitterbestand))
            {
                //Als het bestand bestaat eerst de verzameling bestaande tweets inlezen
                tweets = LeesTweets();
            }
            else
            {
                tweets = new Tweets();
            }

            tweets.addTweet(tweet);
            //De verzameling tweets wegschrijven
            SchrijfTweets(tweets);
        }

        //Verzameling tweets inlezen uit het bestand
        private Tweets LeesTweets()
        {
            try
            {
                using(var bestand = File.Open(twitterbestand, FileMode.Open, FileAccess.Read))
                {
                    BinaryFormatter lezer = new BinaryFormatter();
                    return ((Tweets)lezer.Deserialize(bestand));
                }
            }
            catch (IOException)
            {
                throw new Exception("Er is een probleem met het uitlezen van het bestand");
            }
            catch (SerializationException)
            {
                throw new Exception("Fout bij het geserialiseren, " + "het tiwtterbestand kan niet meer worden geopend");
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void SchrijfTweets(Tweets tweets)
        {
            try
            {
                using (var bestand = File.Open(twitterbestand, FileMode.OpenOrCreate))
                    
                {
                    BinaryFormatter schrijver = new BinaryFormatter();
                    schrijver.Serialize(bestand, tweets);
                }
            }
            catch (IOException)
            {
                throw new Exception("Fout het openen van het bestand!");
            }
            catch (SerializationException)
            {
                throw new Exception("Fout bij het serializeren van het bestand");
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
