namespace AIProj.Models
{
    public class ConversationStore : IConversationStore
    {
        public List<Conversation> Conversations { get; } = new List<Conversation>();

        public Conversation Current { get; set; }

        public void StartNewConversation()
        {
            Conversation conversation = new Conversation();
            Current = conversation;
            Conversations.Add(conversation);
        }

        public bool SetCurrentConversation(Guid id)
        {
            Conversation? conv = Conversations.Find(x => x.Id == id);

            if (conv != null) 
            {
                Current = conv;
            }

            return conv != null;
        }
    }
}
