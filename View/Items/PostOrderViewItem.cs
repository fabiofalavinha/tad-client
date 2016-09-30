namespace TadManagementTool.View.Items
{
    public class PostOrderViewItem
    {
        public int LastPosition { get; private set; }
        public int NewPosition { get; private set; }
        public PostViewItem Data { get; private set; }

        public PostOrderViewItem(int lastPosition, int newPosition, PostViewItem data)
        {
            LastPosition = lastPosition;
            NewPosition = newPosition;
            Data = data;
        }
    }
}
