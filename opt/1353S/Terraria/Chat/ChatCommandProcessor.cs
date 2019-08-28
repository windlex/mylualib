using System;
using System.Collections.Generic;
using System.Linq;
using ReLogic.Utilities;
using Terraria.Chat.Commands;
using Terraria.Localization;

namespace Terraria.Chat
{
	// Token: 0x02000199 RID: 409
	public class ChatCommandProcessor : IChatProcessor
	{
		// Token: 0x06001347 RID: 4935 RVA: 0x0041B370 File Offset: 0x00419570
		public ChatCommandProcessor AddCommand<T>() where T : IChatCommand, new()
		{
			ChatCommandAttribute cacheableAttribute = AttributeUtilities.GetCacheableAttribute<T, ChatCommandAttribute>();
			string commandKey = "ChatCommand." + cacheableAttribute.Name;
			ChatCommandId chatCommandId = ChatCommandId.FromType<T>();
			this._commands[chatCommandId] = Activator.CreateInstance<T>();
			if (Language.Exists(commandKey))
			{
				this._localizedCommands.Add(Language.GetText(commandKey), chatCommandId);
			}
			else
			{
				commandKey += "_";
				LocalizedText[] array = Language.FindAll((string key, LocalizedText text) => key.StartsWith(commandKey));
				for (int i = 0; i < array.Length; i++)
				{
					LocalizedText key2 = array[i];
					this._localizedCommands.Add(key2, chatCommandId);
				}
			}
			return this;
		}

		// Token: 0x06001348 RID: 4936 RVA: 0x0041B430 File Offset: 0x00419630
		public ChatCommandProcessor AddDefaultCommand<T>() where T : IChatCommand, new()
		{
			this.AddCommand<T>();
			ChatCommandId key = ChatCommandId.FromType<T>();
			this._defaultCommand = this._commands[key];
			return this;
		}

		// Token: 0x06001349 RID: 4937 RVA: 0x0041B460 File Offset: 0x00419660
		private static bool HasLocalizedCommand(ChatMessage message, LocalizedText command)
		{
			string text = message.Text.ToLower();
			string value = command.Value;
			return text.StartsWith(value) && (text.Length == value.Length || text[value.Length] == ' ');
		}

		// Token: 0x0600134A RID: 4938 RVA: 0x0041B4AC File Offset: 0x004196AC
		private static string RemoveCommandPrefix(string messageText, LocalizedText command)
		{
			string value = command.Value;
			if (!messageText.StartsWith(value))
			{
				return "";
			}
			if (messageText.Length == value.Length)
			{
				return "";
			}
			if (messageText[value.Length] == ' ')
			{
				return messageText.Substring(value.Length + 1);
			}
			return "";
		}

		// Token: 0x0600134B RID: 4939 RVA: 0x0041B508 File Offset: 0x00419708
		public bool ProcessOutgoingMessage(ChatMessage message)
		{
			KeyValuePair<LocalizedText, ChatCommandId> keyValuePair = this._localizedCommands.FirstOrDefault((KeyValuePair<LocalizedText, ChatCommandId> pair) => ChatCommandProcessor.HasLocalizedCommand(message, pair.Key));
			ChatCommandId value = keyValuePair.Value;
			if (keyValuePair.Key != null)
			{
				message.SetCommand(value);
				message.Text = ChatCommandProcessor.RemoveCommandPrefix(message.Text, keyValuePair.Key);
				return true;
			}
			return false;
		}

		// Token: 0x0600134C RID: 4940 RVA: 0x0041B57C File Offset: 0x0041977C
		public bool ProcessReceivedMessage(ChatMessage message, int clientId)
		{
			IChatCommand chatCommand;
			if (this._commands.TryGetValue(message.CommandId, out chatCommand))
			{
				chatCommand.ProcessMessage(message.Text, (byte)clientId);
				return true;
			}
			if (this._defaultCommand != null)
			{
				this._defaultCommand.ProcessMessage(message.Text, (byte)clientId);
				return true;
			}
			return false;
		}

		// Token: 0x040034A8 RID: 13480
		private Dictionary<LocalizedText, ChatCommandId> _localizedCommands = new Dictionary<LocalizedText, ChatCommandId>();

		// Token: 0x040034A9 RID: 13481
		private Dictionary<ChatCommandId, IChatCommand> _commands = new Dictionary<ChatCommandId, IChatCommand>();

		// Token: 0x040034AA RID: 13482
		private IChatCommand _defaultCommand;
	}
}
