﻿using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using IsometricCore.Modules.WorldModule;
using VisualServer;
using IsometricCore.Modules;
using CustomProperty.Dynamic;
using IsometricImplementation.Modules;

namespace VisualClient.Modules
{
    public class SerializationManager
    {
        #region Singleton-part

        [Obsolete("using backing field")]
        private static SerializationManager _instance;

        #pragma warning disable 618

        public static SerializationManager Instance
        {
            get { return _instance ?? (_instance = new SerializationManager()); }

            set
            {
                #if DEBUG

                if (_instance != null)
                {
                    throw new ArgumentException("Instance is already set");
                }

                #endif

                _instance = value;
            }
        }

        #pragma warning restore 618

        #endregion



        public string SavingDirectory { get; set; } = "saves";
        public string SavingFile { get; set; } = "game-full-save";

        public uint SavingPeriodMilliseconds = 60000;



        public static event Action OnSuccessfulSaving;
        public static event Action<Exception> OnSavingException;

        public static event Action OnSuccessfulOpening;
        public static event Action<Exception> OnOpeningException;



        public delegate object Accessor();
        public delegate void Mutator(object value);

        public Property[] SerializationList { get; set; } =
            {
                new Property(
                    get: () => Core.Version,
                    set: value => Core.SavingVersion = value),

                new Property(
                    get: () => Implementation.Version,
                    set: value => Implementation.SavingVersion = value),

                new Property(
                    get: () => Client.Version,
                    set: value => Client.SavingVersion = value),

                new Property(
                    get: () => Server.Version,
                    set: value => Server.SavingVersion = value),

                new Property(
                    get: () => SingleServer.Instance,
                    set: value => SingleServer.Instance = value),

                new Property(
                    get: () => World.Instance,
                    set: value => World.Instance = value),

                new Property(
                    get: () => Instance.SavingPeriodMilliseconds,
                    set: value => Instance.SavingPeriodMilliseconds = value),
            };





        public bool TrySave()
        {
        #if !DEBUG
            try
        #endif
            {
                if (!Directory.Exists(SavingDirectory))
                {
                    Directory.CreateDirectory(SavingDirectory);
                }

                var serializer = new BinaryFormatter();

                using (var stream = File.OpenWrite($"{SavingDirectory}/{SavingFile}"))
                {
                    foreach (var property in SerializationList)
                    { 
                        // TODO fix saving
                        //serializer.Serialize(stream, property.Get());
                    }
                }

                OnSuccessfulSaving?.Invoke();

                return true;
            }
        #if !DEBUG
            catch (Exception ex)
            {
                OnSavingException?.Invoke(ex);

                return false;
            }
        #endif
        } 

        public bool TryOpen()
        {
            try
            {
                if (!File.Exists($"{SavingDirectory}/{SavingFile}"))
                {
                    return false;
                }

                using (var mainStream = File.OpenRead($"{SavingDirectory}/{SavingFile}"))
                {
                    var serializer = new BinaryFormatter();

                    foreach (var property in SerializationList)
                    {
                        property.Set(serializer.Deserialize(mainStream));
                    }
                }
                OnSuccessfulOpening?.Invoke();

                return true;
            }
            catch (Exception ex)
            {
                OnOpeningException?.Invoke(ex);

#if DEBUG

                if (ex.Message != "Attempting to deserialize an empty stream.")
                {
                    throw;
                }
                else
                {
                    return false;
                }

#else

                return false;

#endif
            }
        }
    }
}

