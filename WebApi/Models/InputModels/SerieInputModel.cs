﻿namespace WebApi.Models.InputModels
{
    public class SerieInputModel
    {
        public int SeId { get; set; }
        public string SeTitle { get; set; } = null!;
        public string SeDate { get; set; } = null!;
        public string? SeImg { get; set; }
        public int? SeQtdSeasons { get; set; }
        public string? SeSynopsis { get; set; }
        public int? GrId { get; set; }
    }
}
