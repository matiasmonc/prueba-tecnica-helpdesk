using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpdesk.Business.DTOs
{
    public class CreateCommentDTO
    {
        /// <summary>
        /// Texto del comentario.
        /// </summary>
        [Required]
        [StringLength(1000)]
        public string Text { get; set; } = string.Empty;

        /// <summary>
        /// Identificador del usuario que crea el comentario.
        /// </summary>
        [Required]
        public Guid CreatedBy { get; set; }
    }
}
