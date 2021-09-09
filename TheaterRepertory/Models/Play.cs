using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TheaterRepertory.Models
{
    public class Play
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Desc { get; set; }

        [DataType(DataType.Date)]
        public DateTime ScheduleTime { get; set; }
        public string ActorsList { get; set; }

        [DataType(DataType.ImageUrl)]
        public string Image { get; set; }
    }
}