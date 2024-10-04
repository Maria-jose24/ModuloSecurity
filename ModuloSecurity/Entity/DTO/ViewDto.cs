﻿namespace Entity.DTO
{
    public class ViewDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool State { get; set; }

        public string ? Modulo { get; set; }

        public int ModuloId { get; set; }
    }
}