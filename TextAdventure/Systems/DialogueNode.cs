namespace TextAdventure.Systems
{

    public class DialogueNode
    {

        public Dictionary<string, DialogueNode> DialogueNodes;
        public string Data { get; set; }

        public DialogueNode(string data)
        {
            DialogueNodes = new Dictionary<string, DialogueNode>();
            this.Data = data;
        }

        public void addNode(DialogueNode node, string choice = "1")
        {
            DialogueNodes.Add(choice, node);
        }

        public DialogueNode getNode(string choice)
        {
            DialogueNode value;
            return DialogueNodes.TryGetValue(choice, out value) ? value : null;
        }
    }
}
