using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDolist
{
    internal class Program
    {
        static List<TodoItem> todolist = new List<TodoItem>();

        static int nextId = 1;

        static void Main(string[] args)
        {
            while (true)   
            {
                ShowMenu();                         
                string input = Console.ReadLine();  

                if (input == "0")                   
                {
                    Console.WriteLine("Saindo…");
                    break;
                }

                switch (input)                      
                {
                    case "1":
                        AddTask();
                        break;
                    case "2":
                        ListTasks();
                        break;
                    case "3":
                        CompleteTask();
                        break;
                    case "4":
                        RemoveTask();
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
        }


        static void ShowMenu()
        {
            Console.WriteLine();
            Console.WriteLine("===== ToDo App =====");
            Console.WriteLine("1 - Adicionar tarefa");
            Console.WriteLine("2 - Listar tarefas");
            Console.WriteLine("3 - Marcar concluída");
            Console.WriteLine("4 - Remover tarefa");
            Console.WriteLine("0 - Sair");
            Console.Write("Escolha uma opção: ");
        }

        static void AddTask()
        {
            Console.Write("Digite a descrição da tarefa: ");

            string description = Console.ReadLine();

            TodoItem item = new TodoItem(nextId++, description);

            todolist.Add(item);

            Console.WriteLine($"Tarefa adcionada com ID {item.Id}.\n");
        }

        static void ListTasks()
        { 
            if (todolist.Count == 0)
            {
               Console.WriteLine("Nenhuma tarefa encontrada.\n");
                return;
            }

            Console.WriteLine("\nLista de Tarefas: ");
            foreach (var item in todolist)
            {
                string status = item.IsCompleted ? "x" : " ";
                Console.WriteLine($"{item.Id} - [{status}] {item.Description}");

            }

            Console.WriteLine();
        }

        static void CompleteTask()
        {
            Console.WriteLine("Informe o ID da tarefa a ser concluída: ");
            string entry = Console.ReadLine();

            if (int.TryParse(entry, out int id))
            {
                var item = todolist.Find(x => x.Id == id);
                if (item != null)
                {
                    item.MarkAsCompleted();
                    Console.WriteLine("Tarefa concluida com sucesso.\n");
                }
                else
                {
                    Console.WriteLine("Tarefa nao encontrada");
                }
            }
            else
            {
                Console.WriteLine("ID invalido");
            }
        }

        static void RemoveTask()
        {
            Console.WriteLine("Informe o ID da tarefa a ser removida");
            string entry = Console.ReadLine();

            if (int.TryParse(entry, out int id))
            {
                int removed = todolist.RemoveAll(x => x.Id == id);

                if (removed > 0)
                    Console.WriteLine("Tarefa removida.\n");
                else
                    Console.WriteLine("Tarefa nao encontrada");
            }
            else
            {

                Console.WriteLine("ID invalido");
            }
        }

}

}
