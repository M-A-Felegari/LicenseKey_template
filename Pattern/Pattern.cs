namespace Pattern
{
    public class Pattern
    {
        /////////////////// this dictionary helps us to Encryption
        public static Dictionary<int, string> lockCodes = new Dictionary<int, string>()
        {
            {1,"A" },{2,"D" },{3,"B" },{4,"C" },{5,"E" },{6,"H" },{7,"F" },{8,"G" },
            {9,"L" },{10,"M" },{11,"H" },{12,"I" },{13,"K" },{14,"J" },{15,"O" },{16,"M" },
            {17,"Q" },{18,"R" },{19,"P" },{20,"S" },{21,"Z" },{22,"U" },{23,"W" },{24,"V" },
            {25,"X" },{26,"Y" }
        };
        public static string SerialPattern(string txtUserNameText)
        {
            string pattern = ""; //our lock pattern
            for (int i = 1; pattern.Length < 16; i++) //to generate a key with 16 character
            {
                // we need this info to check serial number and create our pattern
                string username = txtUserNameText;
                short directoryLength = (short)Environment.CurrentDirectory.Length;
                string systemUserName = Environment.UserName;
                short systemUserNameLength = (short)systemUserName.Length;
                //to control directory length
                if (directoryLength < 20)
                {
                    pattern += lockCodes[directoryLength + i] + lockCodes[directoryLength];
                }
                else if (directoryLength >= 20 && directoryLength <= 26)
                {
                    pattern += lockCodes[directoryLength + i - 16] + lockCodes[directoryLength - i];
                }
                else if (directoryLength > 26 && directoryLength < 100)
                {
                    pattern += lockCodes[3*i+2] + lockCodes[2*i+2];
                }
                else
                {
                    pattern += lockCodes[Convert.ToInt16(directoryLength.ToString("0")) + 5] +
                        lockCodes[Convert.ToInt16(directoryLength.ToString("0")) + 7];
                }
                pattern += lockCodes[username.Length +i];
                pattern += lockCodes[systemUserName.Length +(3*i-5)];
            }
            return pattern;
        }
    }
}