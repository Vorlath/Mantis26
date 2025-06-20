// "bad guy" { Position, Health, DialogueState }

// <shake>hello</shake> how are you?


NPCDialogueNode mainRoom = new NPCDialogueNode()
{
    Handle = "Main Room",
    Data = [
        new DialogueText() { Value = "This is the main room." },
        new DialogueDelay() { Interval = TimeSpan.FromSeconds(2) },
        new DialogueText() { Value = "Type 'north' to go to the north room. \\n\\n Type 'east' to go to the east room." },
    ]
};

PlayerDialogueNode backResponse = new PlayerDialogueNode()
{
    Handle = "Back",
    Data = [],
    Response = mainRoom,
};

PlayerDialogueNode northPlayerResponse = new PlayerDialogueNode()
{
    Handle = "North",
    Data = [],
    Response = new NPCDialogueNode()
    {
        Handle = "North Room",
        Data = [
            new DialogueText() { Value = "This is the north room. It's small and stuffy." },
            new DialogueDelay() { Interval = TimeSpan.FromSeconds(2) },
            new DialogueText() { Value = "Type 'back' to go back to the main room." },
        ],
        PossiblePlayerResponses = [
            backResponse
        ]
    }
};

PlayerDialogueNode eastPlayerResponse = new PlayerDialogueNode()
{
    Handle = "East",
    Data = [],
    Response = new NPCDialogueNode()
    {
        Handle = "East Room",
        Data = [
            new DialogueText() { Value = "This is the east room. It's small and stuffy." },
            new DialogueDelay() { Interval = TimeSpan.FromSeconds(2) },
            new DialogueText() { Value = "Type 'back' to go back to the main room." },
        ],
        PossiblePlayerResponses = [
            backResponse
        ]
    }
};

mainRoom.PossiblePlayerResponses.Add(northPlayerResponse);
mainRoom.PossiblePlayerResponses.Add(eastPlayerResponse);



NPCDialogueNode? currentNPCDialogueNode = mainRoom;
while (currentNPCDialogueNode != null)
{
    foreach(IDialogueData data in currentNPCDialogueNode.Data)
    {
        data.RenderData();
    }

    if (currentNPCDialogueNode.PossiblePlayerResponses.Any())
    {
        bool goodChoice = false;
        while (!goodChoice)
        {
            string choice = Console.ReadLine();
            PlayerDialogueNode? playerReponse = currentNPCDialogueNode.PossiblePlayerResponses.FirstOrDefault(x => x.Handle == choice);
            if (playerReponse == null)
            {
                Console.WriteLine("Invalid command, please select a proper command");
                Console.WriteLine(currentNPCDialogueNode.Data);
            }
            else
            {
                goodChoice = true;
                currentNPCDialogueNode = playerReponse.Response;
            }
        }
    }
}

public interface IDialogueData
{
    void RenderData();
}

public class DialogueText : IDialogueData
{
    public required string Value { get; init; } = string.Empty;

    public void RenderData()
    {
        Console.WriteLine(this.Value);
    }
}

public class DialogueDelay : IDialogueData
{
    public required TimeSpan Interval { get; init; }

    public void RenderData()
    {
        Thread.Sleep(this.Interval);
    }
}

public class DialogueNode
{
    public required string Handle { get; init; }
    public required IDialogueData[] Data { get; init; }
}
public class NPCDialogueNode : DialogueNode
{
    public List<PlayerDialogueNode> PossiblePlayerResponses { get; init; } = new List<PlayerDialogueNode>();
}

public class PlayerDialogueNode : DialogueNode
{
    public required NPCDialogueNode? Response { get; init; }
}

// using (var game = new Mantis26.Sokoban.Game1())
// {
//     game.Run();
// }