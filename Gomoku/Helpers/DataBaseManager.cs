using Gomoku.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.Json;

namespace Gomoku.Helpers
{
    class DataBaseManager
    {
        public List<Player> playersList = new List<Player>();
        private readonly string filePath = System.IO.Directory.GetCurrentDirectory();
        private const string playersListFileName = "playerslist.json";

        public bool SaveToFile()
        {
            try
            {
                using StreamWriter playersStreamWriter = new StreamWriter(filePath + "\\" + playersListFileName);
                string playersJson = JsonSerializer.Serialize(playersList);
                playersStreamWriter.Write(playersJson);
                playersStreamWriter.Flush();
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return false;
            }
        }

        public List<Player> ReadFromFile()
        {
            try
            {
                using StreamReader playersStreamReader = new StreamReader(filePath + "\\" + playersListFileName);
                string playersJson = playersStreamReader.ReadToEnd();
                playersList = JsonSerializer.Deserialize<List<Player>>(playersJson);
                return playersList;
            }
            catch(Exception)
            {
                return playersList;
            }
        }

        public void UpdateOrCreatePlayer(Player player)
        {
            int index = playersList.FindIndex(p => p.Name == player.Name);
            if (index >= 0)
            {
                playersList[index] = player;
            }
            else
            {
                playersList.Add(player);
            }
        }
    }
}
