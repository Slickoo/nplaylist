using System;
using System.IO;
using System.Text;

namespace NPlaylist.Models
{
    public class M3USerializator : ISerializator<M3UPlaylist>
    {
        public string  Serialize(M3UPlaylist playlist)
        {
           var  stringBuilder = new StringBuilder();
                foreach (var entry in playlist.Entries)
                {
                    stringBuilder.AppendLine(entry.Path);
                }

                return stringBuilder.ToString();
        }

        public M3UPlaylist Deserialize(Stream stream)
        {
            var playlist = new M3UPlaylist();
     
            StreamReader sr = new StreamReader(stream);
            

            while(!sr.EndOfStream)
            {
                
                    playlist.Entries.Add(new M3UEntry
                    {
                        Path = sr.ReadLine()
                    });
                
            }

            return playlist;
        }
    }
}
