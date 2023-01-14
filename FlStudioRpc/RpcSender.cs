using System;
using DiscordRPC;
using FlStudioInfoHelper;

namespace FlStudioRpc
{
    /// <summary>
    /// Class, intended to updating and generating presence for Discord RPC
    /// </summary>
    public class RpcSender
    {
        /// <summary>
        /// Represents Discord RPC client, it is needed for setting presence
        /// </summary>
        public DiscordRpcClient Client { get; } = new(RpcHelper.ApplicationId);

        /// <summary>
        /// Represents information about FL Studio and project in it.
        /// </summary>
        public FlStudioInfoRetreiver FlStudioInfo { get; }

        /// <summary>
        /// Creates new instance of <see cref="RpcSender"/>.
        /// </summary>
        /// <param name="retreiver"></param>
        public RpcSender(FlStudioInfoRetreiver retreiver)
        {
            FlStudioInfo = retreiver;

            Client.Initialize();
        }

        /// <summary>
        /// Creates new instance of <see cref="RpcSender"/>.
        /// </summary>
        public RpcSender()
        {
            FlStudioInfo = new();

            Client.Initialize();
        }

        /// <summary>
        /// Generate presence based on <see cref="FlStudioInfoRetreiver"/> information.
        /// </summary>
        /// <returns></returns>
        public RichPresence GeneratePresence()
        {
            string projtitle = FlStudioInfo.ProjectName;

            return new()
            {
                Timestamps = new(FlStudioInfo.StartTime - RpcHelper.DifferenceBetweenUtcAndSystem),
                Details = (projtitle.Length <= 64) ? projtitle : string.Empty,
                Assets = new()
                {
                    LargeImageKey = RpcHelper.LargeImageKey
                }
            };
        }

        /// <summary>
        /// Update presence using <see cref="DiscordRpcClient"/> API.
        /// </summary>
        /// <param name="presence"></param>
        public void UpdatePresence(RichPresence presence) => Client.SetPresence(presence);
    }
}
