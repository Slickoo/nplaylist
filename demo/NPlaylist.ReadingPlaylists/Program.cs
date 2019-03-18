using System;
using System.IO;
using System.Xml.Xsl;
using NPlaylist.Models;

namespace NPlaylist.ReadingPlaylists
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var obj = new M3USerializator();

            var playlist = obj.Deserialize(new FileStream(@"C:\Users\mpodlesnov\OneDrive - ENDAVA\Desktop\Books.txt",
                FileMode.Open));
            
            using (var stream = new StreamWriter(@"C:\Users\mpodlesnov\OneDrive - ENDAVA\Desktop\Serialized.txt"))
            {

                var xs = new XSPFSerializator();
                var playListXSPF = new XSPFPlaylist()
                {
                    Version = 1,
                    Xmlns = "http://xspf.org/ns/0/",
                    Entries =
                    {
                        new XSPFEntry
                        {
                            Path = "afaffa.mp3",
                            Title = "Tumba Iumba"
                        },
                        new XSPFEntry
                        {
                            Path = @"D://afaffa.mp3",
                            Title = "Testa"
                        }
                    }
                };
                
                string st = xs.Serialize(playListXSPF);
                stream.Write(st);
            }
           
            Console.ReadLine();
        }
    }
}
