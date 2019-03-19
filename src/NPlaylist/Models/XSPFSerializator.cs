using System;
using System.IO;
using System.Text;
using System.Xml.Linq;

namespace NPlaylist.Models
{
    public class XSPFSerializator : ISerializator<XSPFPlaylist>
    {
        public string Serialize(XSPFPlaylist playlist)
        {
            var stringBuilder = new StringBuilder();
            if (playlist != null)
            {
                
                stringBuilder.AppendLine(new XDeclaration("1.0", "UTF-8", null).ToString());
                var trackList = new XElement("tracklist");

                foreach (var entry in playlist.Entries)
                {
                    var track = new XElement("track");

                    track.Add(new XElement("title", entry.Title));

                    track.Add(new XElement("location", entry.Path));
                    trackList.Add(track);

                }

                var playlistTag = new XElement("playlist", new XAttribute("version", playlist.Version.ToString()));

                playlistTag.Add(trackList);
                stringBuilder.AppendLine(playlistTag.ToString());
            }

            return stringBuilder.ToString();
            

           
        }

        public XSPFPlaylist Deserialize(Stream stream)
        {
            throw new System.NotImplementedException();
        }
    }
}
