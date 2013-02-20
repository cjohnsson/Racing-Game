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
    class HighScore
    {
        private Dictionary<int, ScoreList> _highScoreList;
        private ScoreList _scoreList;
        private SpriteBatch _spriteBatch;
        private SpriteFont _spriteFont;
        private int _map;

        public HighScore(int map, SpriteBatch spriteBatch, SpriteFont spriteFont)
        {
            _spriteFont = spriteFont;
            _spriteBatch = spriteBatch;
            _map = map;
            _highScoreList = LoadHighScoreList();
            _scoreList = _highScoreList[_map];
        }

        public void GetHighMapScore()
        {
            Draw(_spriteBatch);
        }

        public void SetHighMapScore(TimeSpan newTime)
        {
            _scoreList.SetScore(newTime);
        }

        public Dictionary<int, ScoreList> LoadHighScoreList() {
            try 
            {
                FileStream fileStream = new FileStream("HighScoreList.dat", FileMode.Open);
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                _highScoreList = (Dictionary<int, ScoreList>)binaryFormatter.Deserialize(fileStream);
            }
            catch (SerializationException) {
                if (_highScoreList == null) {
                    SaveHighScoreList();
                    LoadHighScoreList();
                }   throw new SerializationException("Fel vid hämtning av highscore!");
            }
            return _highScoreList;
        }

        public void SaveHighScoreList() {
            try {
                FileStream fileStream = new FileStream("HighScoreList.dat", FileMode.Create);
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(fileStream, _highScoreList);
                fileStream.Close();
            }
            catch (SerializationException) {
                throw new SerializationException("Fel vid sparning av highscore!");
            }
        }

        void Draw(SpriteBatch spriteBatch)
        {
            int yPosition = 20;
            foreach (Score score in _scoreList.scoreArray)
            {
                spriteBatch.DrawString(_spriteFont, "Name: " + score.Name + "Time: " + score.Time,new Vector2(20, yPosition),Color.White);
                yPosition += 20;
            } 
        }
    }
}
