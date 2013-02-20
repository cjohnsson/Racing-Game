using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Color = Microsoft.Xna.Framework.Color;

namespace RaceGame
{
    [Serializable]
    public class HighScore
    {
        private Dictionary<int, ScoreList> _highScoreList;
        private ScoreList _scoreList;
        private SpriteFont _spriteFont;
        private int _map;

        public HighScore(int map, SpriteFont spriteFont)
        {
            _spriteFont = spriteFont;
            _map = map;
            LoadHighScoreList();
            _scoreList = _highScoreList[_map];
        }

        private void InitializeHighScoreList()
        {
            _highScoreList = new Dictionary<int, ScoreList>();
            for (int i = 0; i < 5; i++)
            {
                _highScoreList.Add(i, new ScoreList());
            }
        }

        public void SetHighMapScore(TimeSpan newTime)
        {
            _scoreList.SetScore(newTime);
        }

        public void LoadHighScoreList() {
            try 
            {
                FileStream fileStream = new FileStream("HighScore.dat", FileMode.Open);
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                _highScoreList = (Dictionary<int, ScoreList>) binaryFormatter.Deserialize(fileStream);
            }
            catch (FileNotFoundException) {
                InitializeHighScoreList();
            }
        }

        public void SaveHighScoreList() {
            try {
                FileStream fileStream = new FileStream("HighScore.dat", FileMode.Create);
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(fileStream, _highScoreList);
                fileStream.Close();
            }
            catch (SerializationException) {
                throw new SerializationException("Fel vid sparning av highscore!");
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            int yPosition = 40;
            foreach (Score score in _scoreList.scoreArray)
            {
                if (score != null)
                {
                    spriteBatch.DrawString(_spriteFont, "Name: " + score.Name + "Time: " + score.Time,
                                           new Vector2(40, yPosition), Color.White);
                    yPosition += 20;
                }
            } 
        }
    }
}
