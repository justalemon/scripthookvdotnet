namespace GTA
{
    public class Console
    {
        /// <summary>
        /// Gets a value indicating whether the console is open.
        /// </summary>
        public bool IsOpen => ScriptHookVDotNet.GetConsole().IsOpen;
    }
}
