using System;
using System.Collections.Generic;

class Video
{
    public string Title { get; }
    public string Author { get; }
    public int Duration { get; }
    public List<Comment> Comments { get; } = new List<Comment>();

    public Video(string title, string author, int duration)
    {
        Title = title;
        Author = author;
        Duration = duration;
    }

    public void AddComment(string userName, string text)
    {
        Comments.Add(new Comment(userName, text));
    }

    public int GetCommentCount()
    {
        return Comments.Count;
    }
}

class Comment
{
    public string UserName { get; }
    public string Text { get; }

    public Comment(string userName, string text)
    {
        UserName = userName;
        Text = text;
    }
}

class MyProgram
{
    static void Main()
    {
        // Crear algunos videos
        var video1 = new Video("Video Title 1", "Author 1", 300);
        var video2 = new Video("Video Title 2", "Author 2", 240);
        var video3 = new Video("Video Title 3", "Author 3", 180);

        // Agregar comentarios a los videos
        video1.AddComment("User1", "¡Gran video!");
        video1.AddComment("User2", "Me encantó la explicación.");
        video2.AddComment("User3", "Buena presentación.");
        video3.AddComment("User4", "Tema interesante.");

        // Crear una lista de videos
        var videos = new List<Video> { video1, video2, video3 };

        // Mostrar información para cada video
        foreach (var video in videos)
        {
            Console.WriteLine($"Título: {video.Title}");
            Console.WriteLine($"Autor: {video.Author}");
            Console.WriteLine($"Duración: {video.Duration} segundos");
            Console.WriteLine($"Número de comentarios: {video.GetCommentCount()}");

            Console.WriteLine("Comentarios:");
            foreach (var comment in video.Comments)
            {
                Console.WriteLine($"- {comment.UserName}: {comment.Text}");
            }

            Console.WriteLine();
        }
    }
}
