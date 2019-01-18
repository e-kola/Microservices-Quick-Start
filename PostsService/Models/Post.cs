using System;
using System.ComponentModel.DataAnnotations;

namespace MicroservicesQuickStart.PostsService.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(1024)]
        public string Text { get; set; }
    }
}
