using System;

namespace FlandersOpen.Read.Dtos
{
    public sealed class TeamDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid CompetitionId { get; set; }
    }
}
