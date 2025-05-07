namespace ToDolist
{
    /// Este e um app para add, ler e remover objetivos na lista 

    public class TodoItem
    {

        public int Id { get; }

        public string Description { get; set; }

        public bool IsCompleted { get; private set; }

       

        public TodoItem(int id, string description)
        {
            Id = id;
            Description = description;
            IsCompleted = false;

        }

        
        public void MarkAsCompleted()
        {
            IsCompleted = true;
        }


    }

}