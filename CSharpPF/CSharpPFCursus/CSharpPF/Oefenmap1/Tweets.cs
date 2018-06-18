using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma
{
    [Serializable]
    public class Tweets
    {
        private List<Tweet> tweetsValue;

        public ReadOnlyCollection<Tweet> AlleTweets()
        {
            return new ReadOnlyCollection<Tweet>(tweetsValue);
        }

        public void addTweet(Tweet tweet)
        {
            if(tweetsValue == null)
            {
                tweetsValue = new List<Tweet>();
                tweetsValue.Add(tweet);
            }
        }
    }
}
