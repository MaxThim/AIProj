namespace AIProj.Models
{
    public interface IConversationStore
    {
        List<Conversation> Conversations { get; }

        Conversation Current { get; }

        public void StartNewConversation();
    }
}