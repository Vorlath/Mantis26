namespace TextAdventure.Systems
{
    public class DialogueSystem
    {
        public List<TextElement> ParseText(string rawText)
        {
            List<TextElement> textString = new List<TextElement>();
            int duration = 0;
            for (int i = 0; i < rawText.Length; i++)
            {
                if (rawText[i] == '<' && i + 1 < rawText.Length)
                {
                    switch (rawText[i + 1])
                    {
                        case 'w':
                            break;
                        case 's':
                            break;
                        case '<':
                            break;
                        default:
                            throw new NotImplementedException();
                    }
                }
                duration = FindDuration(rawText[i]);

                textString.Add(new TextElement(duration, rawText[i]));
            }

            return textString;
        }

        public int FindDuration(char rawText)
        {
            switch (rawText)
            {
                case '.':
                case '?':
                case '!':
                    return 20;
                case ',':
                case ';':
                    return 10;
                default:
                    return 5;
            }
        }
    }
}
