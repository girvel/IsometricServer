﻿using System;
using Isometric.CommonStructures;
using Isometric.Core.Modules;
using Isometric.Core.Modules.TickModule;
using Isometric.Server;
using ServerCommandManager = Isometric.Server.Modules.CommandModule.Server.CommandManager;

namespace Isometric.Client.Modules.LogModule
{
    internal static class LogEvents
    {
        internal static void Init()
        {
            ErrorReporter.Instance.OnError += _reportError;

            SingleServer.Instance.OnAcceptedConnection += _onAcceptedConnection;
            SingleServer.Instance.OnWrongCommand += _onWrongCommand;
            ServerCommandManager.Instance.OnLoginAttempt += _onLoginAttempt;

            Connection.OnConnectionEnd += _onConnectionEnd;
            Connection.OnConnectionAbort += _onConnectionAbort;
            Connection.OnDataReceived += _onDataReceived;
            Connection.OnWrongCommand += _onWrongCommand;

            SerializationManager.OnSuccessfulSaving +=
                () => _onSuccessfulAction("Saved");
            SerializationManager.OnSuccessfulOpening +=
                () => _onSuccessfulAction("Opened");

            SerializationManager.OnSavingException +=
                ex => _onSerializationException("Saving", ex);
            SerializationManager.OnOpeningException +=
                ex => _onSerializationException("Opening", ex);

            ClocksManager.OnTick += _onTick;
        }



        private static void _reportError(string message)
        {
            Log.Instance.Write($"ERROR REPORT: {message}");
        }



        #region SingleServer

        private static void _onAcceptedConnection()
        {
            Log.Instance.Write("Connection accepted");
        }

        private static void _onLoginAttempt(string email, LoginResult result)
        {
            var message = string.Empty;

            switch (result)
            {
                case LoginResult.Successful:
                    message = "Successful attempt to enter";
                    break;

                case LoginResult.Unsuccessful:
                    message = "Unsuccessful attempt to enter";
                    break;

                case LoginResult.Banned:
                    message = "Attempt to enter by banned account";
                    break;

                default:
                    message = "Unknown LoginResult";
                    break;
            }

            Log.Instance.Write(message + $"\n\tEmail: {email}");
        }

        private static void _onWrongCommand(string command)
        {
            Log.Instance.Write(command);
        }

        #endregion



        #region Connection

        private static void _onConnectionAbort(Connection connection)
        {
            Log.Instance.Write("Connection aborted. Login: " + connection.Account.Login);
        }

        private static void _onConnectionEnd(Connection connection)
        {
            Log.Instance.Write("Connection end. Login: " + connection.Account.Login);
        }

        private static void _onDataReceived(string data, Account account)
        {
            Log.Instance.Write($"Data received by {account.Login}.\n\n{data}\n");
        }

        private static void _onWrongCommand(string data, Account account)
        {
            Log.Instance.Write($"Wrong command received by {account.Login}.\n{data}");
        }
    
        #endregion



        #region SerializationManager

        private static void _onSuccessfulAction(string action)
        {
            Log.Instance.Write($"{action} successfully");
        }

        private static void _onSerializationException(string process, Exception exception)
        {
            Log.Instance.Exception(exception, "{process} exception was catched");
        }

        #endregion



        #region ClocksManager

        private static void _onTick()
        {
            Log.Instance.Write("Tick event");
        }

        #endregion
    }
}

