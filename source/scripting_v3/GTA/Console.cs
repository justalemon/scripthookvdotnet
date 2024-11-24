namespace GTA
{
    public class Console
    {
        /// <summary>
        /// Gets a value indicating whether the console is open.
        /// </summary>
        public bool IsOpen => ScriptHookVDotNet.GetConsole().IsOpen;

        /// <summary>
        /// Writes the specified message to the console with the level set to INFO.
        /// </summary>
        /// <param name="message">The message to print.</param>
        /// <param name="args">The arguments used to format the message, if any.</param>
        public void WriteInfo(string message, params object[] args) => ScriptHookVDotNet.GetConsole().PrintInfo(message, args);
        /// <summary>
        /// Writes the specified message to the console with the level set to WARNING.
        /// </summary>
        /// <param name="message">The message to print.</param>
        /// <param name="args">The arguments used to format the message, if any.</param>
        public void WriteWarning(string message, params object[] args) => ScriptHookVDotNet.GetConsole().PrintWarning(message, args);
        /// <summary>
        /// Writes the specified message to the console with the level set to ERROR.
        /// </summary>
        /// <param name="message">The message to print.</param>
        /// <param name="args">The arguments used to format the message, if any.</param>
        public void WriteError(string message, params object[] args) => ScriptHookVDotNet.GetConsole().PrintError(message, args);
    }
}
