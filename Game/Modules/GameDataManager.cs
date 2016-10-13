﻿using System;
using System.IO;
using Isometric.Core.Modules;
using Isometric.Core.Modules.SettingsModule;
using Isometric.Game.Modules.GameData.Defaults;
using Isometric.GameDataTools.Exceptions;

namespace Isometric.Game.Modules
{
    [Serializable]
    public class GameDataManager
    {
        public static GameDataManager Instance { get; set; }



        /// <exception cref="InvalidGameDataException">Thrown when data in stream is invalid</exception>
        public GameDataManager(Stream stream)
        {
            BuildingPatternList.Instance = DefaultBuildingPatterns.Instance.GetPatterns();
            AreaPatternList.Instance = DefaultAreaPatterns.Instance.Areas;
            BuildingGraph.Instance = DefaultBuildingGraph.Instance.Graph;
            
            foreach (var property in GameConstantAttribute.GetProperties())
            {
                if (DefaultConstants.Instance.ConstantValues.ContainsKey(property.Name))
                {
                    property.SetValue(null, DefaultConstants.Instance.ConstantValues[property.Name]);
                }
                else
                {
                    throw new NotImplementedException("DefaultConstants.ConstantValues does not contain all expected values");
                }
            }

            // TODO decomment loader

            //GameDataContainer data;

            //try
            //{
            //    data = (GameDataContainer) new BinaryFormatter().Deserialize(stream);
            //}
            //catch (SerializationException ex)
            //{
            //    throw new InvalidGameDataException("Game data can not be deserialized", ex);
            //}

            //Patterns = data.Patterns;
            //BuildingGraph.Instance = data.BuildingGraph;

            //foreach (var property in GameConstantAttribute.GetProperties())
            //{
            //    if (!data.Constants.ContainsKey(property.Name))
            //    {
            //        throw new InvalidGameDataException("Game data does not contain all game constants");
            //    }

            //    property.SetValue(null, data.Constants[property.Name]);
            //}
        }



        protected static object ToPropertyValue(string name, object data)
        {
            throw new NotImplementedException();

            //if (name == nameof(World.GenerateArea))
            //{
            //    return new World.AreaGenerator(
            //        (grid, x, y, seed) => new Area(AreaPatterns.Forest, seed));
            //}

            //return data;
        }
    }
}