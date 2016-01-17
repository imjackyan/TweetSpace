using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tweetinvi.Core.Interfaces.Models;
using Tweetinvi.Core.Interfaces.Models.Entities;
using Tweetinvi.Core.Parameters;
using Tweetinvi.Logic;
using Tweetinvi.Logic.Model;

namespace TweetSpace
{
    public class TweetObj
    {
        public string text { get; set; }
        public string creatorName { get; set; }
        public string screenName { get; set; }
        public DateTime time { get; set; }
        public ICoordinates coords { get; set; }
        public String country { get; set; }
        public List<String> hashtags { get; set; }//might be empty
        private String infoSep = "-dG3=";

        public TweetObj(string text, string creatorName, string screenName, DateTime time, ICoordinates coords, IPlace place, List<IHashtagEntity> hashtags)
        {
            this.text = text;
            if (creatorName == ""){
                this.creatorName = " ";
            } else {
                this.creatorName = creatorName;
            }
            if (screenName == "")
            {
                this.screenName = " ";
            }
            else {
                this.screenName = screenName;
            }
            this.time = time;

            if (coords != null)
            {
                this.coords = coords;
            }
            else
            {
                this.coords = new Coordinates(0.0,0.0);
            }
            if (place != null) { 
                this.country = place.Country;
            } else{
                country = " ";
            }
            this.hashtags = new List<String>();
            for (int i= 0; i < hashtags.Count; i++)
            {
                this.hashtags.Add(hashtags[i].Text);
            }
        }

        public TweetObj(string whole)
        {
            String [] info = whole.Split(new string[] { infoSep }, StringSplitOptions.RemoveEmptyEntries);
            this.text = info[0];
            this.creatorName = info[1];
            this.screenName = info[2];
            this.time = DateTime.Parse(info[3]);
            this.coords = new Coordinates(Double.Parse(info[4]), Double.Parse(info[5]));
            this.country = info[6];
            hashtags = new List<String>();
            if (info.Length == 8){
                String [] hash = info[7].Split(' ');
                for (int i = 0; i < hash.Length; i++)
                {
                    hashtags.Add(hash[i]);
                }
            }

        }

        public override String ToString()
        {
            String info = "";
            info += (text+infoSep+creatorName+infoSep+screenName+infoSep+time.ToString()+
                infoSep+coords.Latitude+ infoSep+coords.Longitude+ infoSep+country+infoSep);
            for (int i = 0; i < hashtags.Count; i++)
            {
                info += hashtags[i];
                info += " ";
            }
            return info;
        }
    }
}
