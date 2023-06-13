﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlanejaiBack.Models
{
    public class EventModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; }

        [Required(ErrorMessage = "Informe um nome.")]
        public string? Name { get; set; }

        public string? Description { get; set; }

        [Required(ErrorMessage = "Informe uma data de início.")]
        public DateTime? StartDate { get; set; }

        [Required(ErrorMessage = "Informe um horário de início.")]
        public DateTime? StartsAt { get; set; }

        [Required(ErrorMessage = "Informe uma data de encerramento.")]
        public DateTime? EndDate { get; set; }

        [Required(ErrorMessage = "Informe um horário de encerramento.")]
        public DateTime? EndsAt { get; set; }

        [Required(ErrorMessage = "Informe um local.")]
        public string? Local { get; set; }

        public UserModel? Organizer { get; set; }

        public bool DatesAreValid ()
        {
            if (EndDate.HasValue && EndsAt.HasValue && StartDate.HasValue && StartsAt.HasValue)
            {
                DateTime endDateTime = EndDate.Value.Date + EndsAt.Value.TimeOfDay;
                DateTime startDateTime = StartDate.Value.Date + StartsAt.Value.TimeOfDay;

                if (endDateTime < startDateTime)
                {
                    return false;
                }
            }
            
            return true;
        }
    }
}